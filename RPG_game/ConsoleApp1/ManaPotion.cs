namespace TextRPG
{
    /// <summary>
    /// Зілля мани
    /// </summary>
    public class ManaPotion : Item
    {
        private int manaAmount;

        public ManaPotion() : base("Зілля Мани", "Відновлює 30 мани")
        {
            manaAmount = 30;
        }

        public override void Use(Player player)
        {
            Console.WriteLine($"🧪 {player.Name} використовує {Name}!");
            player.RestoreMana(manaAmount);
        }
    }
}