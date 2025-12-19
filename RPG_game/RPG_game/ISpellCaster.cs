namespace TextRPG
{
    /// <summary>
    /// Інтерфейс для персонажів, які можуть використовувати магію
    /// </summary>
    public interface ISpellCaster
    {
        int Mana { get; }
        void CastSpell(Character target);
        void RestoreMana(int amount);
    }
}