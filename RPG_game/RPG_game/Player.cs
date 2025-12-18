using static RPG_game.Enemy;

namespace RPG_game
{
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
