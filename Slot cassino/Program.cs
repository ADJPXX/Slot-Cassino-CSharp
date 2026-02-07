using System;
using System.Threading;

namespace Slot
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();


        }

        static void Menu()
        {
            Jogador jogador1 = new Jogador("Adriel", 0);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("            BEM VINDO AO SLOT");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("[ 1 ]NOVO JOGO");
                Console.WriteLine("[ 0 ]SAIR");
                Console.Write("SUA ESCOLHA: ");
                if (int.TryParse(Console.ReadLine().Trim(), out int opcao))
                {
                    if (opcao == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("OBRIGADO POR USAR O PROGRAMA!");
                        Thread.Sleep(3000);
                        break;
                    }

                    else if (opcao == 1)
                        jogador1.AdicionarDinheiro();

                    else
                    {
                        Console.Clear();
                        Console.WriteLine("OPÇÃO INVÁLIDA");
                        Console.WriteLine("APERTE ENTER PARA ESCOLHER OUTRA OPÇÃO.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("OPÇÃO INVÁLIDA");
                    Console.WriteLine("APERTE ENTER PARA ESCOLHER OUTRA OPÇÃO.");
                    Console.ReadKey();
                }
            }
        }
    }
}