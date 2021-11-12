using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Kakarecos.Util
{
    public class Texto
    {
        public static string RetornaSomenteNumeros(string texto)
        {
            return new Regex(@"[^0-9]").Replace(texto, "");
        }
        public Stream ConvertStringToStream(string txt)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(txt);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}

