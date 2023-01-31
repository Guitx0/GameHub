using System.Text.Json;
using System.Text.Json.Serialization;

namespace GameHub.Model
{
    public class GerenciadorDeJogadores
    {
        public List<Jogador> Jogadores { get; private set; } = new List<Jogador>();
        string jogadoresPath = "jogadores.json";

        public GerenciadorDeJogadores()
        {
            if (File.Exists("jogadores.json"))
            {
                string json = File.ReadAllText("jogadores.json");
                Jogadores = JsonSerializer.Deserialize<List<Jogador>>(json);
            }     
        }
        public void SalvarJogador(Jogador jogador)
        {
            Jogadores.Add(jogador);
            string jogadoresJson = JsonSerializer.Serialize(Jogadores);
            File.WriteAllText(jogadoresPath, jogadoresJson);
        }
        public bool playerExist(string nickname)
        {
            return Jogadores.Any(jogador => jogador.Nickname == nickname);
        }

        public Jogador playerExist(string nickname, string password)
        {
            return Jogadores.FirstOrDefault(jogador => jogador.Password.Equals(password) && jogador.Nickname.Equals(nickname, StringComparison.OrdinalIgnoreCase));
        }

        public void AtualizarJogador(Jogador jogador)
        {
            for (int i = 0; i < Jogadores.Count; i++)
            {
                if (Jogadores[i].Nickname == jogador.Nickname)
                {
                    Jogadores[i] = jogador;
                    string jogadoresJson = JsonSerializer.Serialize(Jogadores);
                    File.WriteAllText(jogadoresPath, jogadoresJson);
                }
            }
        }
    }
}
