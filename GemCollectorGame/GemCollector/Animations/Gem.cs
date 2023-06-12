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
    public class Gem : DrawableGameComponent
    {
        private SpriteBatch _spriteBatch;

        private Texture2D _texture;

        private Rectangle _gemRect;

        private Vector2 gemPos;

        public Gem(Game game) :base(game)
        {
            Game1 g = (Game1)game;

            this._spriteBatch = g.SpriteBatch;

            _texture = SharedVars.gem;

            _gemRect = new Rectangle(0,0,30,25);


        }

        public Vector2 GemPos { get => gemPos; set => gemPos = value; }
        public Rectangle GemRect { get => _gemRect; set => _gemRect = value; }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            _spriteBatch.Draw(_texture, gemPos, _gemRect, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public Rectangle getBounds()
        {
            return new Rectangle((int)gemPos.X,(int)gemPos.Y,_texture.Width,_texture.Height);
        }
    }
}
