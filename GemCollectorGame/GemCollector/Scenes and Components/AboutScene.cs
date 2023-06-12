using GemCollector.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemCollector.Scenes_and_Components
{
    public class AboutScene : GameScene
    {
        SpriteBatch spriteBatch;


        string text = "Group Members : ";

        string gourav = "GOURAV KUMAR AVALA - 8804292 ";

        string dona = "DONA ANNA JOJO - 8732301";

        string displayString;

        public AboutScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;

            this.spriteBatch = g.SpriteBatch;

        }
        public override void Draw(GameTime gameTime)
        {
            displayString = text + "\n\n\n" +
                             dona + "\n\n" +
                             gourav;
            spriteBatch.Begin(0);

            spriteBatch.Draw(SharedVars.blackbg, SharedVars.background_rect, Color.Black);


            spriteBatch.DrawString(SharedVars.highLightedFont,
                                        displayString,
                                        new Vector2(SharedVars.background_rect.Width / 4,
                                                    SharedVars.background_rect.Height / 4),
                                        Color.Silver,
                                        0,
                                        Vector2.Zero,
                                        1,
                                        SpriteEffects.None,
                                        0);


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
