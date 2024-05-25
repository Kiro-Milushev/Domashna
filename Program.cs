using ArenaGameEngine;

using ArenaGameEngine; 

namespace ArenaGameConsole
{
    class ConsoleGameEventListener : GameEventListener
    {
        public override void OnGameEvent(Duel gameEvent)
        {
            switch (gameEvent.EventType)
            {
                case GameEventType.Round:
                    // Print each hit individually
                    Console.WriteLine($"{gameEvent.Attacker.Name} hit {gameEvent.Defender.Name} for {gameEvent.Damage} damage.");
                    if (!gameEvent.Defender.IsAlive)
                    {
                        Console.WriteLine($"{gameEvent.Defender.Name} has lost!");
                    }
                    break;

                case GameEventType.BattleEnd:
                    Console.WriteLine();
                    Console.WriteLine($"The duel has ended.");
                    Console.WriteLine($"Winner is: {gameEvent.Winner?.Name}");
                    Console.WriteLine();
                    break;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Hero[] heroes = {
                new Knight("Sir John"),
                new Rogue("Slim Shady"),
                new Vampire("Helsing"),
                new Archer("Robin")
            };

            // Create the Arena and set the event listener
            Arena arena = new Arena(heroes);
            arena.EventListener = new ConsoleGameEventListener();

            // Start the tournament
            Hero champion = arena.StartTournament();

            // Output the champion
            Console.WriteLine($"{champion.Name} is the victor!");
            Console.ReadLine(); // Wait for user input before closing
        }
    }
}
