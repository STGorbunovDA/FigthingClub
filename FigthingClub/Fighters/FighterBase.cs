using System;

namespace FigthingClub.Fighters
{
    public abstract class FighterBase
    {
        protected Random random;
        public event Action IsDead;

        public string Name { get; private set; }
        public string ClassDescription { get; private set; }
        public string UltimateAbilityDescription { get; private set; }
        private int strength;
        public int Strength
        {
            get { return strength; }
            set
            {
                strength = value;
                Damage = value * Constants.damageMultiplier;
            }

        }
        public int Damage { get; private set; }
        private int agility;
        public int Agility
        {
            get { return agility; }
            set
            {
                agility = value;
                DodgeChance = value * Constants.dodgeMultiplier;
            }
        }
        public int DodgeChance { get; private set; }
        private int vitality;
        public int Vitality
        {
            get { return vitality; }
            set
            {
                vitality = value;
                HP = value * Constants.hpMultiplier;
            }
        }
        private int hp;
        public int HP
        {
            get { return hp; }
            set
            {
                hp = value;
                if (hp < 0)
                {
                    hp = 0;
                    if (IsDead != null)
                        IsDead();
                }
            }
        }
        protected FighterBase(string name, string classDescription, string ultimateAbilityDescription,
            int strength, int agility, int vitality)
        {
            random = new Random();
            this.Name = name;
            this.ClassDescription = classDescription;
            this.UltimateAbilityDescription = ultimateAbilityDescription;
            this.Strength = strength;
            this.Agility = agility;
            this.Vitality = vitality;
        }
        public int Kick()
        {
            int totalDamage = random.Next(Damage - 10, Damage + 11);
            Console.WriteLine($"{Name} ударил и нанес {totalDamage} урона!");
            return totalDamage;
        }
        public abstract int UseUltimateAbility();   
        public override string ToString()
        {
            return $"Имя: {Name}\nКласс: {ClassDescription}\nСила: {Strength}\t\t" +
                $"Ловкость: {Agility}\t\tЖивучесть: {Vitality}\nУрон: {Damage}\t" +
                $"Шанс увернуться: {DodgeChance}%\tHP: {HP}\nУмение: {UltimateAbilityDescription}\n";
        }
    }
}
