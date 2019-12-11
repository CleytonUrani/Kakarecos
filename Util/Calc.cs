using System;
using System.Collections.Generic;
using System.Text;

namespace Kakarecos.Util
{
    public class Calc
    {
        public class FormaPagamento
        {
            /// <summary>
            /// Calcula primeira e proximas parcelas, ajustando dizima periódica
            /// </summary>
            /// <param name="valorTotal"></param>
            /// <param name="numParcelaa"></param>
            /// <returns>Tupla com o primeiro valor sendo a primeira parcela e o segundo sendo as outras parcelas</returns>
            public static Tuple<decimal, decimal> CalculaParcela(decimal valorTotal, int numParcela)
            {
                decimal pParcela = 0M;
                decimal vCalculado = 0M;

                decimal valorParcela = Truncar(valorTotal / numParcela);

                if ((valorParcela * numParcela) != valorTotal)
                {
                    vCalculado = (valorTotal - (valorParcela * numParcela));
                    pParcela = vCalculado > 0 ? valorParcela + vCalculado : valorParcela - vCalculado;
                }

                return new Tuple <decimal, decimal> (
                    pParcela == 0M ? valorParcela : pParcela,
                    valorParcela
                );
            }

            /// <summary>
            /// Trunca valor na segunda casa decimal
            /// </summary>
            /// <param name="valor"></param>
            /// <returns>Valor truncado</returns>
            public static decimal Truncar(decimal valor)
            {
                valor *= 100;
                valor = Math.Truncate(valor);
                valor /= 100;

                return valor;
            }
        }
    }
}
