using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TestGame
{
    public class Game1 : Game
    {
        Texture2D orcish_idol; // define 2dtexture for orcish idol
        Vector2 idolPosition; // postion of player
        float idolSpeed; // speed of movement
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
            idolPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2,
            _graphics.PreferredBackBufferHeight /2); // Sets position based on aspect ratio of screen
            idolSpeed = 100f;

            base.Initialize();
        }

        protected override void LoadContent() // ran at start of game use to load content as name suggests
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            orcish_idol = Content.Load<Texture2D>("Sprites/piggy");
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
                idolPosition.Y -= idolSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Down))
            {
                idolPosition.Y += idolSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            if (kstate.IsKeyDown(Keys.Left))
            {
                idolPosition.X -= idolSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                flip = SpriteEffects.FlipHorizontally;
            }
            if (kstate.IsKeyDown(Keys.Right))
            {
                idolPosition.X += idolSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                flip = SpriteEffects.None;
            }
            // set boundries to the icon so that it can not leave the game window
            if (idolPosition.X > _graphics.PreferredBackBufferWidth - orcish_idol.Width / 2)
            {
                idolPosition.X = _graphics.PreferredBackBufferWidth - orcish_idol.Width / 2;
            } else if (idolPosition.X < orcish_idol.Width / 2)
            {
                idolPosition.X = orcish_idol.Width / 2;
            }
            //again for the Y axis
            if (idolPosition.Y > _graphics.PreferredBackBufferHeight - orcish_idol.Height / 2)
            {
                idolPosition.Y = _graphics.PreferredBackBufferHeight - orcish_idol.Height / 2;
            }
            else if (idolPosition.Y < orcish_idol.Height / 2)
            {
                idolPosition.Y = orcish_idol.Height / 2;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) // runs every frame, use to draw content to screen
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw( // draw the sprite with added parameters
                orcish_idol, // sprite reference
                idolPosition, // co-ordinates to draw
                null, // Rectangle ?
                Color.White, // color for sprite, white to leave as is
                0f, // rotation
                new Vector2 (orcish_idol.Width / 2, orcish_idol.Height / 2), // define sprite origin as center of image
                1.5f, // image scale
                flip, // any sprite effects
                0f // sprite depth
                );
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}