namespace ArenaGameEngine
{
    public class Arena
    {
        private Hero[] participants;
        private int currentRoundSize;

        public IGameEventListener EventListener { get; set; }

        public Arena(Hero[] heroes)
        {
            participants = heroes;
            currentRoundSize = heroes.Length;
        }

        public void SetHeroes(Hero a, Hero b)
        {
            HeroA = a;
            HeroB = b;
        }

        public Hero HeroA { get; set; }
        public Hero HeroB { get; set; }

        public Hero Battle()
        {
            Hero attacker = HeroA;
            Hero defender = HeroB;
            while (true)
            {
                int damage = attacker.Attack();
                defender.TakeDamage(damage);

                if (EventListener != null)
                {
                    EventListener.OnGameEvent(new Duel(
                        eventType: GameEventType.Round,
                        attacker: attacker,
                        defender: defender,
                        damage: damage
                    ));
                }

                if (defender.IsDead)
                {
                    if (EventListener != null)
                    {
                        EventListener.OnGameEvent(new Duel(
                            eventType: GameEventType.BattleEnd,
                            winner: attacker,
                            loser: defender
                        ));
                    }
                    return attacker;
                }

                if (attacker is Archer archer)
                {
                    archer.Sacrifice();
                }

                (attacker, defender) = (defender, attacker);
            }
        }

        public Hero StartTournament()
        {
            while (currentRoundSize > 1)
            {
                RandomizeParticipants();

                Hero[] nextRoundWinners = new Hero[currentRoundSize / 2];

                for (int i = 0; i < currentRoundSize; i += 2)
                {
                    SetHeroes(participants[i], participants[i + 1]);
                    nextRoundWinners[i / 2] = Battle();
                }

                participants = nextRoundWinners;
                currentRoundSize /= 2;
            }

            return participants[0];
        }

        private void RandomizeParticipants()
        {
            Random rng = new Random();
            int n = participants.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (participants[k], participants[n]) = (participants[n], participants[k]);
            }
        }
    }
}

