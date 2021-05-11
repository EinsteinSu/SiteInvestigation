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
    [XafDisplayName("案件管理")]
    public class Case : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public Case(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        private Police _CreationUser;
        [Association(FKCollection.CASE_CREATION)]
        [XafDisplayName("创建人")]
        public Police CreationUser
        {
            get { return _CreationUser; }
            set { SetPropertyValue<Police>(nameof(CreationUser), ref _CreationUser, value); }
        }


        private CaseNumberType _NumberType;
        [XafDisplayName("案件号类型")]
        public CaseNumberType NumberType
        {
            get { return _NumberType; }
            set { SetPropertyValue<CaseNumberType>(nameof(NumberType), ref _NumberType, value); }
        }



        private string _Number;
        [XafDisplayName("案件编号")]
        public string Number
        {
            get { return _Number; }
            set { SetPropertyValue<string>(nameof(Number), ref _Number, value); }
        }


        private DateTime _StartTime;
        [XafDisplayName("接警时间")]
        public DateTime StartTime
        {
            get { return _StartTime; }
            set { SetPropertyValue<DateTime>(nameof(StartTime), ref _StartTime, value); }
        }


        private string _HappenedAddress;
        [XafDisplayName("案发地址")]
        public string HappenedAddress
        {
            get { return _HappenedAddress; }
            set { SetPropertyValue<string>(nameof(HappenedAddress), ref _HappenedAddress, value); }
        }


        private string _Description;
        [Size(3000)]
        [XafDisplayName("简要案情")]
        public string Description
        {
            get { return _Description; }
            set { SetPropertyValue<string>(nameof(Description), ref _Description, value); }
        }


        private CaseStatus _Status;
        [XafDisplayName("案件状态")]
        public CaseStatus Status
        {
            get { return _Status; }
            set { SetPropertyValue<CaseStatus>(nameof(Status), ref _Status, value); }
        }

        private PoliceStation _PoliceStation;
        [Association(FKCollection.CASE_POLICESTATION)]
        [XafDisplayName("案发单位")]
        public PoliceStation PoliceStation
        {
            get { return _PoliceStation; }
            set { SetPropertyValue<PoliceStation>(nameof(PoliceStation), ref _PoliceStation, value); }
        }

        private Group _Group;
        [Association(FKCollection.CASE_GROUP)]
        //todo: when the group selected clear and insert the polices
        [XafDisplayName("指定勘察组别")]
        public Group Group
        {
            get { return _Group; }
            set { SetPropertyValue<Group>(nameof(Group), ref _Group, value); }
        }


        [Association(FKCollection.CASE_INVERSTITATION_POLICE)]
        [XafDisplayName("勘察人员")]

        public XPCollection<Police> InvestigationPolices
        {
            get { return GetCollection<Police>(nameof(InvestigationPolices)); }
        }


        [Association(FKCollection.CASE_RELATED_CRIMINAL)]
        [XafDisplayName("嫌疑人")]
        public XPCollection<Criminal> Criminals
        {
            get { return GetCollection<Criminal>(nameof(Criminals)); }
        }


        [Association(FKCollection.CASE_FINGREPRINT)]
        [XafDisplayName("指纹提取数")]
        public XPCollection<FingerPrint> FingrePrints
        {
            get { return GetCollection<FingerPrint>(nameof(FingrePrints)); }
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

    public enum CaseNumberType
    {
        案件A号, 案件J号, 案件K号
    }

    public enum CaseStatus
    {
        已受理, 已立案, 已结案
    }
}