using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Kakarecos.Util
{
    public class Arquivo
    {
        public string Gravar (string dados, string caminho, string nome)
        {
            if (!caminho.EndsWith(@"\"))
                caminho += @"\";

            string caminhoCompleto = caminho + nome;

            if (!File.Exists(caminhoCompleto))
            {
                byte[] dadosBytes = Encoding.UTF8.GetBytes(dados);

                FileStream fs = File.Create(caminhoCompleto, dadosBytes.Length);
                if (fs.CanWrite)
                {
                    fs.Write(dadosBytes, 0, dadosBytes.Length);
                    fs.Close();
                }
            }

            return caminhoCompleto;
        }

        public static void ExcluirArquivo(string caminho)
        {
            if (!caminho.EndsWith(@"\"))
                caminho += @"\";

            if (!File.Exists(caminho))
                File.Delete(caminho);
        }

        
    }
}
