namespace Slot_cassino;

public static class Program
{
    private static int _valorAposta;

    private static Estado _estado = Estado.Menu;

    private static readonly Random Rnd = new Random();

    private static readonly Slot Bar = new Slot("BAR", 2);
    private static readonly Slot BarBar = new Slot("BAR BAR", 4);
    private static readonly Slot BarBarBar = new Slot("BAR BAR BAR", 6);
    private static readonly Slot Boost = new Slot("BOOST", 10);
    private static readonly Slot TripleSeven = new Slot("777", 50);

    private static readonly List<Slot> OnScreen = [Bar, BarBar, BarBarBar, Boost, TripleSeven];

    private static readonly Jogador Jogador = new Jogador("Adriel", -100000);

    public static void Main(string[] args)
    {
        while (_estado != Estado.Sair)
        {
            switch (_estado)
            {
                case Estado.Menu: Menu(); break;
                case Estado.NovoJogo: NovoJogo(); break;
                case Estado.Apostar: Apostar(); break;
                case Estado.Apostando: Apostando(); break;
            }
        }
    }

    
    private static void Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("            BEM VINDO AO SLOT");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("[ 1 ]NOVO JOGO");
            Console.WriteLine("[ 0 ]SAIR");
            var opcao = LerInt("ESCOLHA SUA OPÇÃO: ");

            if (opcao == 0)
            {
                Console.Clear();
                Console.WriteLine("OBRIGADO POR USAR O PROGRAMA!");
                Thread.Sleep(3000);
                _estado = Estado.Sair;
                return;
            }

            else if (opcao == 1)
            {
                _estado = Estado.NovoJogo;
                return;
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

    private static void NovoJogo()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("DIGITE 0 (ZERO) PARA SAIR.\n");
            var saldo = LerInt("DIGITE O VALOR QUE VOCÊ QUER ADICIONAR NA SUA CARTEIRA: $");
            if (saldo == 0)
            {
                _estado = Estado.Menu;
                return;
            }

            else if (saldo < 0)
            {
                Console.Clear();
                Console.WriteLine("SALDO INVÁLIDO, APERTE ENTER PARA DIGITAR NOVAMENTE.");
                Console.ReadKey();
            }
            else
            {

                Jogador.AdicionarDinheiro(saldo);
                _estado = Estado.Apostar;
                return;
            }
        }
    }

    private static void Apostar()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"VALOR ATUAL DA SUA CARTEIRA: ${Jogador.Saldo}");
            Console.WriteLine("\nDIGITE 0 (ZERO) PARA SAIR\n");
            _valorAposta = LerInt("DIGITE QUANTO VOCÊ QUER APOSTAR: $");

            if (_valorAposta == 0)
            {
                _estado = Estado.NovoJogo;
                return;
            }

            else if (_valorAposta < 0 || _valorAposta > Jogador.Saldo)
            {
                Console.Clear();
                Console.WriteLine("SALDO INVÁLIDO, APERTE ENTER PARA DIGITAR NOVAMENTE.");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                _estado = Estado.Apostando;
                return;
            }
        }
    }

    private static void Apostando()
    {
        while (true)
        {
            Console.WriteLine("APERTE \"S\" PARA SAIR.");
            Console.WriteLine($"VALOR APOSTA ${_valorAposta}");
            Console.WriteLine($"DINHEIRO ATUAL: ${Jogador.Saldo}");
            Console.WriteLine("\nAPERTE ENTER PARA JOGAR!");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.S)
            {
                _estado = Estado.Apostar;
                return;
            }

            Jogador.Bet(_valorAposta);
            AtualizarTela();

            if (Jogador.Saldo == 0)
            {
                Console.WriteLine("SEU DINHEIRO ACABOU! VOLTANDO PARA A TELA DE DEPÓSITO");
                Thread.Sleep(3000);
                _estado = Estado.NovoJogo;
                return;
            }
        }
    }


    private static void AtualizarTela()
    {
        var aleatorio = Rnd.Next(0, OnScreen.Count);
        var aleatorio2 = Rnd.Next(0, OnScreen.Count);
        var aleatorio3 = Rnd.Next(0, OnScreen.Count);

        var sorteio1 = OnScreen[aleatorio];
        var sorteio2 = OnScreen[aleatorio2];
        var sorteio3 = OnScreen[aleatorio3];

        Console.Clear();
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-\n");
        Console.Write($"          {sorteio1.Nome}   ----------  {sorteio2.Nome}  ----------  {sorteio3.Nome}");
        Console.WriteLine("\n\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

        if (sorteio1 == sorteio2 && sorteio2 == sorteio3)
        {
            Recompensa(sorteio1.Multiplicador);
        }
    }

    private static void Recompensa(int multiplicador)
    {
        var ganho = _valorAposta * multiplicador;

        Jogador.AdicionarDinheiro(ganho);

        var dinheiroAntes = Jogador.Saldo - ganho;

        Console.WriteLine($"PARABÉNS! VOCÊ GANHOU UM MULTIPLICADOR DE {multiplicador}x, APOSTANDO ${_valorAposta} DA UM GANHO DE ${ganho}");
        Console.WriteLine($"DINHEIRO ANTES DO GANHO ${dinheiroAntes}");
        Console.WriteLine($"DINHEIRO DEPOIS DO GANHO ${Jogador.Saldo}\n");
    }


    private static int LerInt(string msg)
    {
        while (true)
        {
            Console.Write(msg);
            var input = Console.ReadLine()?.Trim();

            if (int.TryParse(input, out var inteiro))
            {
                return inteiro;
            }
        }
    }
}