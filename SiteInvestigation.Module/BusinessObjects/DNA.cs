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
    [XafDisplayName("DNA提取数")]
    public class DNA : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public DNA(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        private string _Number;
        [XafDisplayName("物证编号")]
        public string Number
        {
            get { return _Number; }
            set { SetPropertyValue<string>(nameof(Number), ref _Number, value); }
        }


        private Police _ExtractPolice;
        [Association(FKCollection.DNA_EXTRACT_POLICE)]
        [XafDisplayName("提取人")]
        public Police ExtractPolice
        {
            get { return _ExtractPolice; }
            set { SetPropertyValue<Police>(nameof(ExtractPolice), ref _ExtractPolice, value); }
        }


        private bool _Stored;
        [XafDisplayName("是否入库")]
        public bool Stored
        {
            get { return _Stored; }
            set { SetPropertyValue<bool>(nameof(Stored), ref _Stored, value); }
        }



        private Criminal _Criminal;
        [Association(FKCollection.DNA_CRIMINAL)]
        [XafDisplayName("嫌疑人")]
        public Criminal Criminal
        {
            get { return _Criminal; }
            set { SetPropertyValue<Criminal>(nameof(Criminal), ref _Criminal, value); }
        }


        private Police _Processor;
        [Association(FKCollection.DNA_PROCESSOR_POLICE)]
        [XafDisplayName("处理人")]
        public Police Processor
        {
            get { return _Processor; }
            set { SetPropertyValue<Police>(nameof(Processor), ref _Processor, value); }
        }


        private Case _Case;
        [Association(FKCollection.CASE_DNA)]
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        public Case Case
        {
            get { return _Case; }
            set { SetPropertyValue<Case>(nameof(Case), ref _Case, value); }
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