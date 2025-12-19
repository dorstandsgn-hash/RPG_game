namespace TextRPG
{
    /// <summary>
    /// Зілля здоров'я
    /// </summary>
    public class HealthPotion : Item
    {
        private int healAmount;

        public HealthPotion() : base("Зілля Здоров'я", "Відновлює 40 HP")
        {
            healAmount = 40;
        }

        public override void Use(Player player)
        {
            Console.WriteLine($"🧪 {player.Name} використовує {Name}!");
            player.Heal(healAmount);
        }
    }
}