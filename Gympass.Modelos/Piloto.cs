using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gympass.Modelo
{
    public class Piloto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Volta> Voltas { get; set; }

        public Piloto()
        {
            if (Voltas == null)
            {
                Voltas = new List<Volta>();
            }
        }

        public void AdicionarVolta(Volta volta)
        {
            Voltas.Add(volta);
        }

        public override string ToString()
        {
            return $"ID Piloto: {Id}, Nome: {Nome}";
        }

        public Volta GetMelhorVolta()
        {
            return Voltas.OrderBy(volta => volta.TempoDaVolta).First();
        }

        public double CalcularVelocidadeMedia()
        {
            return Voltas.Average(volta => volta.VelocidadeMediaDaVolta);
        }

        public TimeSpan CalcularTempoTotalDeProva()
        {
            return new TimeSpan(Voltas.Sum(volta => volta.TempoDaVolta.Duration().Ticks));
        }

        public int GetTotalVoltasCompletadas()
        {
            return Voltas.Count;
        }
    }
}
