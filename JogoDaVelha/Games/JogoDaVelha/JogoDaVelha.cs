using GameHub.Model;
using System.Collections.Generic;
using System.Text;

namespace GameHub.Games.JogoDaVelha
{
    public class Game1
    {
        public static void JogoDaVelha(GerenciadorDeUsuario gerenciador, List<Jogador> jogadoresOrdenados)
        {
            string[,] tabuleiro = new string[3, 3];
            List<string> indexCasa = new List<string>();
            string turno = "X";
            int casa = 1;
            int tentativas = 1;

            Console.Clear();

            Titulo();

            AlimentarMatriz(tabuleiro, indexCasa, casa);

            Console.WriteLine($"{gerenciador.Jogador1.Nickname} = X");
            Console.WriteLine($"\n{gerenciador.Jogador2.Nickname} = O");
            Console.WriteLine();

            ImprimirTabuleiro(tabuleiro);

            Console.Write($"\nDeseja jogar {turno} em qual posição? ");
            string jogada = Console.ReadLine();
            Console.Clear();

            // Start of game
            while (tentativas < 9)
            {
                Titulo();

                Console.WriteLine($"{gerenciador.Jogador1.Nickname} = X");
                Console.WriteLine($"\n{gerenciador.Jogador2.Nickname} = O");
                Console.WriteLine();

                // Substituindo o valor da casa
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (jogada == tabuleiro[i, j] && indexCasa.Contains(jogada))
                        {
                            tabuleiro[i, j] = turno;
                            indexCasa.Remove(jogada);
                        }
                    }
                }

                ImprimirTabuleiro(tabuleiro);

                // vitória diagonais
                if (tabuleiro[0, 0] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 2] ||
                    tabuleiro[0, 2] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 0])
                {
                    AtribuirPontos(gerenciador, turno);
                    MensagemGanhador(turno);
                    AfterGame(gerenciador, jogadoresOrdenados);
                }
                // vitória colunas
                if (tabuleiro[0, 0] == tabuleiro[1, 0] && tabuleiro[1, 0] == tabuleiro[2, 0] ||
                    tabuleiro[0, 2] == tabuleiro[1, 2] && tabuleiro[1, 2] == tabuleiro[2, 2] ||
                    tabuleiro[0, 1] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 1])
                {
                    AtribuirPontos(gerenciador, turno);
                    MensagemGanhador(turno);
                    AfterGame(gerenciador, jogadoresOrdenados);
                }
                // vitoria linhas
                if (tabuleiro[0, 0] == tabuleiro[0, 1] && tabuleiro[0, 1] == tabuleiro[0, 2] ||
                    tabuleiro[1, 0] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[1, 2] ||
                    tabuleiro[2, 0] == tabuleiro[2, 1] && tabuleiro[2, 1] == tabuleiro[2, 2])
                {
                    AtribuirPontos(gerenciador, turno);
                    MensagemGanhador(turno);
                    AfterGame(gerenciador, jogadoresOrdenados);
                }

                if (turno == "X")
                {
                    turno = "O";
                }
                else
                {
                    turno = "X";
                }

                Console.Write($"\nDeseja jogar {turno} em qual posição? ");
                jogada = Console.ReadLine();

                tentativas++;

                while (!indexCasa.Contains(jogada))
                {
                    Console.Write("\nJogada inválida! Digite novamente: ");
                    jogada = Console.ReadLine();
                }
                Console.Clear();
            }

            if (tentativas == 9)
            {
                Titulo();

                ImprimirTabuleiro(tabuleiro);

                Console.WriteLine("\nFim de Jogo!!");
                Console.WriteLine("\nDeu velha! Nenhum jogador pontuará!");
                AfterGame(gerenciador, jogadoresOrdenados);
            }
        }
        public static void Titulo()
        {
            Console.WriteLine("            _________________________________ ");
            Console.WriteLine("           |                                 |");
            Console.WriteLine("           |                                 |");
            Console.WriteLine("           |          JOGO DA VELHA          |");
            Console.WriteLine("           |                                 |");
            Console.WriteLine("           |_________________________________|");
            Console.WriteLine();
        }
        public static int AlimentarMatriz(string[,] tabuleiro, List<string> indexCasa, int casa)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tabuleiro[i, j] = casa.ToString();
                    indexCasa.Add(casa.ToString());
                    casa++;
                }
            }
            return casa;
        }
        public static void ImprimirTabuleiro(string[,] tabuleiro)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"| {tabuleiro[i, j]} |");
                }
                Console.WriteLine();
            }
        }
        public static void MensagemGanhador(string turno)
        {
            Console.WriteLine($"\nFim de jogo! O jogador |{turno}| é o grande campeão!!!");
            Console.ReadLine();
        }
        public static void AtribuirPontos(GerenciadorDeUsuario gerenciador, string turno)
        {
            if (turno == "X")
            {
                gerenciador.Jogador1.AddPoints();
                gerenciador.Jogador2.RemovePoints();
            }
            else
            {
                gerenciador.Jogador2.AddPoints();
                gerenciador.Jogador1.RemovePoints();
            }
            gerenciador.SavePoints();
        }
        public static void AfterGame(GerenciadorDeUsuario gerenciador, List<Jogador> jogadoresOrdenados)
        {
            Console.Write("\n Deseja jogar novamente? (Y / N): ");
            string option = Console.ReadLine();
            if (option == "y")
            {
                JogoDaVelha(gerenciador, jogadoresOrdenados);
            }
            else
            {
                Program.ShowMenu(gerenciador, jogadoresOrdenados);
            }
        }
    }
}
