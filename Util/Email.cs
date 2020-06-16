using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Linq;
using System.Net;

namespace Kakarecos.Util
{
    public class Email
    {
        public void Enviar(string[] para, string assunto, string mensagem, string[] anexos = null)
        {
            try
            {
                ConfiguracaoEmail email = CarregaConfiguracao();

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(email.De, "Jose Carlos Macoratti")
                };

                foreach(string p in para)
                    mail.To.Add(new MailAddress(p));

                foreach (string p in para)
                    mail.CC.Add(new MailAddress(p));

                mail.Subject = assunto;
                mail.Body = mensagem;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;

                if (anexos != null)
                {
                    foreach (string anexo in anexos)
                        mail.Attachments.Add(new Attachment(anexo));
                }

                using (SmtpClient smtp = new SmtpClient(email.Dominio, email.Porta))
                {
                    smtp.Credentials = new NetworkCredential(email.Usuario, email.Senha);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private ConfiguracaoEmail CarregaConfiguracao()
        {
            return Converter.JsonPara<ConfiguracaoEmail>(new Configuracao().ObtemConfiguracao("ConfigEmail"));
        }

        private class ConfiguracaoEmail
        {
            public string Dominio { get; set; }
            public int Porta { get; set; }
            public string Usuario { get; set; }
            public string Senha { get; set; }
            public string De { get; set; }
            public string[] Para { get; set; }
            public string[] ParaOculto { get; set; }
        }
    }
}
