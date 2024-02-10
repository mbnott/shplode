using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using shplode.Classes;
using System.Collections.Generic;

namespace shplode
{
    public class ShplodeGame : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private readonly Dictionary<string, Texture2D> _textures;
        private Player _player;
        private Enemy _enemy;

        public ShplodeGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _textures = new Dictionary<string, Texture2D>();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 1000;
            _graphics.PreferredBackBufferHeight = 1000;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Loading textures
            _textures.Add("shploder", Content.Load<Texture2D>("shploder"));
            _textures.Add("kamikaze", Content.Load<Texture2D>("kamikaze"));

            // Creating Sprites
            Sprite playerSprite = new Sprite(_textures["shploder"], 5, 10);
            Sprite kamikazeSprite = new Sprite(_textures["kamikaze"], 5, 10);

            // Creating entities
            _player = new Player(playerSprite, 500, 800, 50, 50, 5);

            // Creating enemy paths
            EnemyPath basicPath = new EnemyPath(new List<EnemyWaypoint>()
            {
                new EnemyWaypoint(500, -100, 600),
                new EnemyWaypoint(500, 1100)
            });

            // Creating enemies
            _enemy = new Enemy(kamikazeSprite, basicPath, 100, 60);

        }

        protected override void Update(GameTime gameTime)
        {
            // Starting animations (to get rid of later)
            _player.Sprite.Start();
            _enemy.Sprite.Start();

            // Keyboard inputs
            KeyboardState state = Keyboard.GetState();

            // Kinda wish there was a better way to do this
            if (state.IsKeyDown(Keys.W) || state.IsKeyDown(Keys.Up)) _player.Move(Direction.Up);
            if (state.IsKeyDown(Keys.A) || state.IsKeyDown(Keys.Left)) _player.Move(Direction.Left);
            if (state.IsKeyDown(Keys.S) || state.IsKeyDown(Keys.Down)) _player.Move(Direction.Down);
            if (state.IsKeyDown(Keys.D) || state.IsKeyDown(Keys.Right)) _player.Move(Direction.Right);

            // Entity updates
            _player.Update();

            _enemy.Path.Start();
            _enemy.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            // Drawing background


            // Drawing bullets?

            // Drawing player
            _spriteBatch.Draw(_player.Sprite.GetTexture(), _player.GetPosition(), _player.Sprite.GetRectangle(), Color.White);

            // Drawing enemies
            _spriteBatch.Draw(_enemy.Sprite.GetTexture(), _enemy.GetPosition(), _enemy.Sprite.GetRectangle(), Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}