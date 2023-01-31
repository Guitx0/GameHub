using GameHub.Games.Battleship;
using GameHub.Games.JogoDaVelha;
using GameHub.Model;
using System.Text.Json;

namespace GameHub;

public class Program
{
    public static void Main(string[] args)
    {
        GerenciadorDeUsuario gerenciador = new GerenciadorDeUsuario();
        GerenciadorDeJogadores gerenciadorDeJogadores = new GerenciadorDeJogadores();
        List<Jogador> jogadoresOrdenados = gerenciadorDeJogadores.Jogadores.OrderBy(x => x.Points).ToList();

        gerenciador.Display();

        ShowMenu(gerenciador, jogadoresOrdenados);
    }

    public static void ShowMenu( GerenciadorDeUsuario gerenciador, List<Jogador> jogadoresOrdenados)
    {
        if (gerenciador.Jogador1 != null && gerenciador.Jogador2 != null)
        {
            Console.Clear();
            Console.WriteLine("               _____________________________________________________       ");
            Console.WriteLine("              |                                                     |      ");
            Console.WriteLine("              |                                                     |      ");
            Console.WriteLine("              |                 WELCOME TO GAMEHUB                  |      ");
            Console.WriteLine("              |                                                     |      ");
            Console.WriteLine("              |                 1 - JOGO DA VELHA                   |      ");
            Console.WriteLine("              |                 2 - BATALHA NAVAL                   |      ");
            Console.WriteLine("              |                 3 - RANKING                         |      ");
            Console.WriteLine("              |                 4 - EXIT                            |      ");
            Console.WriteLine("              |                                                     |      ");
            Console.WriteLine("              |                                                     |      ");
            Console.WriteLine("              |                   Developed by                      |      ");
            Console.WriteLine("              |                 GUILHERME TEIXEIRA                  |      ");
            Console.WriteLine("              |_____________________________________________________|      ");
            Console.Write("                              O QUE DESEJA FAZER? ");
            string game = Console.ReadLine();

            

            if (game == "1")
            {
                Game1.JogoDaVelha(gerenciador, jogadoresOrdenados);
            }
            if (game == "2")
            {
                Game2.Battleship(gerenciador);
            }
            if (game == "3")
            {
                Ranking(gerenciador, jogadoresOrdenados);
                
            }
            if (game == "4")
            {
                Console.WriteLine("\n                         Estou encerrando o programa...");
            }

            while (game != "1" && game != "2" && game != "3" && game != "4")
            {
                Console.Write("Opção inválida! Digite novamente: ");
                game = Console.ReadLine();
            }
        }
    }

    public static void Ranking(GerenciadorDeUsuario gerenciador, List<Jogador> jogadoresOrdenados)
    {
        Console.WriteLine("\n\n###   LEADERBOARD   ###");
        foreach (Jogador jogador in jogadoresOrdenados)
        {
            Console.WriteLine($"{jogador.Nickname} - {jogador.Points}");
        }
        Console.WriteLine("    ***Pressione qualquer tecla pra voltar ao menu***  ");
        Console.ReadKey();
        ShowMenu(gerenciador, jogadoresOrdenados);
    }
}