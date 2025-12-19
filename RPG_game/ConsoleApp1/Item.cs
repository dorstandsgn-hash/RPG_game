<<<<<<< HEAD:RPG_game/ConsoleApp1/Item.cs
﻿namespace TextRPG
{
    // ============================================
    // КЛАСИ ПРЕДМЕТІВ
    // ============================================

    /// <summary>
    /// Базовий клас предмету
    /// </summary>
    public abstract class Item
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
=======
﻿namespace RPG_game
{
    public abstract class Item
    {
        public string Name { get; protected set; }

        public abstract string Description { get; protected set; }
>>>>>>> c085fe08453a74777fc1a8fda98f25102baed449:RPG_game/RPG_game/Item.cs

        protected Item(string name, string description)
        {
            Name = name;
            Description = description;
        }

<<<<<<< HEAD:RPG_game/ConsoleApp1/Item.cs
        public abstract void Use(Player player);
    }
}
=======
        public abstract void Use();
    }
}
>>>>>>> c085fe08453a74777fc1a8fda98f25102baed449:RPG_game/RPG_game/Item.cs
