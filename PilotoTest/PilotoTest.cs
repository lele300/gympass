using System;
using Gympass.Modelo;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PilotoTest
{
    [TestClass]
    public class PilotoTest
    {
        [TestMethod]
        public void CalcularVelocidadeMedia_DeveRetornarAVelocidadeMediaDuranteACorridaDoPiloto()
        {
            var piloto = new Piloto();

            var volta1 = new Volta();

            volta1.VelocidadeMediaDaVolta = 45.31;

            var volta2 = new Volta();
            volta2.VelocidadeMediaDaVolta = 43.1;

            var volta3 = new Volta();
            volta3.VelocidadeMediaDaVolta = 40;

            var volta4 = new Volta();
            volta4.VelocidadeMediaDaVolta = 44.89;

            piloto.AdicionarVolta(volta1);
            piloto.AdicionarVolta(volta2);
            piloto.AdicionarVolta(volta3);
            piloto.AdicionarVolta(volta4);

            double expected = 43.325;

            double current = piloto.CalcularVelocidadeMedia();

            Assert.AreEqual(expected, current, 0.0001);
        }

        [TestMethod]
        public void CalcularTempoTotalDeProva_DeveRetornarASomatoriaDeTodasAsVoltasDoPiloto()
        {
            var piloto = new Piloto();

            var volta1 = new Volta();

            volta1.TempoDaVolta = TimeSpan.Parse("00:1:02.852");

            var volta2 = new Volta();
            volta2.TempoDaVolta = TimeSpan.Parse("00:1:03.170");

            var volta3 = new Volta();
            volta3.TempoDaVolta = TimeSpan.Parse("00:1:02.769");

            var volta4 = new Volta();
            volta4.TempoDaVolta = TimeSpan.Parse("00:1:02.787");

            piloto.AdicionarVolta(volta1);
            piloto.AdicionarVolta(volta2);
            piloto.AdicionarVolta(volta3);
            piloto.AdicionarVolta(volta4);

            var totalTempo = piloto.CalcularTempoTotalDeProva();

            TimeSpan expected = TimeSpan.Parse("00:04:11.5780000");

            Assert.AreEqual(expected, totalTempo);
        }

        [TestMethod]
        public void GetTotalVoltasCompletadas_DeveRetornarAsVoltasCompletadasDoPiloto()
        {
            var piloto = new Piloto();

            var volta1 = new Volta();

            volta1.TempoDaVolta = TimeSpan.Parse("00:1:02.852");

            var volta2 = new Volta();
            volta2.TempoDaVolta = TimeSpan.Parse("00:1:03.170");

            piloto.AdicionarVolta(volta1);
            piloto.AdicionarVolta(volta2);

            int expected = 2;

            int current = piloto.GetTotalVoltasCompletadas();

            Assert.AreEqual(expected, current);
        }
    }
}
