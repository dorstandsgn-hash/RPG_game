using static RPG_game.Enemy;

namespace RPG_game
{
    public abstract class Enemy : Character
    {
        private int _experienceReward;
        private List<Item> _loot;

        public int ExperienceReward
        {
            get => _experienceReward;
            set => _experienceReward = value;
        }

        protected Enemy(int health, int strenght, string name, int experienceReward) : base(health, strenght, name)
        {
            _experienceReward = experienceReward;
            _loot = new List<Item>();
        }

        protected void AddLoot(Item item)
        {
            return new List<Item>(_loot);   
        }
    public abstract class Character
    {
        private int _health;
        private int _maxHealth;
        private int _strength;
        private int _name;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
