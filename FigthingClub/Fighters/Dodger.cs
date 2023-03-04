using System;

namespace FigthingClub.Fighters
{
    public class Dodger : FighterBase
    {
        public Dodger(string name = "Имя должен выбрать игрок") : base(name, "Изворотливый ловкач",
            "Ловкость рук - Есть 25% шанс запутать противника и незаметно ударить второй рукой. " +
            "Такой удар считается критическим попаданием (x3)", 3, 4, 3)
        {

        }
        public override int UseUltimateAbility()
        {
            int totalDamage = 0;
            int chance = random.Next(1, 101);
            if (chance <= 25)
            {
                Console.WriteLine($"{Name} изловчился и ударил второй рукой! " +
                    $"Этот удар оказался критическим и нанес {totalDamage} урона!");
                return totalDamage = Damage * 3;
            }
            Console.WriteLine($"{Name} попытался незаметно ударить второй рукой, " +
                "но противник это заметил и увернулся!");
            return totalDamage;
        }
    }
}
