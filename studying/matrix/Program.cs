namespace matrix;

public class CampoMinado
{
    static int qtdLinhas = 10;
    static int qtdColunas = 10;
    static int[,] campo = new int[qtdLinhas, qtdColunas];
    static int[,] jogo = new int[qtdLinhas, qtdColunas];

    public CampoMinado()
    {
        jogar();
    }

    public static void jogar()
    {
        for (int l = 0; l < qtdLinhas; l++)
        {
            for (int c = 0; c < qtdColunas; c++)
            {
                campo[l, c] = 0;
                jogo[l, c] = -1;
            }
        }
        // gerar posição aleatória para bandeira
        Random random = new Random();
        int linha = random.Next(qtdLinhas);
        int coluna = random.Next(qtdColunas);
        campo[linha, coluna] = 2;

        // gerar posição aleatória para bombas
        int bombas = 0;
        do
        {
            linha = random.Next(qtdLinhas);
            coluna = random.Next(qtdColunas);
            if (campo[linha, coluna] == 0)
            {
                campo[linha, coluna] = 1;
                bombas++;
            }
        }
        while (bombas < 5);

        bool fimDeJogo = false;

        do
        {
            for (int l = 0; l < campo.GetLength(0); l++)
            {
                for (int c = 0; c < campo.GetLength(1); c++)
                {
                    Console.Write(string.Format("{0} ", campo[l, c]));
                }
                Console.WriteLine();
            }

            Console.WriteLine("Selecione uma linha [1-10]: ");
            linha = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine("Selecione uma coluna [1-10]: ");
            coluna = Convert.ToInt32(Console.ReadLine()) - 1;

            switch (campo[linha, coluna])
            {
                case 0:
                    jogo[linha, coluna] = 0;
                    Console.WriteLine("Continue tentando.");
                    Console.WriteLine();
                    break;
                case 1:
                    jogo[linha, coluna] = 1;
                    Console.WriteLine("BOOOOM. Você perdeu.");
                    Console.WriteLine();
                    break;
                default:
                    jogo[linha, coluna] = 2;
                    Console.WriteLine("Parabéns! Você ganhou!");
                    Console.WriteLine();
                    break;
            }
        } while (!fimDeJogo);
    }
}

public class JogoDaVelha
{
    static string[,] tabuleiro = new string[3,3];
    static int linha;
    static int coluna;
    static bool fimDeJogo = false;
    static int jogador = 1;
    static int jogada = 0;

    public JogoDaVelha()
    {
        jogar();
    }

    private static void jogar()
    {
        for (int l = 0; l < 3; l++)
        {
            for(int c = 0; c < 3; c++)
                tabuleiro[l, c] = "";
        }

        while(!fimDeJogo)
        {
            imprimirTabuleiro(tabuleiro);

            if(jogador == 1)
                Console.WriteLine("Jogador 1: ");
            else
                Console.WriteLine("Jogador 2: ");

            Console.WriteLine("Selecione uma linha [1-3]: ");
            linha = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine("Selecione uma coluna [1-3]: ");
            coluna = Convert.ToInt32(Console.ReadLine()) - 1;

            jogada++;

            fimDeJogo = conferirJogada(tabuleiro, linha, coluna, jogador, jogada);

            if(jogador == 1)
                jogador = 2;
            else
                jogador = 1;
        }
    }

    private static void imprimirTabuleiro(string[,] tabuleiro)
    {
        for (int l = 0; l < 3; l++)
        {
            for (int c = 0; c < 3; c++)
            {
                Console.Write(string.Format(" {0} ", tabuleiro[l,c]));
                if(c < 2)
                    Console.Write("|");
            }
            Console.WriteLine();
            if(l < 2)
                Console.Write("--------");
            Console.WriteLine();
        }
    }

    private static bool conferirJogada(string[,] tabuleiro, int linha, int coluna, int jogador, int jogada)
    {
        bool trinca = false;

        if(jogador == 1)
            tabuleiro[linha, coluna] = "X";
        else
            tabuleiro[linha, coluna] = "O";

        for(int c = 0; c < 3; c++)
        {
            if (tabuleiro[linha, c] != tabuleiro[linha, coluna])
                break;
            if (c == 2)
                trinca = true;
        }

        if(!trinca)
        {
            for (int l = 0; l < 3; l++)
            {
                if(tabuleiro[l, coluna] != tabuleiro[linha, coluna])
                    break;
                if (l == 2)
                    trinca = true;
            }
        }

        if(!trinca)
        {
            if(linha == coluna)
            {
                for (int cont = 0; cont < 3; cont++)
                {
                    if(tabuleiro[cont, cont] != tabuleiro[linha, coluna])
                        break;
                    if (cont == 2)
                        trinca = true;
                }
            }
        }

        if(!trinca)
        {
            if (linha+coluna == 3 - 1)
            {
                for (int cont = 0; cont < 3; cont++)
                {
                    if(tabuleiro[cont, 3-cont-1] != tabuleiro[linha, coluna])
                        break;
                    if (cont == 2)
                        trinca = true;
                }
            }
        }

        if (trinca)
        {
            Console.WriteLine();
            imprimirTabuleiro(tabuleiro);
            Console.WriteLine("Jogador " + jogador + " VENCEU!");
            return true;
        }

        if(jogada == 9)
        {
            Console.WriteLine();
            imprimirTabuleiro(tabuleiro);
            Console.WriteLine("Empate!");
            return true;
        }
        else
        {
            Console.WriteLine("Próximo jogador");
            return false;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // CampoMinado campoMinado = new CampoMinado();
        JogoDaVelha jogoDaVelha = new JogoDaVelha();
    }
}