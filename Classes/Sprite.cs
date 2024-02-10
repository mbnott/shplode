using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace shplode.Classes
{
    public class Sprite
    {
        private readonly Texture2D _texture;
        private int _currentFrame;
        private readonly int _frameWidth;
        private readonly int _totalFrames;
        private readonly int _interval;
        private int _currentInterval;
        private bool _active;

        public Sprite(Texture2D texture, int totalFrames, int interval = 1)
        {
            _texture = texture;
            _currentFrame = 0;
            _totalFrames = totalFrames;
            _frameWidth = _texture.Width / totalFrames;
            _active = false;
            _interval = interval;
            _currentInterval = 0;
        }

        /// <summary>
        /// Skips to the next frame, goes back to 0 if last frame
        /// </summary>
        public void Update()
        {
            if (_active)
            {
                // First check if the interval is done
                if (_currentInterval < _interval)
                    _currentInterval++;
                else
                {
                    _currentInterval = 0;

                    // Change frame if interval done
                    if (_currentFrame < _totalFrames - 1)
                        _currentFrame++;
                    else 
                        _currentFrame = 0;
                }
            }
        }

        /// <summary>
        /// Returns a rectangle that represents the location of the current frame this sprite is on, based on its spritesheet
        /// </summary>
        /// <returns></returns>
        public Rectangle GetRectangle()
        {
            return new Rectangle(_frameWidth * _currentFrame, 0, _frameWidth, _texture.Height);
        }

        public Texture2D GetTexture()
        {
            return _texture;
        }

        public void Start()
        {
            _active = true;
        }

        public void Stop()
        {
            _active = false;
        }
    }
}
