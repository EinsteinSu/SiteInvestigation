using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.BaseImpl.PermissionPolicy;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DisplayNameAttribute = DevExpress.Xpo.DisplayNameAttribute;

namespace SiteInvestigation.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    [XafDisplayName("警员管理")]
    public class Police : PermissionPolicyUser
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Police(Session session)
            : base(session)
        {
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        private string _Number;
        [DisplayName("警号")]
        public string Number
        {
            get { return _Number; }
            set { SetPropertyValue<string>(nameof(Number), ref _Number, value); }
        }

        private string _Name;
        [DisplayName("姓名")]
        public string Name
        {
            get { return _Name; }
            set { SetPropertyValue<string>(nameof(Name), ref _Name, value); }
        }


        private Position _Position;
        [Association(FKCollection.POLICE_POSITION)]
        [DisplayName("职务")]
        public Position Position
        {
            get { return _Position; }
            set { SetPropertyValue<Position>(nameof(Position), ref _Position, value); }
        }


        [Association(FKCollection.GROUP_POLICE)]
        [DisplayName("所属分组")]
        public XPCollection<Group> Group
        {
            get { return GetCollection<Group>(nameof(Group)); }
        }


        private Department _Department;
        [Association(FKCollection.POLICE_DEPARTMENT)]
        [DisplayName("所属部门")]
        public Department Department
        {
            get { return _Department; }
            set { SetPropertyValue<Department>(nameof(Department), ref _Department, value); }
        }


        private PoliceStation _PoliceStation;
        [Association(FKCollection.POLICE_STATION)]
        [DisplayName("所属单位")]
        public PoliceStation PoliceStation
        {
            get { return _PoliceStation; }
            set { SetPropertyValue<PoliceStation>(nameof(PoliceStation), ref _PoliceStation, value); }
        }

        private string _Description;
        [DisplayName("备注")]
        public string Description
        {
            get { return _Description; }
            set { SetPropertyValue<string>(nameof(Description), ref _Description, value); }
        }


        [Association(FKCollection.CASE_CREATION)]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public XPCollection<Case> CreationCases
        {
            get { return GetCollection<Case>(nameof(CreationCases)); }
        }


        [Association(FKCollection.CASE_INVERSTITATION_POLICE)]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public XPCollection<Case> InvestigationUsers
        {
            get { return GetCollection<Case>(nameof(InvestigationUsers)); }
        }


        [Association(FKCollection.FINGRE_EXTRACT_POLICE)]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public XPCollection<FingerPrint> FingerPrintsExtractors
        {
            get { return GetCollection<FingerPrint>(nameof(FingerPrintsExtractors)); }
        }


        [Association(FKCollection.FINGRE_PROCESSOR_POLICE)]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public XPCollection<FingerPrint> FingerPrintsProcessors
        {
            get { return GetCollection<FingerPrint>(nameof(FingerPrintsProcessors)); }
        }



        [Association(FKCollection.VIDEO_EXTRACT_POLICE)]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public XPCollection<Video> VideoExtractors
        {
            get { return GetCollection<Video>(nameof(VideoExtractors)); }
        }


        [Association(FKCollection.VIDEO_PROCESSOR_POLICE)]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public XPCollection<Video> VideoProcessors
        {
            get { return GetCollection<Video>(nameof(VideoProcessors)); }
        }


        [Association(FKCollection.DNA_EXTRACT_POLICE)]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public XPCollection<DNA> DNAExtractors
        {
            get { return GetCollection<DNA>(nameof(DNAExtractors)); }
        }


        [Association(FKCollection.DNA_PROCESSOR_POLICE)]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public XPCollection<DNA> DNAProcessors
        {
            get { return GetCollection<DNA>(nameof(DNAProcessors)); }
        }


        [Association(FKCollection.FOOT_EXTRACT_POLICE)]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public XPCollection<FootPrint> FootPrintExtractors
        {
            get { return GetCollection<FootPrint>(nameof(FootPrintExtractors)); }
        }


        [Association(FKCollection.FOOT_PROCESSOR_POLICE)]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public XPCollection<FootPrint> FootPrintProcessors
        {
            get { return GetCollection<FootPrint>(nameof(FootPrintProcessors)); }
        }


        [Association(FKCollection.NOTIFICATION_POLICE)]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public XPCollection<SiteNotification> Notifications
        {
            get { return GetCollection<SiteNotification>(nameof(Notifications)); }
        }


        [Association(FKCollection.CASELINKING_POLICE)]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public XPCollection<CaseLinking> CaseLinkings
        {
            get { return GetCollection<CaseLinking>(nameof(CaseLinkings)); }
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