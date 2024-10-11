namespace abstract_data_type;
public class Heroi
{
    int forca, vida, moedas, tipo;

    public Heroi(int f, int v, int m, int t)
    {
        forca = f;
        vida = v;
        moedas = m;
        tipo = t;
    }

    public void Atacar()
    {
        if (tipo == 1)
            Console.WriteLine("Ataque com espada");
        else
            Console.WriteLine("Ataque com magia");
    }

    public void sofrerDano(int dano)
    {
        vida -= dano;
        if (vida <= 0)
            Console.WriteLine("Herói morreu!");
    }
}
public class Dragao
{
    int mordida, bolaFogo, vida, recompensa;

    public Dragao(int m, int b, int v, int r)
    {
        mordida = m;
        bolaFogo = b;
        vida = v;
        recompensa = r;
    }

    public void morder()
    {
        Console.WriteLine("Mordida!");
    }

    public void lancarFogo()
    {
        Console.WriteLine("Lançar bola de fogo!");
    }

    public void sofrerDano(int dano)
    {
        vida -= dano;
        if (vida <= 0)
            Console.WriteLine("Dragão derrotado!");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Heroi cavaleiro = new Heroi(80, 100, 0, 1);
        Heroi Mago = new Heroi(60, 100, 0, 2);
        Dragao dragaoVermelho = new Dragao(70, 100, 100, 30);

        cavaleiro.Atacar();
        dragaoVermelho.sofrerDano(80);
        dragaoVermelho.lancarFogo();
        cavaleiro.sofrerDano(110);
        Mago.Atacar();
        dragaoVermelho.sofrerDano(60);

        //Console.WriteLine($"Vida - cavaleiro: {cavaleiro.vida}");
    }
}
