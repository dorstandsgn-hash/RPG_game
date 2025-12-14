using System;
using System.Reflection.PortableExecutable;
using System.Xml.Linq;
using static RPG_game.Enemy;

namespace RPG_game
{
    public class Player : Character, ISpellCaster
    {
        private int _mana;
        private int _maxMana;
        private int _experience;
        private int _level;
        private IEquipable _equipableWeapon;
        private List<Item> _inventory;

        public int Mana
        {
            get => _mana;
            private set => _mana = Math.Max(0, Math.Min(value, _maxMana));
        }

        public int Mana
        {
            get => _mana;
            private set => _mana = Math.Max(0, Math.Min(value, _maxMana));
        }

        public int MaxMana
        {
            get => _maxMana;
            private set => _maxMana = value;
        }

        public int Experience
        {
            get => _experience;
            private set => _experience = value;
        }

        public int Level
        {
            get => _level;
            private set => _level = value;
        }

        public IReadOnlyList<Item> Inventory => _inventory.AsReadOnly();

        public Player(string name) : base(100, 10, name)
        {
            _maxMana = 50;
            _mana = _maxMana;
            _level = 1;
            _experience = 0;
            _inventory = new List<Item>();
        }

        public int Mana => throw new NotImplementedException();

        public override void Attack(Character target)
        {
            var rand = new Random();
            var baseDamage = Strenght;

            if (_equipableWeapon  != null && _equipableWeapon is _equipableWeapon weapon)
            {
                baseDamage += weapon.Damage;

            }

            var isCritical = rand.Next(100) < 20;
            var damage = isCritical ? baseDamage * 2 : baseDamage;

            if (isCritical)
            {
                Console.WriteLine($"КРИТИЧНИЙ УДАР! {Name} завдає {damage} пошкоджень {target.Name}!");
            }
            else
            {
                Console.WriteLine($"{Name} атакує {target.Name} і завдає {damage} пошкоджень!");
            }

            target.TakeDamage(damage);

        }
        public void CastSpell(Character target)
        {
            throw new NotImplementedException();
        }

        public void RestoreMana(int amount)
        {
            throw new NotImplementedException();
        }
    }

    public class Player
    {
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

            if (equippedWeapon != null)
            {
                Console.WriteLine($"🗡️  Зброя: {equippedWeapon.Name}");
            }

            Console.WriteLine($"━━━━━━━━━━━━━━━━━━━━━━━━━━━━\n");
        }

        public void ShowInventory()
        {
            Console.WriteLine("\n📦 ІНВЕНТАР:");

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

            Console.WriteLine();
        }
    }
    public abstract class Enemy : Character
    {
        private int _experienceReward;
        private List<Item> _loot;

        public int ExperienceReward
        {
            get => _experienceReward;
            set => _experienceReward = value;
        }

        protected Enemy(int health, int strenght, string name, int experienceReward) : base(health, strenght, name)
        {
            _experienceReward = experienceReward;
            _loot = new List<Item>();
        }

        protected void AddLoot(Item item)
        {
            return new List<Item>(_loot);   
        }
    public abstract class Character
    {
        private int _health;
        private int _maxHealth;
        private int _strength;
        private int _name;
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
