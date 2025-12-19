namespace TextRPG
{
    /// <summary>
    /// Темний маг - використовує отруту
    /// </summary>
    public class DarkMage : Enemy, ISpellCaster
    {
        private int mana;

        public int Mana
        {
            get => mana;
            private set => mana = Math.Max(0, value);
        }

        public DarkMage() : base("Темний Маг", 60, 10, 80)
        {
            mana = 100;
            AddLoot(new ManaPotion());
            AddLoot(new ManaPotion());
            AddLoot(new IronSword());
        }

        public override void Attack(Character target)
        {
            Random rand = new Random();

            // 50% шанс використати магію
            if (Mana >= 15 && rand.Next(100) < 50)
            {
                CastSpell(target);
            }
            else
            {
                int damage = Strength;
                Console.WriteLine($"⚡ {Name} б'є посохом і завдає {damage} пошкоджень!");
                target.TakeDamage(damage);
            }
        }

        public void CastSpell(Character target)
        {
            Mana -= 15;
            int damage = 20;
            Console.WriteLine($"☠️ {Name} використовує темну магію!");
            Console.WriteLine($"🧪 Отруєння завдає {damage} пошкоджень і накладає ефект!");
            target.TakeDamage(damage);
        }

        public void RestoreMana(int amount)
        {
            Mana += amount;
        }
    }
}