using System.IO;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using System;


namespace SiteInvestigation.Module.Extensions
{
    [DefaultProperty("FileName")]
    public class FileSystemStoreObject : BaseObject, IFileData, IEmptyCheckable
    {
        private Stream tempSourceStream;
        private string tempFileName = string.Empty;
        private static object syncRoot = new object();
        public FileSystemStoreObject(Session session) : base(session) { }
        public string RealFileName
        {
            get
            {
                var path = Path.Combine(SiteInvestigationModule.FileSystemStoreLocation, Type.ToString());
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (!string.IsNullOrEmpty(FileName) && Oid != Guid.Empty)
                    return Path.Combine(SiteInvestigationModule.FileSystemStoreLocation, Type.ToString(), string.Format("{0}-{1}", Oid, FileName));
                return null;
            }
        }
        protected virtual void SaveFileToStore()
        {
            if (!string.IsNullOrEmpty(RealFileName) && TempSourceStream != null)
            {
                try
                {
                    using (Stream destination = File.Create(RealFileName))
                    {
                        SiteInvestigationModule.CopyStream(TempSourceStream, destination);
                        Size = (int)destination.Length;
                    }
                }
                catch (DirectoryNotFoundException exc)
                {
                    throw new UserFriendlyException(exc);
                }
            }
        }
        private void RemoveOldFileFromStore()
        {
            //Dennis: We need to remove the old file from the store when saving the current object.
            if (!string.IsNullOrEmpty(tempFileName) && tempFileName != RealFileName)
            {//B222892
                try
                {
                    File.Delete(tempFileName);
                    tempFileName = string.Empty;
                }
                catch (DirectoryNotFoundException exc)
                {
                    throw new UserFriendlyException(exc);
                }
            }
        }
        protected override void OnSaving()
        {
            base.OnSaving();
            Guard.ArgumentNotNullOrEmpty(SiteInvestigationModule.FileSystemStoreLocation, "FileSystemStoreLocation");
            lock (syncRoot)
            {
                if (!Directory.Exists(SiteInvestigationModule.FileSystemStoreLocation))
                    Directory.CreateDirectory(SiteInvestigationModule.FileSystemStoreLocation);
            }
            SaveFileToStore();
            RemoveOldFileFromStore();
        }
        protected override void OnDeleting()
        {
            //Dennis: We need to remove the old file from the store.
            Clear();
            base.OnDeleting();
        }
        protected override void Invalidate(bool disposing)
        {
            if (disposing && TempSourceStream != null)
            {
                TempSourceStream.Close();
                TempSourceStream = null;
            }
            base.Invalidate(disposing);
        }
        #region IFileData Members
        public void Clear()
        {
            //Dennis: When clearing the file name property we need to save the name of the old file to remove it from the store in the future. You can also setup a separate service for that.
            if (string.IsNullOrEmpty(tempFileName))
                tempFileName = RealFileName;
            FileName = string.Empty;
            Size = 0;
        }
        [Size(260)]
        public string FileName
        {
            get { return GetPropertyValue<string>("FileName"); }
            set { SetPropertyValue("FileName", value); }
        }
        [Browsable(false)]
        public Stream TempSourceStream
        {
            get { return tempSourceStream; }
            set
            {
                //Michael: The original Stream might be closed after a while (on the web too - T160753)
                if (value == null)
                {
                    tempSourceStream = null;
                }
                else
                {
                    if (value.Length > (long)int.MaxValue) throw new UserFriendlyException("File is too long");
                    tempSourceStream = new MemoryStream((int)value.Length);
                    SiteInvestigationModule.CopyStream(value, tempSourceStream);
                    tempSourceStream.Position = 0;
                }
            }
        }
        //Dennis: Fires when uploading a file.
        void IFileData.LoadFromStream(string fileName, Stream source)
        {
            //Dennis: When assigning a new file we need to save the name of the old file to remove it from the store in the future.
            if (fileName != FileName)
            {// updated, old code was: if (string.IsNullOrEmpty(tempFileName))
                tempFileName = RealFileName;
            }
            FileName = fileName;
            TempSourceStream = source;
            Size = (int)TempSourceStream.Length;
            OnChanged();//T582918
        }
        //Dennis: Fires when saving or opening a file.
        void IFileData.SaveToStream(Stream destination)
        {
            try
            {
                if (!string.IsNullOrEmpty(RealFileName))
                {
                    if (destination == null)
                        SiteInvestigationModule.OpenFileWithDefaultProgram(RealFileName);
                    else
                        SiteInvestigationModule.CopyFileToStream(RealFileName, destination);
                }
                else if (TempSourceStream != null)
                    SiteInvestigationModule.CopyStream(TempSourceStream, destination);
            }
            catch (DirectoryNotFoundException exc)
            {
                throw new UserFriendlyException(exc);
            }
            catch (FileNotFoundException exc)
            {
                throw new UserFriendlyException(exc);
            }
        }
        [Persistent]
        public int Size
        {
            get { return GetPropertyValue<int>("Size"); }
            private set { SetPropertyValue<int>("Size", value); }
        }

        public StorageType Type
        {
            get { return GetPropertyValue<StorageType>("Type"); }
            set { SetPropertyValue("Type", value); }
        }
        #endregion
        #region IEmptyCheckable Members
        public bool IsEmpty
        {
            //T153149
            get { return FileDataHelper.IsFileDataEmpty(this) || !(this.TempSourceStream != null || File.Exists(RealFileName)); }
        }
        #endregion
    }

    public enum StorageType
    {
        Video, Document, Image, Files
    }
}
