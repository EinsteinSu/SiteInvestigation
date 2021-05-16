using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SiteInvestigation.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    [XafDisplayName("视频截图")]
    [XafDefaultProperty("CriminalsDisplay")]
    public class VideoScreenshot : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public VideoScreenshot(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private byte[] _Image;
        [XafDisplayName("图片")]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit
           , DetailViewImageEditorMode = ImageEditorMode.PictureEdit, ListViewImageEditorCustomHeight = 100)]
        public byte[] Image
        {
            get { return _Image; }
            set { SetPropertyValue<byte[]>(nameof(Image), ref _Image, value); }
        }


        private Video _Video;
        [Association(FKCollection.VIDEO_SCREENSHOT)]
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        public Video Video
        {
            get { return _Video; }
            set { SetPropertyValue<Video>(nameof(Video), ref _Video, value); }
        }


        [Association(FKCollection.SCREENSHOT_CRIMINAL)]
        [XafDisplayName("嫌疑人")]
        public XPCollection<Criminal> Criminals
        {
            get { return GetCollection<Criminal>(nameof(Criminals)); }
        }

        [XafDisplayName("嫌疑人")]
        public string CriminalsDisplay
        {
            get
            {
                string names = string.Empty;
                if (Criminals != null)
                {
                    names = string.Join(",", Criminals.Select(s => s.Name));
                }
                return names;
            }
        }
        //private string _PersistentProperty;
        //[XafDisplayName("My display name"), ToolTip("My hint message")]
        //[ModelDefault("EditMask", "(000)-00"), Index(0), VisibleInListView(false)]
        //[Persistent("DatabaseColumnName"), RuleRequiredField(DefaultContexts.Save)]
        //public string PersistentProperty {
        //    get { return _PersistentProperty; }
        //    set { SetPropertyValue(nameof(PersistentProperty), ref _PersistentProperty, value); }
        //}

        //[Action(Caption = "My UI Action", ConfirmationMessage = "Are you sure?", ImageName = "Attention", AutoCommit = true)]
        //public void ActionMethod() {
        //    // Trigger a custom business logic for the current record in the UI (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112619.aspx).
        //    this.PersistentProperty = "Paid";
        //}
    }
}