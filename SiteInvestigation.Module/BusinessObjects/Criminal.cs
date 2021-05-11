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
    [XafDisplayName("嫌疑人")]
    public class Criminal : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Criminal(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        private string _Name;
        [XafDisplayName("姓名")]
        public string Name
        {
            get { return _Name; }
            set { SetPropertyValue<string>(nameof(Name), ref _Name, value); }
        }


        private string _ID;
        [XafDisplayName("身份证号")]
        public string ID
        {
            get { return _ID; }
            set { SetPropertyValue<string>(nameof(ID), ref _ID, value); }
        }


        private string _Mobile;
        [XafDisplayName("手机")]
        public string Mobile
        {
            get { return _Mobile; }
            set { SetPropertyValue<string>(nameof(Mobile), ref _Mobile, value); }
        }


        private byte[] _Image;
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit
           , DetailViewImageEditorMode = ImageEditorMode.PictureEdit)]

        [XafDisplayName("照片")]
        public byte[] Image
        {
            get { return _Image; }
            set { SetPropertyValue<byte[]>(nameof(Image), ref _Image, value); }
        }


        [Association(FKCollection.CASE_RELATED_CRIMINAL)]
        [XafDisplayName("关联案件")]
        public XPCollection<Case> RelatedCases
        {
            get { return GetCollection<Case>(nameof(RelatedCases)); }
        }



        [Association(FKCollection.CRIMINAL_FINGRE)]
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        public XPCollection<FingerPrint> FingerPrints
        {
            get { return GetCollection<FingerPrint>(nameof(FingerPrints)); }
        }


        [Association(FKCollection.VIDEO_CRIMINAL)]
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        public XPCollection<Video> Videos
        {
            get { return GetCollection<Video>(nameof(Videos)); }
        }


        [Association(FKCollection.DNA_CRIMINAL)]
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        public XPCollection<DNA> DNAs
        {
            get { return GetCollection<DNA>(nameof(DNAs)); }
        }


        [Association(FKCollection.FOOT_CRIMINAL)]
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        public XPCollection<FootPrint> FootPrints
        {
            get { return GetCollection<FootPrint>(nameof(FootPrints)); }
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