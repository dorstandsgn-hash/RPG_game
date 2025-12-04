using System;

namespace RPG_game
{
    public abstract class Character
    {
        private int _health;
        private int _maxHealth;
        private int _strength;
        private string _name;

        public string Name
        {
            get => _name;
            protected set => _name = value;
        }

        public int Health
        {
            get => _health;
            protected set => _health = Math.Max(0, Math.Min(0, _maxHealth));
        }

        public int MaxHealth
        {
            get => _maxHealth;
            protected set => _maxHealth = value;
        }

        public int Strength
        {
            get => _strength;
            protected set => _strength = Math.Max(1, value);
        }


        public bool IsAlive => _health > 0;

        protected Character(int health, int strenght, string name)
        {
            Health = health;
            MaxHealth = health;
            Strength = strenght;
            Name = name;
        }

        public abstract void Attack(Character target);

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"{Name} отримав {damage} пошкоджень! (HP: {Health}/{MaxHealth})")
    

            if (!IsAlive)
            {
                Console.WriteLine($"{Name} загинув!")
            }
        }

        public void Heal(int heal)
        {
            var oldHealth = Health;
            Health += heal;
            Console.WriteLine($"{Name} відновив {Health - oldHealth} (HP: {Health}/{MaxHealth})")
            }

    }
}


