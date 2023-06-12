using GemCollector.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GemCollector.Animations
{
  public class Player
  {

    private PlayerAnimationManager _animationManager;

    private Dictionary<string, Animation> _animations;

    private Vector2 _position;


    public Input Input;




    public Vector2 Position
    {
      get { return _position; }
      set
      {
        _position = value;

        if (AnimationManager != null)
          AnimationManager.Position = _position;
      }
    }

        public PlayerAnimationManager AnimationManager { get => _animationManager; set => _animationManager = value; }

        public float Speed = 1.8f;

    public Vector2 Velocity;

        


    public virtual void Draw(SpriteBatch spriteBatch)
    {
            if (AnimationManager != null)
            {

                _animationManager.Draw(spriteBatch);


            }
            else
            {
                throw new Exception("Error in Player Draw");
            }
    }

    public virtual void Move()
    {
      if (Keyboard.GetState().IsKeyDown(Input.Up))
      {
                Velocity.Y = -Speed;
      }
      else if (Keyboard.GetState().IsKeyDown(Input.Down))
       {
                Velocity.Y = Speed;
            }
      else if (Keyboard.GetState().IsKeyDown(Input.Left))
      {
                Velocity.X = -Speed;
      }
      else if (Keyboard.GetState().IsKeyDown(Input.Right))
      {
                Velocity.X = Speed;
            }
    }


    protected virtual void SetAnimations()
    {
      if (Velocity.X > 0)
            {
                _animationManager.Play(_animations["walkRight"]);
            }
      else if (Velocity.X < 0)
            {
                _animationManager.Play(_animations["walkLeft"]);
            }
      else if (Velocity.Y > 0)
            {

                _animationManager.Play(_animations["walkDown"]);
            }
      else if (Velocity.Y < 0)
            {
                _animationManager.Play(_animations["walkUp"]);
            }
      else
            {
                _animationManager.Stop();
            }



    }

    public Player(Dictionary<string, Animation> animations)
    {
      _animations = animations;
      _animationManager = new PlayerAnimationManager(_animations.First().Value);
    
    }

    public virtual void screenBounds()
    {
           if(Position.X <= 0)
           {
                _position.X = SharedVars.background_rect.Width;
           }
           else if(Position.X >= SharedVars.background_rect.Width)
           {
                _position.X = 0;
           }
           else if(Position.Y <= 0)
           {
                _position.Y= SharedVars.background_rect.Height;
           }
           else if(Position.Y >= SharedVars.background_rect.Height)
           {
                _position.Y = 0;
           }
    }

    public virtual void Update(GameTime gameTime, List<Player> sprites)
    {
      Move();


      SetAnimations();

      _animationManager.Update(gameTime);

      Position += Velocity;
      Velocity = Vector2.Zero;

            screenBounds();

    }

        public Rectangle getBounds()
        {
            return new Rectangle((int)Position.X,(int)Position.Y,_animationManager.PlayerRect.Width,_animationManager.PlayerRect.Height);
        }

  }
}
