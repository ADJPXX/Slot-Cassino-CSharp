using System;
using System.Threading;

namespace Slot_cassino;

class Program
{
    static int _valorAposta;

    enum Estado
    {
        AtualizarTela,
        Menu,
        NovoJogo,
        Apostar,
        Apostando,
        Sair
    }

    static Estado _estado = Estado.Menu;

    static Random _rnd = new Random();

    static Slot _bar = new Slot("BAR", 2);
    static Slot _barBar = new Slot("BAR BAR", 4);
    static Slot _barBarBar = new Slot("BAR BAR BAR", 6);
    static Slot _boost = new Slot("BOOST", 10);
    static Slot _tripleSeven = new Slot("777", 50);

    static List<string> _onScreen = [_bar.Nome, _barBar.Nome, _barBarBar.Nome, _boost.Nome, _tripleSeven.Nome];

    static Jogador _jogador = new Jogador("Adriel", 0);

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

    public static void Menu()
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

    public static void NovoJogo()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("DIGITE 0 (ZERO) PARA SAIR.\n");
            int saldo = LerInt("DIGITE O VALOR QUE VOCÊ QUER ADICIONAR NA SUA CARTEIRA: $");
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

                _jogador.AdicionarDinheiro(saldo);
                _estado = Estado.Apostar;
                return;
            }
        }
    }

    public static void Apostar()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"VALOR ATUAL DA SUA CARTEIRA: ${_jogador.Saldo}");
            Console.WriteLine("\nDIGITE 0 (ZERO) PARA SAIR\n");
            _valorAposta = LerInt("DIGITE QUANTO VOCÊ QUER APOSTAR: $");

            if (_valorAposta == 0)
            {
                _estado = Estado.NovoJogo;
                return;
            }

            else if (_valorAposta < 0 || _valorAposta > _jogador.Saldo)
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

    public static void Apostando()
    {
        while (true)
        {
            Console.WriteLine("APERTE 'S' PARA SAIR.");
            Console.WriteLine($"VALOR APOSTA ${_valorAposta}");
            Console.WriteLine($"DINHEIRO ATUAL: ${_jogador.Saldo}");
            Console.WriteLine("\nAPERTE ENTER PARA JOGAR!");
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key == ConsoleKey.S)
            {
                _estado = Estado.Apostar;
                return;
            }

            _jogador.Bet(_valorAposta);
            AtualizarTela();

            if (_jogador.Saldo == 0)
            {
                Console.WriteLine("SEU DINHEIRO ACABOU! VOLTANDO PARA A TELA DE DEPÓSITO");
                Thread.Sleep(3000);
                _estado = Estado.NovoJogo;
                return;
            }
        }
    }


    public static void AtualizarTela()
    {
        int aleatorio = _rnd.Next(0, _onScreen.Count);
        int aleatorio2 = _rnd.Next(0, _onScreen.Count);
        int aleatorio3 = _rnd.Next(0, _onScreen.Count);

        Console.Clear();
        Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-\n");
        Console.Write($"          {_onScreen[aleatorio]}   ----------  {_onScreen[aleatorio2]}  ----------  {_onScreen[aleatorio3]}");
        Console.WriteLine("\n\n=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

        if (_onScreen[aleatorio] == _onScreen[aleatorio2] && _onScreen[aleatorio2] == _onScreen[aleatorio3])
        {
            if (_onScreen[aleatorio] == _bar.Nome)
            {
                Recompensa(_bar.Multiplicador);
            }
            else if (_onScreen[aleatorio] == _barBar.Nome)
            {
                Recompensa(_barBar.Multiplicador);
            }
            else if (_onScreen[aleatorio] == _barBarBar.Nome)
            {
                Recompensa(_barBarBar.Multiplicador);
            }
            else if (_onScreen[aleatorio] == _boost.Nome)
            {
                Recompensa(_boost.Multiplicador);
            }
            else if (_onScreen[aleatorio] == _tripleSeven.Nome)
            {
                Recompensa(_tripleSeven.Multiplicador);
            }
        }
    }

    public static void Recompensa(int multiplicador)
    {
        int ganho = _valorAposta * multiplicador;

        _jogador.AdicionarDinheiro(ganho);

        int dinheiroAntes = _jogador.Saldo - ganho;

        Console.WriteLine($"PARABÉNS! VOCÊ GANHOU UM MULTIPLICADOR DE {multiplicador}x, APOSTANDO ${_valorAposta} DA UM GANHO DE ${ganho}");
        Console.WriteLine($"DINHEIRO ANTES DO GANHO ${dinheiroAntes}");
        Console.WriteLine($"DINHEIRO ANTES DO GANHO ${_jogador.Saldo}\n");
    }


    public static int LerInt(string msg)
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