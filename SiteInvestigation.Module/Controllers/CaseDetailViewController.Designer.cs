
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
            this.casePropertySelection = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
            this.pictureShowsup = new DevExpress.ExpressApp.Actions.PopupWindowShowAction(this.components);
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
            // casePropertySelection
            // 
            this.casePropertySelection.AcceptButtonCaption = null;
            this.casePropertySelection.CancelButtonCaption = null;
            this.casePropertySelection.Caption = "选择";
            this.casePropertySelection.Category = "CasePropertySelection";
            this.casePropertySelection.ConfirmationMessage = null;
            this.casePropertySelection.Id = "9dfdf3d8-ebab-4a76-aee9-c47cf20f6700";
            this.casePropertySelection.TargetObjectType = typeof(SiteInvestigation.Module.BusinessObjects.Case);
            this.casePropertySelection.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.casePropertySelection.ToolTip = null;
            this.casePropertySelection.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.casePropertySelection.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.casePropertySelection_CustomizePopupWindowParams);
            this.casePropertySelection.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.casePropertySelection_Execute);
            // 
            // pictureShowsup
            // 
            this.pictureShowsup.AcceptButtonCaption = null;
            this.pictureShowsup.CancelButtonCaption = null;
            this.pictureShowsup.Caption = "图片";
            this.pictureShowsup.Category = "Edit";
            this.pictureShowsup.ConfirmationMessage = null;
            this.pictureShowsup.Id = "f462b3e1-bc60-4f21-a0a7-4ed2b18be7d9";
            this.pictureShowsup.TargetObjectType = typeof(SiteInvestigation.Module.BusinessObjects.Case);
            this.pictureShowsup.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.pictureShowsup.ToolTip = null;
            this.pictureShowsup.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.pictureShowsup.CustomizePopupWindowParams += new DevExpress.ExpressApp.Actions.CustomizePopupWindowParamsEventHandler(this.pictureShowsup_CustomizePopupWindowParams);
            this.pictureShowsup.Execute += new DevExpress.ExpressApp.Actions.PopupWindowShowActionExecuteEventHandler(this.pictureShowsup_Execute);
            // 
            // CaseDetailViewController
            // 
            this.Actions.Add(this.groupSelection);
            this.Actions.Add(this.casePropertySelection);
            this.Actions.Add(this.pictureShowsup);
            this.TargetObjectType = typeof(SiteInvestigation.Module.BusinessObjects.Case);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.PopupWindowShowAction groupSelection;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction casePropertySelection;
        private DevExpress.ExpressApp.Actions.PopupWindowShowAction pictureShowsup;
    }
}
