
namespace SiteInvestigation.Module.Win.Controllers
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
            this.createDNA = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // createDNA
            // 
            this.createDNA.Caption = "新建DNA取证";
            this.createDNA.Category = "Edit";
            this.createDNA.ConfirmationMessage = null;
            this.createDNA.Id = "9bff900a-cf17-4132-a933-e5a0e915e827";
            this.createDNA.TargetObjectType = typeof(SiteInvestigation.Module.BusinessObjects.DNA);
            this.createDNA.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.createDNA.ToolTip = null;
            this.createDNA.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.createDNA.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.createDNA_Execute);
            // 
            // CaseDetailViewController
            // 
            this.Actions.Add(this.createDNA);
            this.TargetObjectType = typeof(SiteInvestigation.Module.BusinessObjects.DNA);
            this.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction createDNA;
    }
}
