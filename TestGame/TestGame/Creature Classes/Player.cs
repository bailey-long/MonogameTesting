using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGame.Creature_Classes
{
    internal class Player
    {
        private int playerClass;
        private int level;
        private int xp;
        private int xpToNextLevel;
        private int maxHealth;
        private int currentHealth;
        private int gold;
        private float moveSpeed;
        private float attackSpeed;

        public Player(int playerClass, int level, int xp, int xpToNextLevel, int maxHealth, int currentHealth,
            int gold, float moveSpeed, float attackSpeed)
        {
            this.playerClass = playerClass;
            this.level = level;
            this.xp = xp;
            this.xpToNextLevel = xpToNextLevel;
            this.maxHealth = maxHealth;
            this.currentHealth = currentHealth;
            this.gold = gold;
            this.moveSpeed = moveSpeed;
            this.attackSpeed = attackSpeed;
        }
        //sprite and position stats
        public Vector2 Position { get; set; }
        public Texture2D Sprite { get; set;}
        public int PlayerClass
        {
            get { return playerClass; }
            set { playerClass = value; }
        }
        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        public int XP
        {
            get { return xp; }
            set { xp = value; }
        }
        public int XPToNextLevel
        {
            get { return xpToNextLevel; }
            set { xpToNextLevel = value; }
        }
        public int MaxHealth
        {
            get { return maxHealth; }
            set { maxHealth = value; }
        }
        public int CurrentHealth
        {
            get { return currentHealth; }
            set { currentHealth = value; }
        }
        public int Gold
        {
            get { return gold; }
            set { gold = value; }
        }
        public float MoveSpeed
        {
            get { return moveSpeed; }
            set { moveSpeed = value; }
        }
        public float AttackSpeed
        {
            get { return attackSpeed; }
            set { attackSpeed = value; }
        }
        //Methods
        public void Move(KeyboardState keyboardState)
        {
            // Calculate the movement vector
            Vector2 movement = Vector2.Zero;

            if (keyboardState.IsKeyDown(Keys.W))
                movement.Y -= moveSpeed;
            if (keyboardState.IsKeyDown(Keys.S))
                movement.Y += moveSpeed;
            if (keyboardState.IsKeyDown(Keys.A))
                movement.X -= moveSpeed;
            if (keyboardState.IsKeyDown(Keys.D))
                movement.X += moveSpeed;

            // Normalize the movement vector to ensure consistent speed in all directions
            if (movement != Vector2.Zero)
                movement.Normalize();

            // Apply movement to the player's position
            Position += movement * MoveSpeed;
        }
    }
}
