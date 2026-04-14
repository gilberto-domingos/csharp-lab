using System;
    public class Team
    {
        public string TeamName { get; private set; }
        public int NumberOfPlayers { get; private set; }

        public Team(string teamName, int numberOfPlayers)
        {
            TeamName = teamName;
            NumberOfPlayers = numberOfPlayers;
        }

        public void AddPlayer(int count)
        {
            if (count < 0)
                throw new ArgumentException("O número de jogadores a adicionar não pode ser negativo.", nameof(count));

            NumberOfPlayers += count;
        }

        public bool RemovePlayer(int count)
        {
            if (count < 0)
                throw new ArgumentException("O número de jogadores a remover não pode ser negativo.", nameof(count));

            if (NumberOfPlayers - count < 0)
                return false;

            NumberOfPlayers -= count;
            return true;
        }

        protected void SetTeamName(string newName)
        {
            TeamName = newName;
        }
    }

    public class Subteam : Team
    {
        public Subteam(string teamName, int numberOfPlayers)
            : base(teamName, numberOfPlayers)
        {
        }

        public void ChangeTeamName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("O novo nome do time não pode ser vazio.", nameof(newName));

            SetTeamName(newName);
        }
    }

    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("===== GERENCIADOR DE TIMES =====");

            Console.Write("Digite o nome do time: ");
            string teamName = Console.ReadLine() ?? "SemNome";

            Console.Write("Digite o número inicial de jogadores: ");
            int numberOfPlayers = int.Parse(Console.ReadLine() ?? "0");

            var team = new Subteam(teamName, numberOfPlayers);

            Console.WriteLine($"\nTime '{team.TeamName}' criado com {team.NumberOfPlayers} jogadores.");

            Console.Write("\nQuantos jogadores você deseja adicionar? ");
            int addCount = int.Parse(Console.ReadLine() ?? "0");
            team.AddPlayer(addCount);
            Console.WriteLine($"Agora o time '{team.TeamName}' tem {team.NumberOfPlayers} jogadores.");

            Console.Write("\nQuantos jogadores você deseja remover? ");
            int removeCount = int.Parse(Console.ReadLine() ?? "0");
            bool removed = team.RemovePlayer(removeCount);

            if (removed)
                Console.WriteLine($"Agora o time '{team.TeamName}' tem {team.NumberOfPlayers} jogadores.");
            else
                Console.WriteLine($"Não foi possível remover {removeCount} jogadores (ficaria negativo).");

            Console.Write("\nDeseja alterar o nome do time? (s/n): ");
            if (Console.ReadLine()?.Trim().ToLower() == "s")
            {
                Console.Write("Digite o novo nome do time: ");
                string newName = Console.ReadLine() ?? team.TeamName;
                string oldName = team.TeamName;

                team.ChangeTeamName(newName);
                Console.WriteLine($"O nome do time '{oldName}' foi alterado para '{team.TeamName}'.");
            }

            Console.WriteLine("\nOperações concluídas com sucesso!");
        }
    }

