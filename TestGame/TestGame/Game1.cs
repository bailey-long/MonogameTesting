using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using TestGame.Creature_Classes;

namespace TestGame
{
    public class Game1 : Game
    {
        //setup pigs
        List<Pig> pigs = new List<Pig>
            {
                new Pig(8, 90, false, 0, 0),
                new Pig(10, 100, false, 0, 0),
                new Pig(13, 300, true, 3, 5)
            };
        //get random to allow for rng later
        Random rnd = new Random();

        Texture2D piggy; // define 2dtexture for orcish idol
        Vector2 idolPosition; // postion of player
        float piggySpeed; // speed of movement
        SpriteEffects flip = SpriteEffects.FlipHorizontally; // to flip the model if it moves left or right

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() // ran at start of game
        {
            // TODO: Add your initialization logic here
            //idolPosition = new Vector2(rnd.Next(0, 800), rnd.Next(0, 800)); // Sets position based on aspect ratio of screen
            piggySpeed = 100f;

            base.Initialize();
        }

        protected override void LoadContent() // ran at start of game use to load content as name suggests
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            piggy = Content.Load<Texture2D>("Sprites/piggy");
        }

        protected override void Update(GameTime gameTime) // runs every frame
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();
            //keyboard logic
            if (kstate.IsKeyDown(Keys.Up))
            {
                idolPosition.Y -= piggySpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Down))
            {
                idolPosition.Y += piggySpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Left))
            {
                idolPosition.X -= piggySpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                flip = SpriteEffects.FlipHorizontally;
            }
            if (kstate.IsKeyDown(Keys.Right))
            {
                idolPosition.X += piggySpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                flip = SpriteEffects.None;
            }
            // Press space to make the pig squeal
            if (kstate.IsKeyDown(Keys.Space))
            {
                //p1.Squeal();
            }
            // set boundries to the icon so that it can not leave the game window
            if (idolPosition.X > _graphics.PreferredBackBufferWidth - piggy.Width / 2)
            {
                idolPosition.X = _graphics.PreferredBackBufferWidth - piggy.Width / 2;
            } else if (idolPosition.X < piggy.Width / 2)
            {
                idolPosition.X = piggy.Width / 2;
            }
            //again for the Y axis
            if (idolPosition.Y > _graphics.PreferredBackBufferHeight - piggy.Height / 2)
            {
                idolPosition.Y = _graphics.PreferredBackBufferHeight - piggy.Height / 2;
            }
            else if (idolPosition.Y < piggy.Height / 2)
            {
                idolPosition.Y = piggy.Height / 2;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) // runs every frame, use to draw content to screen
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            foreach (Pig Pig in pigs) {
                _spriteBatch.Draw( // draw the sprite with added parameters
                    piggy, // sprite reference
                    new Vector2(rnd.Next(0, 800), rnd.Next(0, 800)), // co-ordinates to draw
                    null, // Rectangle ?
                    Color.White, // color for sprite, white to leave as is
                    0f, // rotation
                    new Vector2(piggy.Width / 2, piggy.Height / 2), // define sprite origin as center of image
                    1.5f, // image scale
                    flip, // any sprite effects
                    0f // sprite depth
                    );
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}