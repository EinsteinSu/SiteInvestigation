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

            CreationUser = Session.GetObjectByKey<Police>(SecuritySystem.CurrentUserId);
            StartTime = DateTime.Now;
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


        private string _ANumber;
        [XafDisplayName("案件A号")]
        public string ANumber
        {
            get { return _ANumber; }
            set { SetPropertyValue<string>(nameof(ANumber), ref _ANumber, value); }
        }


        private string _JNumber;
        [XafDisplayName("案件J号")]
        public string JNumber
        {
            get { return _JNumber; }
            set { SetPropertyValue<string>(nameof(JNumber), ref _JNumber, value); }
        }


        private string _KNumber;
        [XafDisplayName("案件K号")]
        public string KNumber
        {
            get { return _KNumber; }
            set { SetPropertyValue<string>(nameof(KNumber), ref _KNumber, value); }
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


        [Association(FKCollection.CASE_VIDEO)]
        [XafDisplayName("视频提取数")]
        public XPCollection<Video> Videos
        {
            get { return GetCollection<Video>(nameof(Videos)); }
        }


        [Association(FKCollection.CASE_DNA)]
        [XafDisplayName("DNA提取数")]
        public XPCollection<DNA> DNAs
        {
            get { return GetCollection<DNA>(nameof(DNAs)); }
        }


        [Association(FKCollection.CASE_FOOT)]
        [XafDisplayName("足迹提取数")]
        public XPCollection<FootPrint> FootPrints
        {
            get { return GetCollection<FootPrint>(nameof(FootPrints)); }
        }

        [Association(FKCollection.CASE_INBREAKTIME)]
        [XafDisplayName("入侵时段")]
        public XPCollection<InBreakTime> InBreakTimes
        {
            get { return GetCollection<InBreakTime>(nameof(InBreakTimes)); }
        }


        [Association(FKCollection.CASE_INBREAKPLACE)]
        [XafDisplayName("入侵场所")]
        public XPCollection<InBreakPlace> InBreakPlaces
        {
            get { return GetCollection<InBreakPlace>(nameof(InBreakPlaces)); }
        }


        [Association(FKCollection.CASE_INBREAKMETHOD)]
        [XafDisplayName("入侵方式")]
        public XPCollection<InBreakMethod> InBreakMethods
        {
            get { return GetCollection<InBreakMethod>(nameof(InBreakMethods)); }
        }


        [Association(FKCollection.CASE_INBREAKHABIT)]
        [XafDisplayName("行为习惯")]
        public XPCollection<InBreakHabit> InBreakHabits
        {
            get { return GetCollection<InBreakHabit>(nameof(InBreakHabits)); }
        }

        [Association(FKCollection.CASE_FINANCIALTYPE)]
        [XafDisplayName("损失财务类型")]
        public XPCollection<FinancialType> FinancialTypes
        {
            get { return GetCollection<FinancialType>(nameof(FinancialTypes)); }
        }


        private int _NumberOfCriminal;
        [XafDisplayName("作案人员数")]
        public int NumberOfCriminal
        {
            get { return _NumberOfCriminal; }
            set { SetPropertyValue<int>(nameof(NumberOfCriminal), ref _NumberOfCriminal, value); }
        }



        private string _AnalysisDescription;
        [XafDisplayName("研判备注")]
        [Size(3000)]
        public string AnalysisDescription
        {
            get { return _AnalysisDescription; }
            set { SetPropertyValue<string>(nameof(AnalysisDescription), ref _AnalysisDescription, value); }
        }


        [Association(FKCollection.CASE_LINKING)]
        [XafDisplayName("串并联案件")]
        public XPCollection<CaseLinking> Linkings
        {
            get { return GetCollection<CaseLinking>(nameof(Linkings)); }
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

    public enum CaseStatus
    {
        已受理, 已立案, 已结案
    }
}