using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using shplode.Classes;
using shplode.Classes.GameElements;
using shplode.Classes.Pathing;
using shplode.Classes.GameElements.Stats;
using System.Collections.Generic;
using shplode.Classes.Logs;
using shplode.Classes.Effects;
using shplode.Classes.GameElements.Projectiles;
using Microsoft.Xna.Framework.Content;

namespace shplode
{
    public class ShplodeGame : Game
    {
        // GRAPHICS
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Dictionary<string, Texture2D> _textures;
        private Dictionary<string, SpriteFont> _fonts;

        // CONSTANTS
        const int GameWidth = 1000;
        const int GameHeight = 1000;

        // CONTENT
        private Player _player;
        private List<Enemy> _enemies;
        private List<Log> _logs;
        private bool _showLogs;

        // BulletsManager, EffectsManager and CollisionManager are also static classes used by the program

        public ShplodeGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _textures = new Dictionary<string, Texture2D>();
            _fonts = new Dictionary<string, SpriteFont>();
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

            // Initializing game managers
            EffectsManager.Initialize();
            BulletsManager.Initialize();

            // Loading textures
            _textures.Add("shploder", Content.Load<Texture2D>("shploder"));
            _textures.Add("kamikaze", Content.Load<Texture2D>("kamikaze"));
            _textures.Add("playerBullet", Content.Load<Texture2D>("playerBullet"));
            _fonts.Add("damageIndicator", Content.Load<SpriteFont>("DamageIndicator"));

            // Creating Sprites
            Sprite playerSprite = new Sprite(_textures["shploder"], 5, 10);
            Sprite kamikazeSprite = new Sprite(_textures["kamikaze"], 5, 10);

            // Creating player
            _player = new Player(playerSprite, 500, 800, 50, 50, new CombatStats(500, 10, 10), 5);

            // Creating paths
            Path basicPath = new Path(new List<Waypoint>()
            {
                new Waypoint(500, -100, 600),
                new Waypoint(500, 1100)
            });

            // Creating enemies
            _enemies.Add(new Enemy(kamikazeSprite, basicPath, 100, 60, new CombatStats(30, 10, 10)));
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
            if (state.IsKeyDown(Keys.Y)) _player.Shoot(_textures["playerBullet"]);

            // Updates
            EffectsManager.Update();
            BulletsManager.Update();
            _player.Update();

            foreach (Enemy enemy in _enemies)
            {
                enemy.Update();
                enemy.Path.Start();
            }

            // Checking collisions and dealing damage
            List<Bullet> bullets = BulletsManager.GetBullets();

            for (int i = 0; i < _enemies.Count; i++) {
                // Maybe i could implement enemies colliding with bullets, idk man my programming skills and logic just can't compute this project anymore
                // I'll just find different ways to restructure the project, and it'll eventually get fixed i hope
                
                // if player itself touches enemy
                if (CollisionManager.CheckCollision(_enemies[i].BoundingBox, _player.BoundingBox))
                {
                    bool isPlayerAlive = _player.Hurt(_enemies[i].Stats.BaseDamage);
                    if (!isPlayerAlive)
                    {
                        this.Exit();
                    }
                    bool isEnemyAlive = _enemies[i].Hurt(_player.Stats.BaseDamage);
                    if (!isEnemyAlive)
                    {
                        _enemies.RemoveAt(i);
                        i--;
                    }
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            // Drawing background
            // TODO

            // Drawing bullets
            foreach (Bullet bullet in BulletsManager.GetBullets())
                _spriteBatch.Draw(bullet.Sprite.GetTexture(), bullet.GetRectangle(), bullet.Sprite.GetRectangle(), Color.White);

            // Drawing player
            _spriteBatch.Draw(_player.Sprite.GetTexture(), _player.GetRectangle(), _player.Sprite.GetRectangle(), Color.White);

            // Drawing enemies
            foreach (Enemy enemy in _enemies)
                _spriteBatch.Draw(enemy.Sprite.GetTexture(), enemy.GetRectangle(), enemy.Sprite.GetRectangle(), Color.White);

            // Drawing Effects
            foreach (DamageIndicator indicator in EffectsManager.GetDamageIndicators())
                _spriteBatch.DrawString(_fonts["damageIndicator"], indicator.Value, indicator.GetLocation(), indicator.GetColor());

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}