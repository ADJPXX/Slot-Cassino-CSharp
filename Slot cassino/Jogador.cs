namespace Slot_cassino;

class Jogador
{
    public string Nome { get; set; }
    public int Saldo { get; private set; }

    public Jogador(string nome, int saldo)
    {
        if (!string.IsNullOrWhiteSpace(nome))
            Nome = nome;

        if (saldo > 0)
            Saldo = saldo;
    }

    public void AdicionarDinheiro(int valor)
    {
        if (valor > 0)
            Saldo += valor;
    }

    public void Bet(int valor)
    {
        if (valor > 0 && valor <= Saldo)
        {
            Saldo -= valor;
        }
    }
}