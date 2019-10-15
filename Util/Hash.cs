using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Kakarecos.Util
{
    public class Hash
    {
        public string GerarMd5(string chave)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(chave));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString(); 
            }
        }
    }
}
