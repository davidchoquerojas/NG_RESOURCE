using System;
using System.Net.Mail;
using System.Configuration;
using System.Web;
using Metricaencuesta.Models;
using Metricaencuesta.Data;

namespace Metricaencuesta.Utils
{
    public class SendMail
    {
        public void mailTo(String file,resultado r)
        {
            var user = ConfigurationManager.AppSettings.Get("mail").ToString();
            var pass = ConfigurationManager.AppSettings.Get("pass").ToString();
            var to   = ConfigurationManager.AppSettings.Get("mailAdm").ToString();
            var name = ConfigurationManager.AppSettings.Get("nameAdm").ToString();
            try
            {
                var empleado = new EmpleadoDB().listAll(r.id_empleado);
                var evaluador = new EvaluadorDB().listAll(r.id_evaluador);

                var smtpClient = new SmtpClient() {
                    Host = ConfigurationManager.AppSettings.Get("server").ToString(),
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential(user,pass),
                    Port = Convert.ToInt32(ConfigurationManager.AppSettings.Get("port")),
                    EnableSsl = true
                };
                var fromAddress = new MailAddress(to, name);
                var message = new MailMessage()
                {
                    From = fromAddress,
                    Subject = "Encuesta Métrica",
                    IsBodyHtml = false,
                    Body = "Muchas gracias por evaluar al colaborador : " + empleado[0].nombres + " " + empleado[0].apellidos
                };
                message.To.Add(new MailAddress(evaluador[0].email));
                message.CC.Add(new MailAddress(to));
                message.Attachments.Add(new Attachment(@HttpContext.Current.Server.MapPath("~/Utils/pdfs/" + file)));

                smtpClient.Send(message);
            }
            catch (Exception ex)
            {
                new Elmah.Error(ex);
                //throw;
            }
        }
    }
}
