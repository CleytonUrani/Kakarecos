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
        public static bool Enviar(string[] para, string assunto, string mensagem, string[] paraOculto = null, string[] anexos = null)
        {
            try
            {
                ConfiguracaoEmail email = CarregaConfiguracao();

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(email.De, email.NomeApresentacao)
                };

                foreach(string p in para)
                    mail.To.Add(new MailAddress(p));

                foreach (string p in paraOculto)
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
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static ConfiguracaoEmail CarregaConfiguracao()
        {
            return new ConfiguracaoEmail
            {
                Dominio = new Configuracao().ObtemConfiguracao("Dominio"),
                NomeApresentacao = new Configuracao().ObtemConfiguracao("NomeApresentacao"),
                Porta = Convert.ToInt32(new Configuracao().ObtemConfiguracao("Porta")),
                Usuario = new Configuracao().ObtemConfiguracao("Usuario"),
                Senha = new Configuracao().ObtemConfiguracao("Senha"),
                De = new Configuracao().ObtemConfiguracao("De"),
                Para = new string[] { new Configuracao().ObtemConfiguracao("Para") },
                ParaOculto = new string[] { new Configuracao().ObtemConfiguracao("ParaOculto") },
            };
        }

        private class ConfiguracaoEmail
        {
            public string NomeApresentacao { get; set; }
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
