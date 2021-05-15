
namespace SiteInvestigation.Module.Controllers
{
    partial class CaseDetailViewController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupSelection = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            // 
            // groupSelection
            // 
            this.groupSelection.AcceptButtonCaption = null;
            this.groupSelection.CancelButtonCaption = null;
            this.groupSelection.Caption = "选择勘察组";
            this.groupSelection.Category = "CaseGroupSelection";
            this.groupSelection.ConfirmationMessage = null;
            this.groupSelection.Id = "869a947f-63fa-472c-a4c2-cfe1d3ebaebb";
            this.groupSelection.TargetObjectType = typeof(SiteInvestigation.Module.BusinessObjects.Case);
            this.groupSelection.TargetViewId = "Case_DetailView_Initial";
            this.groupSelection.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.groupSelection.ToolTip = null;
            this.groupSelection.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.groupSelection.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.groupSelection_CustomizePopupWindowParams);
            this.groupSelection.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.groupSelection_Execute);
            // 
            // CaseDetailViewController
            // 
            this.Actions.Add(this.groupSelection);
            this.TargetObjectType = typeof(SiteInvestigation.Module.BusinessObjects.Case);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction groupSelection;
    }
}
