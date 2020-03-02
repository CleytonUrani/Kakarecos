using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Kakarecos.Util
{
    public class ConsomeWS
    {
        private static CookieContainer cookies = new CookieContainer();

        public static string ConsumirWS(string wsURL, string param, string action, string tipoAplication, VerboHttp verbo, X509Certificate certificado = null)
        {
            try
            {
                HttpWebRequest requisicao = (HttpWebRequest)HttpWebRequest.Create(new Uri(wsURL));
                requisicao.CookieContainer = cookies;
                requisicao.Timeout = 300000;
                requisicao.ContentType = string.Format("application/{0}; charset=utf-8; action={1}", tipoAplication, action);

                if (certificado != null)
                    requisicao.ClientCertificates.Add(certificado);

                switch (verbo)
                {
                    case VerboHttp.POST:
                        {
                            byte[] buffer = Encoding.ASCII.GetBytes(param);
                            requisicao.Method = "POST";
                            requisicao.ContentLength = buffer.Length;
                            Stream PostData = requisicao.GetRequestStream();
                            PostData.Write(buffer, 0, buffer.Length);
                            PostData.Close();
                            break;
                        }
                    case VerboHttp.PUT:
                        requisicao.Method = "PUT";
                        break;
                    case VerboHttp.GET:
                        requisicao.Method = "GET";
                        break;
                    case VerboHttp.DELETE:
                        requisicao.Method = "DELETE";
                        break;
                    default:
                        requisicao.Method = "GET";
                        break;
                }
                
                HttpWebResponse response = (HttpWebResponse)requisicao.GetResponse();
                return new StreamReader(
                                response.GetResponseStream(),
                                System.Text.Encoding.ASCII
                                )
                            .ReadToEnd()
                            .ToString();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public enum VerboHttp
        {
            POST,
            PUT,
            GET,
            DELETE,
        }
    }
}
