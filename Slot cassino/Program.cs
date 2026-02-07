using System;
using System.Threading;

namespace Slot;

class Program
{
    static void Main(string[] args)
    {
        Menu();
    }

    static void Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("            BEM VINDO AO SLOT");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("[ 1 ]NOVO JOGO");
            Console.WriteLine("[ 0 ]SAIR");
            int opcao = LerInt("ESCOLHA SUA OPÇÃO: ");

            if (opcao == 0)
            {
                Console.Clear();
                Console.WriteLine("OBRIGADO POR USAR O PROGRAMA!");
                Thread.Sleep(3000);
                break;
            }

            else if (opcao == 1)
            {
                NovoJogo();
                break;
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

    static void NovoJogo()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("DIGITE 0 (ZERO) PARA SAIR.\n");
            int saldo = LerInt("DIGITE O VALOR QUE VOCÊ QUER ADICIONAR NA SUA CARTEIRA: $");
            if (saldo == 0)
            {
                break;
            }

            else if (saldo < 0)
            {
                Console.Clear();
                Console.WriteLine("SALDO INVÁLIDO, APERTE ENTER PARA DIGITAR NOVAMENTE.");
                Console.ReadKey();
            }
            else
            {
                Jogador jogador = new Jogador("Adriel", 0);
                jogador.AdicionarDinheiro(saldo);
                Apostar(saldo, jogador);
            }
        }
        Menu();
    }

    static void Apostar(int saldo, Jogador jogador)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"VALOR ATUAL DA SUA CARTEIRA: ${jogador.Saldo}");
            Console.WriteLine("\nDIGITE 0 (ZERO) PARA SAIR\n");
            int valorAposta = LerInt("DIGITE QUANTO VOCÊ QUER APOSTAR: $");

            if (valorAposta == 0)
            {
                break;
            }

            else if (valorAposta < 0 || valorAposta > jogador.Saldo)
            {
                Console.Clear();
                Console.WriteLine("SALDO INVÁLIDO, APERTE ENTER PARA DIGITAR NOVAMENTE.");
                Console.ReadKey();
            }
            else
            {
                jogador.Bet(valorAposta);
                Console.Clear();
                AtualizarTela(valorAposta, jogador);
                Console.WriteLine($"VOCÊ APOSTOU ${valorAposta}");
                Console.WriteLine($"DINHEIRO ATUAL: {jogador.Saldo}");
                Console.ReadKey();
            }
        }
        NovoJogo();
    }

    static void AtualizarTela(int valorAposta, Jogador jogador)
    {
        Random rnd = new Random();

        Slot bar = new Slot("BAR", 2);
        Slot barBar = new Slot("BAR BAR", 4);
        Slot barBarBar = new Slot("BAR BAR BAR", 6);
        Slot boost = new Slot("BOOST", 10);
        Slot tripleSeven = new Slot("777", 50);

        List<string> onScreen = [bar.Nome, barBar.Nome, barBarBar.Nome, boost.Nome, tripleSeven.Nome];

        int aleatorio = rnd.Next(0, onScreen.Count);
        int aleatorio2 = rnd.Next(0, onScreen.Count);
        int aleatorio3 = rnd.Next(0, onScreen.Count);

        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-\n");
        Console.Write($"{onScreen[aleatorio]}   ----------  {onScreen[aleatorio2]}  ----------  {onScreen[aleatorio3]}");
        Console.WriteLine("\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

        if (onScreen[aleatorio] == onScreen[aleatorio2] && onScreen[aleatorio2] == onScreen[aleatorio3])
        {
            if (onScreen[aleatorio] == bar.Nome)
            {
                int ganho = valorAposta * bar.Multiplicador;

                jogador.AdicionarDinheiro(ganho);

                int dinheiroAntes = jogador.Saldo - ganho;

                Console.WriteLine($"PARABÉNS! VOCÊ GANHOU UM MULTIPLICADOR DE {bar.Multiplicador}x, APOSTANDO ${valorAposta} DA UM GANHO DE ${ganho}");
                Console.WriteLine($"DINHEIRO ANTES DO GANHO ${dinheiroAntes}");
                Console.WriteLine($"DINHEIRO ANTES DO GANHO ${jogador.Saldo}");
            }
            else if (onScreen[aleatorio] == barBar.Nome)
            {
                int ganho = valorAposta * barBar.Multiplicador;

                jogador.AdicionarDinheiro(ganho);

                int dinheiroAntes = jogador.Saldo - ganho;

                Console.WriteLine($"PARABÉNS! VOCÊ GANHOU UM MULTIPLICADOR DE {barBar.Multiplicador}x, APOSTANDO ${valorAposta} DA UM GANHO DE ${ganho}");
                Console.WriteLine($"DINHEIRO ANTES DO GANHO ${dinheiroAntes}");
                Console.WriteLine($"DINHEIRO ANTES DO GANHO ${jogador.Saldo}");
            }
            else if (onScreen[aleatorio] == barBarBar.Nome)
            {
                int ganho = valorAposta * barBarBar.Multiplicador;

                jogador.AdicionarDinheiro(ganho);

                int dinheiroAntes = jogador.Saldo - ganho;

                Console.WriteLine($"PARABÉNS! VOCÊ GANHOU UM MULTIPLICADOR DE {barBarBar.Multiplicador}x, APOSTANDO ${valorAposta} DA UM GANHO DE ${ganho}");
                Console.WriteLine($"DINHEIRO ANTES DO GANHO ${dinheiroAntes}");
                Console.WriteLine($"DINHEIRO ANTES DO GANHO ${jogador.Saldo}");
            }
            else if (onScreen[aleatorio] == boost.Nome)
            {
                int ganho = valorAposta * boost.Multiplicador;

                jogador.AdicionarDinheiro(ganho);

                int dinheiroAntes = jogador.Saldo - ganho;

                Console.WriteLine($"PARABÉNS! VOCÊ GANHOU UM MULTIPLICADOR DE {boost.Multiplicador}x, APOSTANDO ${valorAposta} DA UM GANHO DE ${ganho}");
                Console.WriteLine($"DINHEIRO ANTES DO GANHO ${dinheiroAntes}");
                Console.WriteLine($"DINHEIRO ANTES DO GANHO ${jogador.Saldo}");
            }
            else if (onScreen[aleatorio] == tripleSeven.Nome)
            {
                int ganho = valorAposta * tripleSeven.Multiplicador;

                jogador.AdicionarDinheiro(ganho);

                int dinheiroAntes = jogador.Saldo - ganho;

                Console.WriteLine($"PARABÉNS! VOCÊ GANHOU UM MULTIPLICADOR DE {tripleSeven.Multiplicador}x, APOSTANDO ${valorAposta} DA UM GANHO DE ${ganho}");
                Console.WriteLine($"DINHEIRO ANTES DO GANHO ${dinheiroAntes}");
                Console.WriteLine($"DINHEIRO ANTES DO GANHO ${jogador.Saldo}");
            }
        }
    }


    static int LerInt(string msg)
    {
        while (true)
        {
            Console.Write(msg);
            string input = Console.ReadLine().Trim();

            if (int.TryParse(input, out int inteiro))
            {
                return inteiro;
            }
        }
    }
}