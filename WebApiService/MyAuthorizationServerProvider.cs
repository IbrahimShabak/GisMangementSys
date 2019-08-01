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

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)

        {
            context.Validated(); //
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            if (context.UserName == "admin" && context.Password == "123")
            {
                identity.AddClaim(new Claim("UserID", context.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                var xxx = identity.Claims;
                context.Validated(identity);
            }
            //if (UserAutho.login(context.UserName, context.Password))
            //{
            //    try
            //    {
            //        var MyuserInfo = UserAutho.MyUserData;
            //        identity.AddClaim(new Claim("UserID", MyuserInfo.MyUser.ID.ToString()));
            //        identity.AddClaim(new Claim("UserName", MyuserInfo.MyUser.UserName?.ToString()));

            //        identity.AddClaim(new Claim(ClaimTypes.Email, MyuserInfo.MyUser.Email == null ? string.Empty : MyuserInfo.MyUser.Email));
            //        identity.AddClaim(new Claim(ClaimTypes.Name, MyuserInfo.MyUser.Full_Name == null ? string.Empty : MyuserInfo.MyUser.Full_Name));
            //        identity.AddClaim(new Claim("Group_ID", MyuserInfo.MyUser.Group_ID?.ToString()));
            //        if (MyuserInfo.MyManger != null)
            //        {
            //            identity.AddClaim(new Claim("MangerID", MyuserInfo.MyManger?.ID.ToString()));
            //            identity.AddClaim(new Claim("MangerEmail", MyuserInfo.MyManger.Email == null ? string.Empty : MyuserInfo.MyManger.Email));
            //        }

            //        foreach (var item in MyuserInfo.MyPermissions)
            //        {
            //            identity.AddClaim(new Claim(ClaimTypes.Role, item.Code_Name));
            //        }

            //        var xxx = identity.Claims;
            //        context.Validated(identity);
            //    }
            //    catch (Exception e)
            //    {
            //        context.SetError("invalid_grant", e.Message);
            //        return;
            //    }

            //}
            else
            {
                context.SetError("invalid_grant", "اسم المستخدم او كلمة السر خطأ");
                return;
            }
        }
    }
}