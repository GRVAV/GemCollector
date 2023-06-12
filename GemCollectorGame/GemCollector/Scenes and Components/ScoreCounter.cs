using GemCollector.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemCollector.Scenes_and_Components
{
    public class ScoreCounter: DrawableGameComponent
    {
        SpriteBatch spriteBatch;

        int score;

        int health = 100;

        Vector2 scorePos;


        string scoreDisplay;



        public ScoreCounter(Game game):base(game)
        {
            Game1 gm = (Game1)(game);

            this.spriteBatch = gm.SpriteBatch;

            scorePos = new Vector2(SharedVars.background_rect.X / 6, SharedVars.background_rect.Y / 6);


        }

        public int Health { get => health; set => health = value; }
        public int Score { get => score; set => score = value; }
        public Vector2 ScorePos { get => scorePos; set => scorePos = value; }

        public string ScoreDisplay { get { return scoreDisplay; } set { scoreDisplay = value; } }

        public string hit { get; set; }

        public override void Draw(GameTime gameTime)
        {
            ScoreDisplay = "Score : " + score + "\n" + "Health : " + health ;

            spriteBatch.Begin();

            spriteBatch.DrawString(SharedVars.ScoreFont,
                                     scoreDisplay,
                                     scorePos,
                                     Color.Brown,
                                     0,
                                     Vector2.Zero,
                                     1.3f,
                                     SpriteEffects.None,
                                     0
                                    );
                
            spriteBatch.End();


            base.Draw(gameTime);
        }


    }
}
