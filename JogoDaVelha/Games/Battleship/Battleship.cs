using GameHub.Model;


namespace GameHub.Games.Battleship
{
    public class Game2
    {
        public static void Battleship(GerenciadorDeUsuario gerenciador)
        {
            string[,] mapa = new string[9, 9];
            string[,] mapa2 = new string[9, 9];
            List<string> indexCasa = new List<string>();
            string water = "~";
            string submarine = "S";
            string fragata = "F";
            string destroyer = "D";
            string erro = "X";
            int enemyLife = 10;
            int qtdSubmarine = 2;
            int qtdFrigate = 2;
            int qtdDestroyer = 1;   
            Console.Clear();

            Titulo();

            mapa[0, 0] = " "; mapa[0, 1] = "1"; mapa[0, 2] = "2"; mapa[0, 3] = "3"; mapa[0, 4] = "4"; mapa[0, 5] = "5"; mapa[0, 6] = "6"; mapa[0, 7] = "7"; mapa[0, 8] = "8";
            mapa[1, 0] = "1"; mapa[2, 0] = "2"; mapa[3, 0] = "3"; mapa[4, 0] = "4"; mapa[5, 0] = "5"; mapa[6, 0] = "6"; mapa[7, 0] = "7"; mapa[8, 0] = "8";

            Console.WriteLine($"  - A BATALHA ESTÁ CHEGANDO ALMIRANTE {gerenciador.Jogador1.Nickname}, POSICIONE SUAS ARMAS!!!");
            Console.WriteLine("   - AQUI ESTÃO TODOS OS SEUS NAVIOS DISPONÍVEIS: ");
            Console.WriteLine($"\n  - DESTROYER: {qtdDestroyer}");
            Console.WriteLine($"\n  - FRAGATA: {qtdFrigate}");
            Console.WriteLine($"\n  - SUBMARINO: {qtdSubmarine}");

            Console.WriteLine();
            string option;
            int linha = 0;
            int coluna = 0;
            string direction;      
            
            SubstituirPorAgua(mapa, water);

            ImprimirMapa(mapa);



            Console.WriteLine();
        }
        public static void Titulo()
        {
            Console.WriteLine(" _________________________________ ");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|          BATALHA NAVAL          |");
            Console.WriteLine("|                                 |");
            Console.WriteLine("|_________________________________|");
            Console.WriteLine();
        }
        public static void ImprimirMapa(string[,] mapa)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write($" {mapa[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        public static string SubstituirPorAgua(string[,] mapa, string water)
        {
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    mapa[i, j] = water;
                }
            }
            return water;
        }
        public static void Coordenadas(int linha, int coluna, string direction)
        {
            Console.Write("\n DIGITE A LINHA: ");
            linha = int.Parse(Console.ReadLine());
            Console.Write("\n DIGITE A COLUNA: ");
            coluna = int.Parse(Console.ReadLine());
            Console.Write("POSICIONAR NA VERTICAL OU HORIZONTAL?(V / H): ");
            direction = Console.ReadLine();
            while (direction != "v" && direction != "h")
            {
                Console.WriteLine("OPÇÃO INVÁLIDA!");
                direction = Console.ReadLine();
            }
        }
        public static void CallDestroyer(string[,] mapa, int linha, int coluna, string destryoer, string direction)
        {
            if (direction == "v")
            {
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (linha + 3 > mapa.GetLength(0) && coluna > mapa.GetLength(1))
                        {
                            Console.WriteLine("NÃO É POSSIVEL POSICIONAR AQUI, TENTE OUTRA COORDENADA");
                            Coordenadas(linha, coluna, direction);
                        }
                        mapa[linha, coluna] = destryoer;
                        mapa[linha + 1, coluna] = destryoer;
                        mapa[linha + 2, coluna] = destryoer;
                        mapa[linha + 3, coluna] = destryoer;
                        
                    }
                }
            }
            else
            {
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (coluna + 3 > mapa.GetLength(1) && linha > mapa.GetLength(0))
                        {
                            Console.WriteLine("NÃO É POSSIVEL POSICIONAR AQUI, TENTE OUTRA COORDENADA!!");
                            Coordenadas(linha, coluna, direction);
                        }
                        mapa[linha, coluna] = destryoer;
                        mapa[linha, coluna + 1] = destryoer;
                        mapa[linha, coluna + 2] = destryoer;
                        mapa[linha, coluna + 3] = destryoer;
                        
                    }
                }
            }
        }
        public static void CallFrigate(string[,] mapa, int linha, int coluna, string fragata, string direction)
        {
            if (direction == "v")
            {
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (linha + 2 > mapa.GetLength(0) && coluna > mapa.GetLength(1))
                        {
                            Console.WriteLine("NÃO É POSSIVEL POSICIONAR AQUI, TENTE OUTRA COORDENADA");
                            Coordenadas(linha, coluna, direction);
                        }
                        mapa[linha, coluna] = fragata;
                        mapa[linha + 1, coluna] = fragata;
                        mapa[linha + 2, coluna] = fragata;
                        
                    }
                }
            }
            else
            {
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (coluna + 2 > mapa.GetLength(1) && linha > mapa.GetLength(0))
                        {
                            Console.WriteLine("NÃO É POSSIVEL POSICIONAR AQUI, TENTE OUTRA COORDENADA");
                            Coordenadas(linha, coluna, direction);
                        }
                        mapa[linha, coluna] = fragata;
                        mapa[linha, coluna + 1] = fragata;
                        mapa[linha, coluna + 2] = fragata;
                        
                    }
                }
            }
        }
        public static void CallSubmarine(string[,] mapa, int linha, int coluna, string submarine, string direction)
        {
            if (direction == "v")
            {
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (linha + 2 > mapa.GetLength(0) && coluna > mapa.GetLength(1))
                        {
                            Console.WriteLine("NÃO É POSSIVEL POSICIONAR AQUI, TENTE OUTRA COORDENADA");
                            Coordenadas(linha, coluna, direction);
                        }
                        mapa[linha, coluna] = submarine;
                        mapa[linha + 1, coluna] = submarine;
                        mapa[linha + 2, coluna] = submarine;
                        
                    }
                }
            }
            else
            {
                for (int i = 1; i < 9; i++)
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (coluna + 2 > mapa.GetLength(1) && linha > mapa.GetLength(0))
                        {
                            Console.WriteLine("NÃO É POSSIVEL POSICIONAR AQUI, TENTE OUTRA COORDENADA");
                            Coordenadas(linha, coluna, direction);
                        }
                        mapa[linha, coluna] = submarine;
                        mapa[linha, coluna + 1] = submarine;
                        mapa[linha, coluna + 2] = submarine;
                        
                    }
                }
            }
        }
     
    }

}
