using GemCollector.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GemCollector.Animations
{
  public class PlayerAnimationManager
  {
    private Animation _animation;

    private float _timer;

        private Rectangle playerRect;


        public Vector2 Position { get; set; }
        
   public Rectangle PlayerRect { get => playerRect; set => playerRect = value; }


    public PlayerAnimationManager(Animation animation)
    {
      _animation = animation;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
            PlayerRect = new Rectangle(_animation.CurrentFrame * _animation.FrameWidth,
                                         0,
                                         _animation.FrameWidth,
                                         _animation.FrameHeight);

            spriteBatch.Draw(_animation.Texture,
                       Position,
                      PlayerRect,
                       Color.White);

    }

    public void Play(Animation animation)
    {
      if (_animation == animation)
        return;

      _animation = animation;

      _animation.CurrentFrame = 0;


      _timer = 0;
    }

    public void Stop()
    {
      _timer = 0f;

      _animation.CurrentFrame = 0;
    }

    public void Update(GameTime gameTime)
    {
      _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;


      if(_timer > _animation.FrameSpeed)
      {
        _timer = 0f;

        _animation.CurrentFrame++;

        if (_animation.CurrentFrame >= _animation.FrameCount)
          _animation.CurrentFrame = 0;
      }
    }
  }
}
