namespace RPG_game
{
    public interface Iequippable
    {
        string Name { get; }
        void Equip(Player player);
        void Unequip(Player player);

    }
