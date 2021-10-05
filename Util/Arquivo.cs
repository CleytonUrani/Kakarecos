using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

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

        public class XML
        {
            public static void GerarXML(ObjXml xml)
            {
                try
                {
                    StringWriterISO8859 sw = new StringWriterISO8859();
                    XmlTextWriter writer = new XmlTextWriter(sw);

                    //inicia o documento xml
                    writer.WriteStartDocument();
                    //escreve o elmento raiz
                    writer.WriteStartElement(xml.NameElement);
                    //attribute
                    foreach (var el in xml.Attribute)
                    {
                        writer.WriteAttributeString(el.key, el.value);
                    }
                    //Escreve os sub-elementos
                    foreach (var el in xml.Elements)
                    {
                        WriteElements(el, ref writer);
                        writer.WriteEndElement();
                    }
                    // encerra o elemento raiz
                    writer.WriteEndElement();
                    //Escreve o XML para o arquivo e fecha o objeto escritor
                    //writer.Close();

                    writer.Flush();
                    //Return text from string writer...

                    Console.WriteLine(sw.ToString());
                    //close the Objects
                    writer.Close();
                    sw.Close();
                }
                catch (Exception ex)
                {
                }
            }

            private static void WriteElements(ElementXml element, ref XmlTextWriter writer)
            {
                if (!string.IsNullOrEmpty(element.value))
                    writer.WriteElementString(element.key, element.value);
                else
                    writer.WriteStartElement(element.key);

                if (element.Elements != null && element.Elements.Any())
                {
                    foreach (var el in element.Elements)
                    {
                        WriteElements(el, ref writer);
                    }
                }
            }
            private class StringWriterISO8859 : StringWriter
            {
                public override Encoding Encoding
                {
                    get { return System.Text.Encoding.GetEncoding("iso-8859-1"); }
                }
            }
            
            public class ObjXml
            {
                public string NameElement { get; set; }
                public ElementXml[] Attribute { get; set; }
                public ElementXml[] Elements { get; set; }
            }
            public class ElementXml
            {
                public string key { get; set; }
                public string value { get; set; }

                public ElementXml[] Elements { get; set; }
            }
        }
    }
}
