using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGameEngine
{
    // The GameEvent class (or struct) should be defined in your project
    public class Duel
    {
        public GameEventType EventType { get; }
        public Hero Attacker { get; }
        public Hero Defender { get; }
        public int Damage { get; }
        public Hero Winner { get; }
        public Hero Loser { get; }

        // Constructor for round events
        public Duel(GameEventType eventType, Hero attacker, Hero defender, int damage)
        {
            EventType = eventType;
            Attacker = attacker;
            Defender = defender;
            Damage = damage;
        }

        // Constructor for battle end events
        public Duel(GameEventType eventType, Hero winner, Hero loser)
        {
            EventType = eventType;
            Winner = winner;
            Loser = loser;
        }
    }

    // The GameEventType enum should also be defined in your project
    public enum GameEventType
    {
        Round,
        BattleEnd
    }

    // The generic event listener interface
    public interface IGameEventListener
    {
        void OnGameEvent(Duel gameEvent);
    }

    // Your updated GameEventListener class
    public class GameEventListener : IGameEventListener
    {
        public virtual void OnGameEvent(Duel gameEvent)
        {
            switch (gameEvent.EventType)
            {
                case GameEventType.Round:
                    Console.WriteLine(gameEvent.Defender.IsAlive
                        ? $"{gameEvent.Attacker.Name} hit {gameEvent.Defender.Name} for {gameEvent.Damage} damage! {gameEvent.Defender.Name} has {gameEvent.Defender.Health} health remaining."
                        : $"{gameEvent.Attacker.Name} hit {gameEvent.Defender.Name} for {gameEvent.Damage} damage! {gameEvent.Defender.Name} has been defeated!");
                    break;

                case GameEventType.BattleEnd:
                    Console.WriteLine($"\nThe duel has ended. Winner is: {gameEvent.Winner.Name}\n");
                    break;
            }
        }
    }
}
