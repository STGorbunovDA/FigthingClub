using FigthingClub.Fighters;
using System;

namespace FigthingClub
{
    public class Game
    {
        private Random random;
        private FightState fightState;
        private FighterBase player1;
        private FighterBase player2;

        public Game()
        {
            random = new Random();
            fightState = FightState.NextRound;
        }

        public void StartGame()
        {
            Console.Clear();
            Console.WriteLine("ИГРОК 1 СОЗДАЕТ БОЙЦА:\n");
            player1 = CreateFighter();
            Console.Clear();
            Console.WriteLine("ИГРОК 2 СОЗДАЕТ БОЙЦА:\n");
            player2 = CreateFighter();
            Console.Clear();
            StartFight();

        }
        private void StartFight()
        {
            for (int i = 3; i > 0; i--)
            {
                Console.Clear();
                Console.WriteLine($"{i}...");
                Console.ReadLine();
            }
            int round = 1;

            while (fightState == FightState.NextRound)
            {
                Console.Clear();
                Console.WriteLine($"РАУНД {round}\n");
                CalculateDamage(player1, player2);
                CalculateDamage(player2, player1);
                Console.WriteLine();
                Console.WriteLine("ИГРОК 1:");
                Console.WriteLine(player1);
                Console.WriteLine();
                Console.WriteLine("ИГРОК 2:");
                Console.WriteLine(player2);
                Console.ReadLine();
                round++;
            }
            Console.WriteLine("БОЙ ОКОНЧЕН!");
            Console.ReadLine();
        }
        private void CalculateDamage(FighterBase agressor, FighterBase victim)
        {
            if (victim.DodgeChance > random.Next(1, 101))
                Console.WriteLine($"{agressor.Name} хотел ударить, но противник увернулся от удара!");
            else
            {
                victim.HP -= agressor.Kick();
                victim.HP -= agressor.UseUltimateAbility();
            }
        }

        private FighterBase CreateFighter()
        {
            FighterBase fighter;
            int points = 5;
            Console.WriteLine("Назовите своего бойца: ");
            string name = Console.ReadLine();
            Console.WriteLine("\nВыберите класс героя:\n1: Воин\n2: Ловкач\n3: Маг");
            string fighterType = Console.ReadLine();
            switch (fighterType)
            {
                case "1":
                    fighter = new Warrior(name);
                    break;
                case "2":
                    fighter = new Dodger(name);
                    break;
                default:
                    fighter = new Mage(name);
                    break;
            }
            while (points > 0)
            {
                Console.Clear();
                Console.WriteLine(fighter);
                Console.WriteLine("Распределите очки умений среди характеристик персонажа:");
                Console.WriteLine($"+1 Силы:      +{Constants.damageMultiplier} к урону");
                Console.WriteLine($"+1 Ловкости:  +{Constants.dodgeMultiplier}% увернуться от атаки");
                Console.WriteLine($"+1 Живучести: +{Constants.hpMultiplier} HP");
                Console.WriteLine();
                Console.WriteLine($"Осталось очков умений: {points}");
                Console.WriteLine("1: +1 Силы");
                Console.WriteLine("2: +1 Ловкости");
                Console.WriteLine("3: +1 Живучести");
                switch (Console.ReadLine())
                {
                    case "1":
                        fighter.Strength += 1;
                        break;
                    case "2":
                        fighter.Agility += 1;
                        break;
                    default:
                        fighter.Vitality += 1;
                        break;
                }
                points--;
            }
            fighter.IsDead += () => fightState = FightState.Stopped;
            return fighter;
        }
    }
}
