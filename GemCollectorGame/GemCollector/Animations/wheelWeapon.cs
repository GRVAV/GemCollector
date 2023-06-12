using GemCollector.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using SharpDX.DXGI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemCollector.Animations
{
    public class wheelWeapon :DrawableGameComponent
    {
        private SpriteBatch _spriteBatch;

        private Texture2D _wheelTex;

        private Rectangle wheelTexRect;

        private Vector2 wheelPos;

        private float rotation = 2.41f;

        private const float ROTATION_FACTOR = 0.05f;

        private float scale = 1.0f;


        private float speed = 1.5f;

        public float Rotation { get { return rotation; } set { rotation = value; } }

        public float Speed { get { return speed; } set { speed = value; } }

        public Vector2 WheelPos { get { return wheelPos; } set { wheelPos = value; } }

        public wheelWeapon(Game game):base(game) 
        {
            Game1 g = game as Game1;

            this._spriteBatch = g.SpriteBatch;

            _wheelTex = SharedVars.Weapon;

            wheelTexRect = new Rectangle(0, 0, _wheelTex.Width, _wheelTex.Height);

            wheelPos= new Vector2(SharedVars.background_rect.X, 
                                   new Random().Next(50,360)
                                   );

        }

        public override void Update(GameTime gameTime)
        {

            wheelPos.X += speed;

            rotation += ROTATION_FACTOR;


                if(wheelPos.X >= SharedVars.background_rect.Width )
                {
                    wheelPos.X = -speed;
                    wheelPos.Y = new Random().Next(60, 360);

                    if (wheelPos.X <= SharedVars.background_rect.X)
                    {
                        wheelPos.X += speed;
                    }
                }
            

            base.Update(gameTime);
        }

        public virtual void Draw(SpriteBatch _spritebatch)
        {

            _spritebatch.Draw(_wheelTex,
                            wheelPos,
                            wheelTexRect,
                            Color.White,
                            rotation,
                            new Vector2(_wheelTex.Width / 2, _wheelTex.Height / 2),
                            scale,
                            SpriteEffects.None,
                            0);
            



        }

        public Rectangle getBounds()
        {
            return new Rectangle((int)wheelPos.X, (int)wheelPos.Y, _wheelTex.Width, _wheelTex.Height);
        }
    }
}
