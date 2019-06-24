using Gympass.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gympass.Arquivo
{
    public class Arquivo
    {
        public string Nome { get; set; }

        public string PadraoRegex { get; private set; }

        public Arquivo(string nomeDoArquivo, string pattern)
        {
            Nome = nomeDoArquivo;
            PadraoRegex = pattern;
        }

        public CorridaKart LerArquivoDeLog()
        {
            try
            {
                var arquivo = new StreamReader(Nome);
                string linha = null;
                var corrida = new CorridaKart();
                while ((linha = arquivo.ReadLine()) != null)
                {
                    MatchCollection matches = Regex.Matches(linha, PadraoRegex);

                    foreach (Match match in matches)
                    {
                        Piloto piloto = new Piloto();
                        Volta volta = new Volta();

                        //Adicionando informações do piloto.
                        piloto.Id = Convert.ToInt32(match.Groups[2].Value);
                        piloto.Nome = match.Groups[3].Value;

                        //Adicionando informações da volta.
                        volta.HoraVolta = TimeSpan.Parse(match.Groups[1].Value);
                        volta.NumeroDaVolta = Convert.ToInt32(match.Groups[4].Value);
                        volta.TempoDaVolta = TimeSpan.Parse($"00:{match.Groups[5].Value}");
                        volta.VelocidadeMediaDaVolta = Convert.ToDouble(match.Groups[6].Value);

                        var pilotoExiste = corrida.VerificarSeOPilotoExiste(piloto);

                        if (pilotoExiste)
                        {
                            var pilotoEncontrado = corrida.GetPiloto(piloto);
                            pilotoEncontrado.AdicionarVolta(volta);
                            continue;
                        }

                        piloto.AdicionarVolta(volta);
                        corrida.AdicionarPilotoNaCorrida(piloto);
                    }
                }
                return corrida;

            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("O arquivo especificado não está no diretório especificado ou não existe", Nome);
            }

        }
    }
}
