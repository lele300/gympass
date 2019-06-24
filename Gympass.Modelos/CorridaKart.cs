using System;
using System.Collections.Generic;
using System.Linq;

namespace Gympass.Modelo
{
    public class CorridaKart
    {
        public List<Piloto> Pilotos { get; set; }

        public CorridaKart()
        {
            if (Pilotos == null)
            {
                Pilotos = new List<Piloto>();
            }
        }

        public void AdicionarPilotoNaCorrida(Piloto piloto)
        {
            Pilotos.Add(piloto);
        }

        public bool VerificarSeOPilotoExiste(Piloto piloto)
        {
            return Pilotos.Any(pilotoNaLista => pilotoNaLista.Id == piloto.Id);
        }

        public Piloto GetPiloto(Piloto piloto)
        {
            return Pilotos.First(pilotoNaLista => pilotoNaLista.Id == piloto.Id);
        }

        public List<Piloto> ClassificarOrdemDeChegada()
        {
            return Pilotos.OrderByDescending(piloto => piloto.Voltas.Count)
                .ThenBy(piloto => piloto.Voltas.Sum(volta => volta.TempoDaVolta.Duration().Ticks))
                .ToList();
        }

        public Volta ClassificarMelhorVoltaDaCorrida()
        {
            return Pilotos.Min(piloto => piloto.GetMelhorVolta());
        }

        public void CalcularDiferencaDeTempoDoVencedor()
        {
            var classificacaoOrdemDeChegada = ClassificarOrdemDeChegada();
            var pilotoVencedor = classificacaoOrdemDeChegada.First();

            //Remover o vencedor da lista
            classificacaoOrdemDeChegada.RemoveAt(0);

            foreach (var piloto in classificacaoOrdemDeChegada)
            {
                Console.WriteLine($"A diferença de tempo entre o piloto vencedor ({pilotoVencedor.Nome}) e o {piloto.Nome} é {new TimeSpan(piloto.CalcularTempoTotalDeProva().Ticks - pilotoVencedor.CalcularTempoTotalDeProva().Ticks)}");
            }
        }

    }
}
