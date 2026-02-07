namespace Slot;

class Jogador
{
    public string Nome { get; set; }
    public double Saldo { get; private set; }

    public Jogador(string nome, double saldo)
    {
        if (!string.IsNullOrWhiteSpace(nome))
            Nome = nome;

        if (saldo > 0)
            Saldo = saldo;
    }

    public void AdicionarDinheiro()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("DIGITE 0 (ZERO) PARA SAIR.\n");
            Console.Write("DIGITE O VALOR QUE VOCÊ QUER ADICIONAR NA SUA CARTEIRA: $");
            if (int.TryParse(Console.ReadLine().Trim(), out int valor))
            {
                if (valor == 0)
                {
                    break;
                }
                else if (valor > 0)
                {
                    Saldo += valor;
                    Console.WriteLine($"FOI ADICIONADO ${Saldo} NA SUA CARTEIRA");
                    Bet();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("VALOR INVÁLIDO, DIGITE UM VALOR VÁLIDO!");
                    Console.WriteLine("\nAPERTE ENTER PARA INSERIR UM NOVO VALOR");
                    Console.ReadKey();
                }
            }
        }
    }

    public void Bet()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("DIGITE 0 (ZERO) PARA SAIR.\n");
            Console.WriteLine($"SEU DINHEIRO ATUAL É ${Saldo}");
            Console.Write("DIGITE O VALOR QUE VOCÊ QUER APOSTAR: $");

            if (double.TryParse(Console.ReadLine().Trim(), out double valor))
            {
                if (valor == 0)
                {
                    AdicionarDinheiro();
                    break;
                }

                else if (valor > 0 && valor <= Saldo)
                {
                    Saldo -= valor;
                    Console.WriteLine($"VOCÊ APOSTOU ${valor}");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("VALOR INVÁLIDO, DIGITE UM VALOR VÁLIDO!");
                    Console.WriteLine("\nAPERTE ENTER PARA INSERIR UM NOVO VALOR");
                    Console.ReadKey();
                }
            }
        }
    }
}