using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gympass.Modelo
{
    public class Volta : IComparable
    {
        public int NumeroDaVolta { get; set; }
        public TimeSpan TempoDaVolta { get; set; }
        public TimeSpan HoraVolta { get; set; }
        public double VelocidadeMediaDaVolta { get; set; }

        public int CompareTo(object obj)
        {
            var novaVolta = obj as Volta;

            if (novaVolta.TempoDaVolta > TempoDaVolta)
            {
                return -1;
            }

            if (novaVolta.TempoDaVolta < TempoDaVolta)
            {
                return 1;
            }

            return 0;
        }

        public override string ToString()
        {
            return $"Nº de volta: {NumeroDaVolta}, Tempo da volta: {TempoDaVolta}, Hora da Volta: {HoraVolta}, Velocidade média da volta: {VelocidadeMediaDaVolta}";
        }
    }
}
