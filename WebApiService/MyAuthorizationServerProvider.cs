using DAL.Entities.Employees;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace WebApiService
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        //   AdminDAL.Operations.UserAuthorization UserAutho = new AdminDAL.Operations.UserAuthorization();
        private EmployeeDBGIS2019Entities db = new EmployeeDBGIS2019Entities();

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)

        {
            context.Validated(); //
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);

            var Result = db.GetUserByPassWord_Proc(context.UserName, context.Password).ToList();
            if (Result != null && Result.Count > 0)
            {
                var MyUser = Result.First();
                identity.AddClaim(new Claim("UserID", MyUser.EmployeeID.ToString()));
                identity.AddClaim(new Claim("UserName", MyUser.EmailAddress?.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Email, MyUser.EmailAddress == null ? string.Empty : MyUser.EmailAddress));
                identity.AddClaim(new Claim(ClaimTypes.Name, MyUser.EnName == null ? string.Empty : MyUser.EnName));
                identity.AddClaim(new Claim(ClaimTypes.MobilePhone, MyUser.PhoneNumber == null ? string.Empty : MyUser.PhoneNumber));
                identity.AddClaim(new Claim("EnJobTitle", MyUser?.JobTitleTBL?.EnName == null ? string.Empty : MyUser.JobTitleTBL.EnName));
                identity.AddClaim(new Claim("ArJobTitle", MyUser?.JobTitleTBL?.ArName == null ? string.Empty : MyUser.JobTitleTBL.ArName));
                identity.AddClaim(new Claim("ArName", MyUser.ArName == null ? string.Empty : MyUser.ArName));
                identity.AddClaim(new Claim("Group_ID", MyUser.GroupID?.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Role, MyUser.GROUP.EN_Name));
                //var xxx = identity.Claims;
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "اسم المستخدم او كلمة السر خطأ");
                return;
            }
        }
    }
}