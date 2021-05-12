using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Base.General;
using DevExpress.Persistent.BaseImpl;
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
    public class SiteNotification : BaseObject, ISupportNotifications
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        public SiteNotification(Session session)
            : base(session)
        {
        }

        private string _Message;
        [DisplayName("提醒信息")]
        public string Message
        {
            get { return _Message; }
            set { SetPropertyValue<string>(nameof(Message), ref _Message, value); }
        }

        private DateTime? _AlarmTime;
        [DisplayName("提醒时间")]
        public DateTime? AlarmTime
        {
            get { return _AlarmTime; }
            set { SetPropertyValue<DateTime?>(nameof(AlarmTime), ref _AlarmTime, value); }
        }


        private bool _IsPostponed;
        [DisplayName("延迟提醒")]
        public bool IsPostponed
        {
            get { return _IsPostponed; }
            set { SetPropertyValue<bool>(nameof(IsPostponed), ref _IsPostponed, value); }
        }


        public object UniqueId => Oid;

        public string NotificationMessage => Message;


        private Police _NotificatedPolice;
        [Association(FKCollection.NOTIFICATION_POLICE)]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public Police NotificatedPolice
        {
            get { return _NotificatedPolice; }
            set { SetPropertyValue<Police>(nameof(NotificatedPolice), ref _NotificatedPolice, value); }
        }




        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
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