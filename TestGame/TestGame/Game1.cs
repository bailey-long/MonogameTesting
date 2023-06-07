using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Aseprite.Sprites;
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
        //setup graphics
        private SpriteFont font;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        //setup sprites
        public Texture2D playerModel;
        public Texture2D tree;
        List<Vector2> spritePositions = new List<Vector2>();
        public Texture2D enemy;
        //Camera Position
        Vector2 cameraPosition = Vector2.Zero;
        //load player object
        Player player;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.SynchronizeWithVerticalRetrace = false;
            _graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        //! ran at start of game
        protected override void Initialize()
        {
            base.Initialize();
            //generate x,y for environment stuff around screen
            for (int i = 0; i < 2500; i++)
            {
                // Generate random positions within the screen boundaries
                int x = rnd.Next(-7000, 7000);
                int y = rnd.Next(-7000, 7000);

                // Store the position in the list or array
                spritePositions.Add(new Vector2(x, y));
            }

        }

        //! ran at start of game use to load content as name suggests
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //load sprites
            font = Content.Load<SpriteFont>("Text");
            playerModel = Content.Load<Texture2D>("Sprites/player1");
            tree = Content.Load<Texture2D>("Sprites/Environment/tree");

            //create player
            player = new Player(1, 1, 0, 10, 10, 10, 0, 2, 2.0f);
                player.Sprite = playerModel;
                // Calculate the position to center the player model
                player.Position = new Vector2(
                (GraphicsDevice.Viewport.Width - playerModel.Width) / 2,
                (GraphicsDevice.Viewport.Height - playerModel.Height) / 2
                );
        }

        //! runs every frame
        protected override void Update(GameTime gameTime)
        {
            //close game
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //Player movement logic
            KeyboardState keyboardState = Keyboard.GetState();
            player.Move(keyboardState);
            cameraPosition = new Vector2(
                (int)(player.Position.X - GraphicsDevice.Viewport.Width / 2),
                (int)(player.Position.Y - GraphicsDevice.Viewport.Height / 2)
            );
        }

        //! runs every frame, use to draw content to screen
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //Camera transform
            Matrix cameraTransform = Matrix.CreateTranslation(-cameraPosition.X, -cameraPosition.Y, 0);

            _spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, null, null, null, null, cameraTransform);
            // TODO: Add your drawing code here

            //Draw Environment sstuff around game
            foreach (Vector2 position in spritePositions)
            {
                _spriteBatch.Draw(tree, position, Color.White);
            }
            _spriteBatch.Draw(player.Sprite, player.Position, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}