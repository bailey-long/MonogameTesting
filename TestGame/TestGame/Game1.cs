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
        public Texture2D enemy;
        //load player object
        Player player;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        //! ran at start of game
        protected override void Initialize()
        {
            base.Initialize();
        }

        //! ran at start of game use to load content as name suggests
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //load font
            font = Content.Load<SpriteFont>("Text");
            playerModel = Content.Load<Texture2D>("Sprites/player1");
            //create player
            player = new Player(1, 1, 0, 10, 10, 10, 0, 2.0f, 2.0f);
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // TODO: Add your update logic here
            KeyboardState keyboardState = Keyboard.GetState();
            player.Move(keyboardState);
        }
        //! runs every frame, use to draw content to screen
        protected override void Draw(GameTime gameTime)
        {
            //Screen background colour
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(player.Sprite, player.Position, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}