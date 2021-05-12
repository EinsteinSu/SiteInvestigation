using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.ExpressApp;
using SiteInvestigation.Module.BusinessObjects;

namespace SiteInvestigation.Module.Helpers
{
    public class MessageHelper
    {
        public static void ShowMessage(XafApplication application, string message,
           InformationType type = InformationType.Success,
           InformationPosition position = InformationPosition.Bottom,
           int duration = 2000)
        {
            if (application == null)
                return;
            MessageOptions options = new MessageOptions();
            options.Duration = duration;
            options.Message = message;
            options.Type = type;
            options.Web.Position = position;
            application.ShowViewStrategy.ShowMessage(options);
        }

        public static void ShowNotification(IObjectSpace objectSpace, string subject, Guid userId)
        {
            var n = objectSpace.CreateObject<SiteNotification>();
            n.Message = subject;
            n.AlarmTime = DateTime.Now;
            n.NotificatedPolice = objectSpace.GetObjectByKey<Police>(userId);
            objectSpace.CommitChanges();
        }
    }
}
