using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using TestGame.Creature_Classes;

namespace TestGame
{
    public class Game1 : Game
    {
        // get random to allow for rng later
        Random rnd = new Random();
        // referece for SpriteEffects
        SpriteEffects flip;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // setup pigs
        List<Pig> pigs = new List<Pig>
            {
                new Pig(8, "Piggy", 90, false, 0, 0),
                new Pig(10, "John", 100, false, 0, 0),
                new Pig(13, "Clarice", 300, true, 3, 5),
                new Pig(13, "Ficher", 300, true, 3, 5),
                new Pig(13, "Napoleon", 300, true, 3, 5),
                new Pig(13, "Skotizo", 300, true, 3, 5),
                new Pig(13, "Vorky", 300, true, 3, 5),
                new Pig(15, "Poglin", 100, false, 0, 0),
            };
        // Create dictionaries to hold the spawn points and orientation of the pigs.
        Dictionary<Pig, Vector2> pigSpawnPoints = new Dictionary<Pig, Vector2>();
        Dictionary<Pig, SpriteEffects> pigOrientation = new Dictionary<Pig, SpriteEffects>();
        Texture2D piggy; // define 2dtexture for the pig

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() // ran at start of game
        {
            // TODO: Add your initialization logic here
            foreach (Pig pig in pigs)
            {
                // Define the spawn points for each pig and add it to the dictionary to be called in the draw function.
                Vector2 spawnPoint = new Vector2(rnd.Next(0, 1100), rnd.Next(0, 640));
                // Randomly choose the direction of each pig
                int direction = rnd.Next(0, 2);
                // add pig direction to dictionary
                if (direction == 0)
                {
                    flip = SpriteEffects.FlipHorizontally;
                    pigOrientation.Add(pig, flip);
                } else
                {
                    flip = SpriteEffects.None;
                    pigOrientation.Add(pig, flip);
                }
                // add pig spawnpoint to dictionary
                pigSpawnPoints.Add(pig, spawnPoint);
            }
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
            var mouseState = Mouse.GetState();
            var mousePoint = new Point(mouseState.X, mouseState.Y);
            var rectangle = new Rectangle(mousePoint.X, mousePoint.Y, this.piggy.Width, this.piggy.Height);

            if (rectangle.Contains(mousePoint))
            {
                Debug.WriteLine(this.piggy.Width);
            }
            

            //Hover over pig with mouse cursor
            /*foreach(Pig pig in pigs)
            {
                Vector2 pigSpawnPoint;
                if (mState.Position(pigSpawnPoint))
                {

                }
            }*/


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) // runs every frame, use to draw content to screen
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            // draw pigs first frame.
                // Instantiate each pig from the list
                foreach (Pig Pig in pigs)
                {
                    Vector2 pigSpawnPoint;
                    if (pigSpawnPoints.TryGetValue(Pig, out pigSpawnPoint) && pigOrientation.TryGetValue(Pig, out flip))
                    {
                        _spriteBatch.Draw( // draw the sprite with added parameters
                            piggy, // sprite reference
                            pigSpawnPoint, // co-ordinates to draw
                            null, // Rectangle ?
                            Color.White, // color for sprite, white to leave as is
                            0f, // rotation
                            new Vector2(piggy.Width / 2, piggy.Height / 2), // define sprite origin as center of image
                            1.5f, // image scale
                            flip, // any sprite effects
                            0f // sprite depth
                            );
                    }
                }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}