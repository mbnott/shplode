using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using shplode.Classes;
using shplode.Classes.GameElements;
using shplode.Classes.Pathing;
using shplode.Classes.GameElements.Stats;
using System.Collections.Generic;

namespace shplode
{
    public class ShplodeGame : Game
    {
        // GRAPHICS
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private readonly Dictionary<string, Texture2D> _textures;

        // CONSTANTS
        const int GameWidth = 1000;
        const int GameHeight = 1000;

        // CONTENT
        private Player _player;
        private List<Enemy> _enemies;
        private List<Log> _logs;
        private bool _showLogs;

        public ShplodeGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _textures = new Dictionary<string, Texture2D>();
            _enemies = new List<Enemy>();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = GameWidth;
            _graphics.PreferredBackBufferHeight = GameHeight;
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
            Path basicPath = new Path(new List<Waypoint>()
            {
                new Waypoint(500, -100, 600),
                new Waypoint(500, 1100)
            });

            // Creating enemies
            _enemies.Add(new Enemy(kamikazeSprite, basicPath, 100, 60));

        }

        protected override void Update(GameTime gameTime)
        {
            // Starting animations (to get rid of later)
            _player.Sprite.Start();
            foreach (var enemy in _enemies) 
                enemy.Sprite.Start();

            // Keyboard inputs
            KeyboardState state = Keyboard.GetState();

            // Player movement
            if (state.IsKeyDown(Keys.W) || state.IsKeyDown(Keys.Up)) _player.Move(Direction.Up);
            if (state.IsKeyDown(Keys.A) || state.IsKeyDown(Keys.Left)) _player.Move(Direction.Left);
            if (state.IsKeyDown(Keys.S) || state.IsKeyDown(Keys.Down)) _player.Move(Direction.Down);
            if (state.IsKeyDown(Keys.D) || state.IsKeyDown(Keys.Right)) _player.Move(Direction.Right);

            // Entity updates
            _player.Update();

            foreach (Enemy enemy in _enemies)
            {
                enemy.Update();
                enemy.Path.Start();
            }

            // Checking collisions
            foreach (Enemy enemy in _enemies)
            {
                if (CollisionManager.CheckCollision(enemy.BoundingBox, _player.BoundingBox))
                {
                    _enemies.Remove(enemy);
                    break;
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            // Drawing background

            // Drawing bullets?

            // Drawing player
            _spriteBatch.Draw(_player.Sprite.GetTexture(), _player.GetRectangle(), _player.Sprite.GetRectangle(), Color.White);

            // Drawing enemies
            foreach (Enemy enemy in _enemies)
                _spriteBatch.Draw(enemy.Sprite.GetTexture(), enemy.GetRectangle(), enemy.Sprite.GetRectangle(), Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}