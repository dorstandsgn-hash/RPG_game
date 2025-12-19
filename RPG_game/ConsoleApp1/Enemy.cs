namespace TextRPG
{
    // ============================================
    // КЛАСИ ВОРОГІВ
    // ============================================

    /// <summary>
    /// Базовий клас ворога
    /// </summary>
    public abstract class Enemy : Character
    {
        private int experienceReward;
        private List<Item> loot;

        public int ExperienceReward
        {
            get => experienceReward;
            protected set => experienceReward = value;
        }

        protected Enemy(string name, int health, int strength, int expReward)
            : base(name, health, strength)
        {
            experienceReward = expReward;
            loot = new List<Item>();
        }

        protected void AddLoot(Item item)
        {
            loot.Add(item);
        }

        public List<Item> GetLoot()
        {
            return new List<Item>(loot);
        }
    }
}