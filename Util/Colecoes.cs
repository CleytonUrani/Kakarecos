namespace Kakarecos.Util
{
    public class Colecoes
    {
        public static int[] AdicionaValorArray(int[] old, int aumento, params int[] valores)
        {
            int[] a = new int[old.Length + aumento];
            int i = 0;

            foreach (int num in old)
                a.SetValue(num, i++);

            foreach (int v in valores)
                a.SetValue(v, i++);

            return a;
        }
    }
}
