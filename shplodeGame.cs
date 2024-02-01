using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using shplode.Classes;
using System;
using System.Collections.Generic;

namespace shplode
{
    public class shplodeGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Dictionary<string, Texture2D> _textures;
        private Player _player;

        public shplodeGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _textures = new Dictionary<string, Texture2D>();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 1200;
            _graphics.PreferredBackBufferHeight = 800;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Loading textures
            _textures.Add("shploder", Content.Load<Texture2D>("shploder"));

            // Creating Sprites
            Sprite playerSprite = new Sprite(_textures["shploder"], 5, 100, 100, 10);

            // Creating entities
            _player = new Player(playerSprite, 20, 20, 50, 50, 10);
        }

        protected override void Update(GameTime gameTime)
        {
            // Use once
            _player.Sprite.Start();

            // Keyboard inputs
            KeyboardState state = Keyboard.GetState();

            // Kinda wish there was a better way to do this
            if (state.IsKeyDown(Keys.W)) _player.Move(Direction.Up);
            if (state.IsKeyDown(Keys.A)) _player.Move(Direction.Left);
            if (state.IsKeyDown(Keys.S)) _player.Move(Direction.Down);
            if (state.IsKeyDown(Keys.D)) _player.Move(Direction.Right);

            // Object updates
            _player.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            _spriteBatch.Draw(_player.Sprite.GetTexture(), _player.GetPosition(), _player.Sprite.GetRectangle(), Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}