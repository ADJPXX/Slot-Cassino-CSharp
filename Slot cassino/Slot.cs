/*
BAR = 2x

BAR BAR = 4x

BAR BAR BAR = 6x

BOOST = 10x

777 = 50x
*/

namespace Slot;

class Slot
{
    public string Nome { get; set; }
    public int Multiplicador { get; set; }

    public Slot(string nome, int multiplicador)
    {
        if (!string.IsNullOrWhiteSpace(nome))
            Nome = nome;
        if (multiplicador >= 0)
            Multiplicador = multiplicador;
    }
}
