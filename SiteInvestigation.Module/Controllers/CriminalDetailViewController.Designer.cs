
namespace SiteInvestigation.Module.Controllers
{
    partial class CriminalDetailViewController
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
            this.getCriminalInfo = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // getCriminalInfo
            // 
            this.getCriminalInfo.Caption = "获取信息";
            this.getCriminalInfo.Category = "GetCriminalInfo";
            this.getCriminalInfo.ConfirmationMessage = null;
            this.getCriminalInfo.Id = "9138e0d6-5c7c-48d6-9573-e2223630ed3f";
            this.getCriminalInfo.TargetObjectType = typeof(SiteInvestigation.Module.BusinessObjects.Criminal);
            this.getCriminalInfo.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.getCriminalInfo.ToolTip = null;
            this.getCriminalInfo.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.getCriminalInfo.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.getCriminalInfo_Execute);
            // 
            // CriminalDetailViewController
            // 
            this.Actions.Add(this.getCriminalInfo);
            this.TargetObjectType = typeof(SiteInvestigation.Module.BusinessObjects.Criminal);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction getCriminalInfo;
    }
}
