using Gympass.Arquivo;
using Gympass.Modelo;
using System;
using System.Collections.Generic;
using System.IO;

/*
    Olá, meu nome é Leonardo Lopes Silva.
    Tenho 22 anos e sou formado em sistemas de informação.

    Recebi uma mensagem do Caio Chedid - Head Hunter da Gympass e gostaria de compartilhar com vocês
    a solução que criei baseado no problema da corrida de Kart incluindo as funções bônus.

    Meu e-mail é leo_lopes09@hotmail.com
    Meu celular é (11)96383-1321.

    Fico no aguardo do resultado do teste. :)
*/


namespace GeradoDerRelatorio
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(\d{2}:\d{2}:\d{2}\.\d{0,3})\s*(\d{0,3})\s*\–\s*([A-z\.]+)\s*(\d)\s*(\d{0,2}:\d{0,2}\.\d{0,3})\s*(\d+\,\d+)+\s*$";

            Console.WriteLine("---------------------------------------\r");
            Console.WriteLine("-Gerador de resultados da Corrida Kart- \r");
            Console.WriteLine("---------------------------------------\n");

            Console.Write("Por favor, informe o nome do arquivo de log para gerar o resultado e aperte ENTER: ");
            string nomeArquivo = Console.ReadLine();

            Arquivo arquivo = new Arquivo(nomeArquivo, pattern);
            CorridaKart corrida = null;

            try
            {
                corrida = arquivo.LerArquivoDeLog();

                Console.WriteLine("Arquivo de LOG processado com sucesso!!!");

                string opcao = "S";

                while (opcao.ToUpper() == "S")
                {
                    Console.WriteLine();
                    Console.WriteLine("Escolha uma das opções da lista abaixo: ");
                    Console.WriteLine("\t1 - Classificar pilotos da corrida");
                    Console.WriteLine("\t2 - Ver melhor volta de cada piloto");
                    Console.WriteLine("\t3 - Ver a melhor volta da corrida");
                    Console.WriteLine("\t4 - Ver a velocidade média de cada piloto durante a corrida");
                    Console.WriteLine("\t5 - Ver quanto tempo cada piloto chegou após o vencedor");
                    Console.Write("Opção: ");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            var classificacao = corrida.ClassificarOrdemDeChegada();
                            ExibirClassificacao(classificacao);
                            break;

                        case "2":
                            ExibirMelhorVoltaDeCadaPiloto(corrida);
                            break;

                        case "3":
                            ExibirMelhorVoltaDaCorrida(corrida);
                            break;

                        case "4":
                            ExibirVelocidadeMediaDeCadaPiloto(corrida);
                            break;

                        case "5":
                            ExibirTempoDeCadaCorredorAposVencedor(corrida);
                            break;

                        default:
                            Console.WriteLine("Ops! Essa opção não está disponível. Por favor, selecione uma das opções acima.");
                            break;
                    }
                    Console.WriteLine();
                    Console.WriteLine("Deseja realizar mais alguma operação?");
                    Console.Write("Opção (S/N): ");
                    opcao = Console.ReadLine();
                }            
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Pressione qualquer tecla para finalizar a aplicação...");
            Console.ReadLine();
        }

        private static void ExibirTempoDeCadaCorredorAposVencedor(CorridaKart corrida)
        {
            corrida.CalcularDiferencaDeTempoDoVencedor();
        }

        private static void ExibirVelocidadeMediaDeCadaPiloto(CorridaKart corrida)
        {
            foreach (var piloto in corrida.Pilotos)
            {
                Console.WriteLine($"A velocidade média do piloto {piloto.Nome} foi de {piloto.CalcularVelocidadeMedia().ToString("00.00")}");
            }
        }

        private static void ExibirMelhorVoltaDaCorrida(CorridaKart corrida)
        {
            var volta = corrida.ClassificarMelhorVoltaDaCorrida();

            Console.WriteLine($"A melhor volta da corrida foi {volta.TempoDaVolta}");
        }

        private static void ExibirMelhorVoltaDeCadaPiloto(CorridaKart corrida)
        {
            foreach (var piloto in corrida.Pilotos)
            {
                Console.WriteLine($"O piloto {piloto.Nome} se destacou na volta nº {piloto.GetMelhorVolta().NumeroDaVolta} fazendo {piloto.GetMelhorVolta().TempoDaVolta}");
            }
        }

        private static void ExibirClassificacao(List<Piloto> classificacao)
        {
            Console.WriteLine("Classificação \t\tCód. Piloto \t\tNome \t\tQtd. Voltas \t\tTempo Total\r");
            for (int i = 0; i < classificacao.Count; i++)
            {     
                Console.WriteLine($"\t\t{i + 1}  \t\t{classificacao[i].Id} \t\t{classificacao[i].Nome} \t\t{classificacao[i].GetTotalVoltasCompletadas()} \t\t{classificacao[i].CalcularTempoTotalDeProva()}");
            }
        }
    }
}
