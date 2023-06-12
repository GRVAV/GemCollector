using GemCollector.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemCollector.Scenes_and_Components
{
    public class HelpScene : GameScene
    {
        SpriteBatch spriteBatch;



        public HelpScene(Game1 game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.SpriteBatch;


        }

        public override void Draw(GameTime gameTime)
        {

            spriteBatch.Begin();

            spriteBatch.Draw(SharedVars.helpScene,
                             SharedVars.background_rect,
                             Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
