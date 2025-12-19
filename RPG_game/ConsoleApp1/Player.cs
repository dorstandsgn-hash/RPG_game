<<<<<<< HEAD:RPG_game/ConsoleApp1/Player.cs
﻿namespace TextRPG
{
    // ============================================
    // КЛАСИ ГРАВЦЯ
    // ============================================

    /// <summary>
    /// Клас гравця з можливістю екіпірування та магії
    /// </summary>
    public class Player : Character, ISpellCaster
    {
        private int mana;
        private int maxMana;
        private int experience;
        private int level;
        private IEquippable equippedWeapon;
        private List<Item> inventory;

        public int Mana
        {
            get => mana;
            private set => mana = Math.Max(0, Math.Min(value, maxMana));
        }

        public int MaxMana
        {
            get => maxMana;
            private set => maxMana = value;
        }

        public int Experience
        {
            get => experience;
            private set => experience = value;
        }

        public int Level
        {
            get => level;
            private set => level = value;
        }

        public IReadOnlyList<Item> Inventory => inventory.AsReadOnly();

        public Player(string name) : base(name, 100, 10)
        {
            maxMana = 50;
            mana = maxMana;
            level = 1;
            experience = 0;
            inventory = new List<Item>();
        }

        public override void Attack(Character target)
        {
            Random rand = new Random();
            int baseDamage = Strength;

            // Бонус від зброї
            if (equippedWeapon != null && equippedWeapon is Weapon weapon)
            {
                baseDamage += weapon.Damage;
            }

            // Шанс критичного удару (20%)
            bool isCritical = rand.Next(100) < 20;
            int damage = isCritical ? baseDamage * 2 : baseDamage;

            if (isCritical)
            {
                Console.WriteLine($"⚡ КРИТИЧНИЙ УДАР! {Name} завдає {damage} пошкоджень {target.Name}!");
            }
            else
            {
                Console.WriteLine($"⚔️ {Name} атакує {target.Name} і завдає {damage} пошкоджень!");
            }

            target.TakeDamage(damage);
        }

=======
﻿using static RPG_game.Enemy;

namespace RPG_game
{
    public class Player
    {
>>>>>>> c085fe08453a74777fc1a8fda98f25102baed449:RPG_game/RPG_game/Player.cs
        public void CastSpell(Character target)
        {
            int manaCost = 20;
            int spellDamage = 30;

            if (Mana < manaCost)
            {
                Console.WriteLine($"❌ Недостатньо мани! (Потрібно: {manaCost}, є: {Mana})");
                return;
            }

            Mana -= manaCost;
            Console.WriteLine($"🔮 {Name} використовує магію! Мана: {Mana}/{MaxMana}");
            Console.WriteLine($"✨ Магічний удар завдає {spellDamage} пошкоджень {target.Name}!");
            target.TakeDamage(spellDamage);
        }

        public void RestoreMana(int amount)
        {
            int oldMana = Mana;
            Mana += amount;
            Console.WriteLine($"💙 {Name} відновив {Mana - oldMana} мани! (Мана: {Mana}/{MaxMana})");
        }

        public void EquipWeapon(IEquippable weapon)
        {
            if (equippedWeapon != null)
            {
                equippedWeapon.Unequip(this);
            }

            weapon.Equip(this);
            equippedWeapon = weapon;
        }

        public void AddItem(Item item)
        {
            inventory.Add(item);
            Console.WriteLine($"📦 Отримано: {item.Name}");
        }

        public void UseItem(int itemIndex)
        {
            if (itemIndex < 0 || itemIndex >= inventory.Count)
            {
                Console.WriteLine("❌ Невірний індекс предмету!");
                return;
            }

            Item item = inventory[itemIndex];
            item.Use(this);
            inventory.RemoveAt(itemIndex);
        }

        public void GainExperience(int exp)
        {
            Experience += exp;
            Console.WriteLine($"✨ Отримано {exp} досвіду! (Всього: {Experience})");

            // Перевірка рівня
            int expForNextLevel = Level * 100;
            if (Experience >= expForNextLevel)
            {
                LevelUp();
            }
        }

        private void LevelUp()
        {
            Level++;
            MaxHealth += 20;
            Health = MaxHealth;
            MaxMana += 10;
            Mana = MaxMana;
            Strength += 5;
            Experience = 0;

            Console.WriteLine($"\n🎉 РІВЕНЬ ПІДВИЩЕНО! Тепер ви {Level} рівня!");
            Console.WriteLine($"📈 HP: {MaxHealth}, Мана: {MaxMana}, Сила: {Strength}");
        }

        public void ShowStats()
        {
            Console.WriteLine($"\n━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            Console.WriteLine($"👤 {Name} (Рівень {Level})");
            Console.WriteLine($"❤️  HP: {Health}/{MaxHealth}");
            Console.WriteLine($"💙 Мана: {Mana}/{MaxMana}");
            Console.WriteLine($"⚔️  Сила: {Strength}");
            Console.WriteLine($"✨ Досвід: {Experience}/{Level * 100}");
<<<<<<< HEAD:RPG_game/ConsoleApp1/Player.cs
=======

>>>>>>> c085fe08453a74777fc1a8fda98f25102baed449:RPG_game/RPG_game/Player.cs
            if (equippedWeapon != null)
            {
                Console.WriteLine($"🗡️  Зброя: {equippedWeapon.Name}");
            }
<<<<<<< HEAD:RPG_game/ConsoleApp1/Player.cs
=======

>>>>>>> c085fe08453a74777fc1a8fda98f25102baed449:RPG_game/RPG_game/Player.cs
            Console.WriteLine($"━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n");
        }

        public void ShowInventory()
        {
            Console.WriteLine("\n📦 ІНВЕНТАР:");
<<<<<<< HEAD:RPG_game/ConsoleApp1/Player.cs
=======

>>>>>>> c085fe08453a74777fc1a8fda98f25102baed449:RPG_game/RPG_game/Player.cs
            if (inventory.Count == 0)
            {
                Console.WriteLine("  Пусто");
            }
            else
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    Console.WriteLine($"  [{i}] {inventory[i].Name} - {inventory[i].Description}");
                }
            }
<<<<<<< HEAD:RPG_game/ConsoleApp1/Player.cs
            Console.WriteLine();
        }
    }
}
=======

            Console.WriteLine();
        }
    }
>>>>>>> c085fe08453a74777fc1a8fda98f25102baed449:RPG_game/RPG_game/Player.cs
