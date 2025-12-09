namespace RPG_game
{
    public interface IspellCaster
    {
        int Mana {  get; }

        void CastSpell(Character target);
        void RestoreMana(int amout);

    }
