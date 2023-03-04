using System;

namespace FigthingClub.Fighters
{
    public class Warrior : FighterBase
    {
        public Warrior(string name = "Имя должен выбрать игрок") : base(name, "Безжалостный воин", 
            "Ярость - Боль делает воина только сильнее. После удара воин впадает в ярость " +
            "и трижды бьет противника щитом. Урон каждого удара равен показателю силы", 5, 0, 5)
        {

        }
        public override int UseUltimateAbility()
        {
            int totalDamage = Strength * 3;
            Console.WriteLine($"{Name} впадает в ярость! Он трижды бьет щитом и наносит {totalDamage} урона!");
            return totalDamage;
        }
    }
}
