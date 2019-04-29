using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace WebApiService
{
    public class UnauthorizedAccess
    {
        const string SystemEmail = "donotreply@domain.com";
        const string EmailPassword = "password";
        const int Port = 587;
        const string Host = "smtp.gmail.com";

        public static void WarningEmail(System.Security.Principal.IIdentity UserIdentity, string CurrentRole)
        {
            //AdminDAL.Entities.AdminModel0.ADMINEntities db = new AdminDAL.Entities.AdminModel0.ADMINEntities();
            try
            {

                var identity = (System.Security.Claims.ClaimsIdentity)UserIdentity;
                string UserID = identity.Claims.First(c => c.Type == "UserID").Value;
                string UserName = identity.Claims.First(c => c.Type == "UserName").Value;
                string FullName = identity.Claims.First(c => c.Type == System.Security.Claims.ClaimTypes.Name).Value;
                string MangerEmail = identity.Claims.First(c => c.Type == "MangerEmail").Value;
                if (MangerEmail == null || MangerEmail == "")
                    MangerEmail = SystemEmail;
                // var System_Roles = db.System_Roles_V.Where(a => a.Code_Name == CurrentRole).First();
                //string RoleName = System_Roles.AR_Name;
                //string RoleSystemName = System_Roles.AR_SystemName;
                var subject = "إختراق صلاحيات تطبيقات سجل الاثار: ";// + RoleName;
                var body = "تم محاولة إختراق وتجاوز صلاحيات نظام سجل الاثار من قبل المستخدم " + FullName + Environment.NewLine;
                body += "اسم المستخدم: " + UserName + Environment.NewLine;
                body += "الاسم بالكامل: " + FullName + Environment.NewLine;
                body += "التاريخ: " + DateTime.Now.ToString() + Environment.NewLine;
                //body += "اسم التطبيق: " + RoleSystemName + Environment.NewLine;
               // body += "الصلاحية التي حاول تجاوزها: " + RoleName + Environment.NewLine;
                MailAddress FormMail = new MailAddress(SystemEmail, "نظام سجل الآثار");
                MailAddress ToMail = new MailAddress(MangerEmail);
                MailMessage mm = new MailMessage(FormMail, ToMail);
                //MailAddress CopyTo1 = new MailAddress("haddadd@scth.gov.sa", "Hisham K. Aqrabawi (IT) هشام العقرباوي");
                //mm.CC.Add(CopyTo1);
                //MailAddress CopyTo2 = new MailAddress("Mazrooa@scth.gov.sa", "محمد المزروع");
                //mm.CC.Add(CopyTo2);
                //MailAddress CopyTo3 = new MailAddress("MalkiAM@scth.gov.sa", "Adel Al-Malki (IT) عادل المالكي");
                //mm.CC.Add(CopyTo3);
                //MailAddress CopyTo4 = new MailAddress("nuhas@scth.gov.sa", "Nuha A. Al-Saeed (IT) نهى السعيد");
                //mm.CC.Add(CopyTo4);
                mm.Subject = subject;
                mm.Body = body;
                mm.BodyEncoding = System.Text.UTF8Encoding.UTF8;
                mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                SmtpClient client = new SmtpClient();
                client.Port = Port; client.Host = Host; client.EnableSsl = true; client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential(SystemEmail, EmailPassword);
                client.Send(mm);
             //   db.Dispose();

            }
            catch
            {
             //   db.Dispose();
            }
        }
    }
}