using System;
using System.Collections.Generic;
using System.Text;
using GameHub;

namespace GameHub.Model
{
    public class GerenciadorDeUsuario
    {
        public GerenciadorDeJogadores UserData { get; set; } = new GerenciadorDeJogadores();
        public Jogador Jogador1 { get; set; }
        public Jogador Jogador2 { get; set; }

        public void Display()
        {
            Console.Clear();
            Console.WriteLine("               ____________________________________________________       ");
            Console.WriteLine("              |                                                    |      ");
            Console.WriteLine("              |                                                    |      ");
            Console.WriteLine("              |                 WELCOME TO GAMEHUB                 |      ");
            Console.WriteLine("              |                                                    |      ");
            Console.WriteLine("              |                                                    |      ");
            Console.WriteLine("              |                    1 - LOGIN                       |      ");
            Console.WriteLine("              |                    2 - NEW USER                    |      ");
            Console.WriteLine("              |                    3 - EXIT                        |      ");
            Console.WriteLine("              |                                                    |      ");
            Console.WriteLine("              |                                                    |      ");
            Console.WriteLine("              |                   Developed by                     |      ");
            Console.WriteLine("              |                 GUILHERME TEIXEIRA                 |      ");
            Console.WriteLine("              |____________________________________________________|      ");
            Console.Write("                              O QUE DESEJA FAZER? ");
            string option = Console.ReadLine();

            while (option != "1" && option != "2" && option != "3")
            {
                Console.Write("          Opção inválida, digite novamente: ");
                option = Console.ReadLine();
            }

            if (option == "1")
            {
                Login();
            }
            if (option == "2")
            {
                CadastrarUsuario();
            }
            if (option == "3")
            {
                Console.WriteLine("\n                         Estou encerrando o programa...");
                Console.ReadKey();
            }
            return;
        }
        public void CadastrarUsuario()
        {
            Console.Clear();
            Console.WriteLine("           ______________________ ");
            Console.WriteLine("          |                      |");
            Console.WriteLine("          |  #### NEW USER ####  |");
            Console.WriteLine("          |______________________|");
            Console.WriteLine();
            Console.Write("           - Digite seu nome: ");
            string name = Console.ReadLine();
            Console.Write("           - Digite seu nickname: ");
            string nickname = Console.ReadLine();
            Console.Write("           - Digite sua senha: ");
            string password = Console.ReadLine();
            
            Jogador jogador = new Jogador(name, nickname, password);
            
            if (jogador.isValid)
            {
                Console.WriteLine("           JOGADOR REGISTRADO COM SUCESSO!");
                if (UserData.playerExist(nickname))
                {
                    Console.WriteLine("          O Nickname já existe! Tente novamente: ");
                    CadastrarUsuario();
                    return;
                }
                Console.WriteLine("           JOGADOR REGISTRADO COM SUCESSO!");
                UserData.SalvarJogador(jogador);
            }           
            Display();
        }
        public void Login()
        {
            Console.Clear();
            if (Jogador1 == null)
            {
                Console.WriteLine("           ____________________________ ");
                Console.WriteLine("          |                            |");
                Console.WriteLine("          |  #### LOGIN PLAYER 1 ####  |");
                Console.WriteLine("          |____________________________|");
                Console.WriteLine();
            } else
            {
                Console.WriteLine("           ____________________________ ");
                Console.WriteLine("          |                            |");
                Console.WriteLine("          |  #### LOGIN PLAYER 2 ####  |");
                Console.WriteLine("          |____________________________|");
                Console.WriteLine();
            }
            Console.Write("          - Digite seu nickname: ");
            string nickname = Console.ReadLine();
            Console.Write("          - Digite a sua senha: ");
            string password = Console.ReadLine();
            Jogador verification = UserData.playerExist(nickname, password);
            if (verification == null)
            {
                Console.WriteLine("          Usuário inexistente, faça o cadastro ou entre com um login válido!");
            } 
            if (Jogador1 == null)
            {
                Jogador1 = verification;
            } else
            {
                Jogador2 = verification;
            }
            while (Jogador1 == null || Jogador2 == null)
            {
                Login();
            }
        }
        public void SavePoints()
        {
            UserData.AtualizarJogador(Jogador1);
            UserData.AtualizarJogador(Jogador2);
        }
    }
}
