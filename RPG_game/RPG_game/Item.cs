namespace RPG_game
{
    public abstract class Item
    {
        public string Name { get; protected set; }

        public abstract string Description { get; protected set; }

        protected Item(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public abstract void Use();
    }
}
