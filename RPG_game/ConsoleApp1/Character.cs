namespace TextRPG
{
    // ============================================
    // БАЗОВІ КЛАСИ
    // ============================================

    /// <summary>
    /// Базовий клас для всіх персонажів
    /// </summary>
    public abstract class Character
    {
        private int health;
        private int maxHealth;
        private int strength;
        private string name;

        public string Name
        {
            get => name;
            protected set => name = value;
        }

        public int Health
        {
            get => health;
            protected set => health = Math.Max(0, Math.Min(value, maxHealth));
        }

        public int MaxHealth
        {
            get => maxHealth;
            protected set => maxHealth = value;
        }

        public int Strength
        {
            get => strength;
            protected set => strength = Math.Max(1, value);
        }

        public bool IsAlive => health > 0;

        protected Character(string name, int health, int strength)
        {
            this.name = name;
            this.maxHealth = health;
            this.health = health;
            this.strength = strength;
        }

        /// <summary>
        /// Поліморфний метод атаки
        /// </summary>
        public abstract void Attack(Character target);

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name} отримав {damage} пошкоджень! (HP: {Health}/{MaxHealth})");

            if (!IsAlive)
            {
                Console.WriteLine($"💀 {Name} загинув!");
            }
        }

        public void Heal(int amount)
        {
            int oldHealth = Health;
            Health += amount;
            Console.WriteLine($"💚 {Name} відновив {Health - oldHealth} HP! (HP: {Health}/{MaxHealth})");
        }
    }
}