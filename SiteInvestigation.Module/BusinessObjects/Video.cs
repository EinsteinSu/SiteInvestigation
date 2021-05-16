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
    [XafDisplayName("视频提取数")]
    public class Video : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Video(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            Processor = Session.GetObjectByKey<Police>(SecuritySystem.CurrentUserId);
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        private FileData _VideoData;
        [XafDisplayName("视频文件")]
        [FileTypeFilter("视频文件", 1, "*.mp4", "*.mkv", "*.avi", "*.flv", "*.mpeg","*.mov")]
        [FileTypeFilter("所有文件", 2, "*.*")]
        public FileData VideoData
        {
            get { return _VideoData; }
            set { SetPropertyValue<FileData>(nameof(VideoData), ref _VideoData, value); }
        }



        private Police _ExtractPolice;
        [Association(FKCollection.VIDEO_EXTRACT_POLICE)]
        [XafDisplayName("提取人")]
        public Police ExtractPolice
        {
            get { return _ExtractPolice; }
            set { SetPropertyValue<Police>(nameof(ExtractPolice), ref _ExtractPolice, value); }
        }


        [Association(FKCollection.VIDEO_CRIMINAL)]
        [XafDisplayName("嫌疑人")]
        public XPCollection<Criminal> Criminals
        {
            get { return GetCollection<Criminal>(nameof(Criminals)); }
        }


        private Police _Processor;
        [Association(FKCollection.VIDEO_PROCESSOR_POLICE)]
        [XafDisplayName("处理人")]
        public Police Processor
        {
            get { return _Processor; }
            set { SetPropertyValue<Police>(nameof(Processor), ref _Processor, value); }
        }

        private Case _Case;
        [Association(FKCollection.CASE_VIDEO)]
        [XafDisplayName("案件")]
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        public Case Case
        {
            get { return _Case; }
            set { SetPropertyValue<Case>(nameof(Case), ref _Case, value); }
        }


        [Association(FKCollection.VIDEO_SCREENSHOT)]
        [XafDisplayName("视频截图")]
        public XPCollection<VideoScreenshot> Screenshots
        {
            get { return GetCollection<VideoScreenshot>(nameof(Screenshots)); }
        }

    }
}