using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace SiteInvestigation.Module.Web.Editors
{
    [PropertyEditor(typeof(DateTime), false)]
    public class DateAndTimeEditor: ASPxDateTimePropertyEditor
    {
        public DateAndTimeEditor(Type objectType, IModelMemberViewItem info) :
        base(objectType, info)
        { }
        protected override void SetupControl(WebControl control)
        {
            base.SetupControl(control);
            if (ViewEditMode == ViewEditMode.Edit)
            {
                ASPxDateEdit dateEdit = (ASPxDateEdit)control;
                dateEdit.TimeSectionProperties.Visible = true;
                dateEdit.UseMaskBehavior = true;
            }
        }

    }
}
