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
    [XafDisplayName("案件串并")]
    public class CaseLinking : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public CaseLinking(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        private string _Name;
        [XafDisplayName("串并名称")]
        public string Name
        {
            get { return _Name; }
            set { SetPropertyValue<string>(nameof(Name), ref _Name, value); }
        }



        private string _Gist;
        [XafDisplayName("串并依据")]
        [Size(1000)]
        public string Gist
        {
            get { return _Gist; }
            set { SetPropertyValue<string>(nameof(Gist), ref _Gist, value); }
        }


        private DateTime _LinkingTime;
        [XafDisplayName("串并时间")]
        public DateTime LinkingTime
        {
            get { return _LinkingTime; }
            set { SetPropertyValue<DateTime>(nameof(LinkingTime), ref _LinkingTime, value); }
        }


        [Association(FKCollection.CASE_LINKING)]
        [XafDisplayName("串并案件")]
        public XPCollection<Case> Cases
        {
            get { return GetCollection<Case>(nameof(Cases)); }
        }


        private Police _Processor;
        [Association(FKCollection.CASELINKING_POLICE)]
        [XafDisplayName("串并人")]
        public Police Processor
        {
            get { return _Processor; }
            set { SetPropertyValue<Police>(nameof(Processor), ref _Processor, value); }
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