namespace TextRPG
{
    // ============================================
    // ІНТЕРФЕЙСИ
    // ============================================

    /// <summary>
    /// Інтерфейс для предметів, які можна екіпірувати
    /// </summary>
    public interface IEquippable
    {
        string Name { get; }
        void Equip(Player player);
        void Unequip(Player player);
    }
}