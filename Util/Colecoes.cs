using System;

namespace Kakarecos.Util
{
    public class Colecoes
    {
        public static T[] AdicionaItemNoArray<T>(T[] old, params T[] valores)
        {
            T[] a = new T[old.Length + valores.Length];
            int i = 0;

            foreach (T num in old)
                a.SetValue(num, i++);

            foreach (T v in valores)
                a.SetValue(v, i++);

            return a;
        }
        
        public static T[] RemoverItemNoArray<T>(T[] old, T elemento)
        {
            if (elemento == null)
                return old;

            T[] a = new T[old.Length - 1];
            int i = 0;

            if (old.Length == 1)
                return null;

            bool removeuItem = false;
            foreach (T num in old)
            {
                if (!removeuItem && (i == Array.IndexOf(old, elemento)))
                {
                    removeuItem = true;
                    continue;
                }
                a.SetValue(num, i++);
            }

            return a;
        }
    }
}
