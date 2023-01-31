using GameHub.Model;
using System.Text.Json;
using System;


namespace GameHub.Model
{
    public class Jogador
    {
        public string Name { get; set; } = null!;
        public string Nickname { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Points { get; set; } = 0;
        public bool isValid { get; private set; } = true;
        public int Shots { get; set; } = 64;

        public Jogador()
        {
        }
        public Jogador(string name, string nickname, string password)
        {
            if (string.IsNullOrEmpty(name))
            {
                isValid = false; 
            }
            if (string.IsNullOrEmpty(nickname))
            {
                isValid = false;
            }
            if (string.IsNullOrEmpty(password))
            {
                isValid = false;
            }

            Name = name;
            Nickname = nickname;
            Password = password;
        }
        public void AddPoints ()
        {
            Points += 10;
        }
        public void RemovePoints()
        {
            Points -= 5;
            if (Points < 0)
            {
                Points = 0;
            }
        }
    }
}
