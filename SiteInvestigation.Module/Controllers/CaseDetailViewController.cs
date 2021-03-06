using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using SiteInvestigation.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SiteInvestigation.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CaseDetailViewController : ViewController
    {
        public CaseDetailViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            var c = View.CurrentObject as Case;
            if (c != null)
            {
                pictureShowsup.Caption = $"图片({c.Images?.Count})张";
            }

            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        #region group selection
        IObjectSpace objectSpace;
        private void groupSelection_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            objectSpace = Application.CreateObjectSpace(typeof(BusinessObjects.Group));
            var viewId = Application.FindLookupListViewId(typeof(BusinessObjects.Group));
            CollectionSourceBase source = Application.CreateCollectionSource(objectSpace, typeof(BusinessObjects.Group), viewId);
            e.View = Application.CreateListView(viewId, source, true);
        }

        private void groupSelection_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            var c = View.CurrentObject as Case;
            if (c != null && e.PopupWindowViewSelectedObjects.Count > 0)
            {
                var list = new List<Police>();
                foreach (var item in c.InvestigationPolices)
                {
                    list.Add(item);
                }
                foreach (var item in list)
                {
                    c.InvestigationPolices.Remove(item);
                }
                c.Group = View.ObjectSpace.GetObjectByKey<Group>((e.PopupWindowViewSelectedObjects[0] as Group).Oid);
                foreach (var item in c.Group.Polices)
                {
                    c.InvestigationPolices.Add(View.ObjectSpace.GetObjectByKey<Police>(item.Oid));
                }
                View.ObjectSpace.CommitChanges();
            }
        }
        #endregion

        #region case property selection
        private void casePropertySelection_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            objectSpace = Application.CreateObjectSpace(typeof(BusinessObjects.CaseProperty));
            var viewId = Application.FindLookupListViewId(typeof(BusinessObjects.CaseProperty));
            CollectionSourceBase source = Application.CreateCollectionSource(objectSpace, typeof(BusinessObjects.CaseProperty), viewId);
            e.View = Application.CreateListView(viewId, source, true);
        }

        private void casePropertySelection_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {
            var c = View.CurrentObject as Case;
            if (c != null && e.PopupWindowViewSelectedObjects.Count > 0)
            {
                var item = e.PopupWindowViewSelectedObjects[0] as HCategory;
                if (item != null)
                {
                    c.CaseProperty = item.Name;
                    //View.ObjectSpace.CommitChanges();
                    //View.RefreshDataSource();
                    //View.Refresh();
                }
            }
        }
        #endregion

        private void pictureShowsup_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            objectSpace = Application.CreateObjectSpace(typeof(BusinessObjects.CaseImage));
            var viewId = Application.FindLookupListViewId(typeof(BusinessObjects.CaseImage));
            CollectionSourceBase source = Application.CreateCollectionSource(objectSpace, typeof(BusinessObjects.CaseImage), viewId);
            e.View = Application.CreateListView(viewId, source, true);
        }

        private void pictureShowsup_Execute(object sender, PopupWindowShowActionExecuteEventArgs e)
        {

        }
    }
}
