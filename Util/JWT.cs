using Jose;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Kakarecos.Util
{
    public class JWT<T>
    {
        private static readonly string ChaveToken = new Configuracao().ObtemConfiguracao("TOKENJWT");

        public bool EhValido { get; set; }
        public T Dados { get; set; }

        public static string GeraToken(T obj)
        {
            try
            {
                byte[] arByte = System.Text.Encoding.ASCII.GetBytes(ChaveToken);
                return Jose.JWT.Encode(obj, arByte, JwsAlgorithm.HS256);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static JWT<T> ObtemDados(string token)
        {
            JWT<T> jwt = new JWT<T>();
            try
            {
                byte[] arByte = System.Text.Encoding.ASCII.GetBytes(ChaveToken);

                jwt.EhValido = true;
                jwt.Dados = Converter.JsonPara<T>(Jose.JWT.Decode(token, arByte, JwsAlgorithm.HS256));
                return jwt;
            }
            catch (Exception)
            {
                jwt.EhValido = false;
                return jwt;
            }
        }
    }
}
