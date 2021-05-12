using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;

namespace SiteInvestigation.Module
{
    public class MyAuthenticationStandard : AuthenticationStandard
    {
        public override bool AskLogonParametersViaUI
        {
            get
            {
#if DEBUG
                return false;
#else
        return true;
#endif
            }
        }
        public override object Authenticate(IObjectSpace objectSpace)
        {
#if DEBUG
            return objectSpace.FindObject(UserType, CriteriaOperator.Parse("UserName = ?", "PolliceAdmin"));
#else
        return base.Authenticate(objectSpace);
#endif
        }
    }
}
