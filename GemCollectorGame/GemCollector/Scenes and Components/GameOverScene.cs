using GemCollector.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace GemCollector.Scenes_and_Components
{
    public class GameOverScene :GameScene  
    {
        SpriteBatch spriteBatch;


        private string gameOver;

        public int Score { get; set; }

        private MenuScene _menuScene;


        public GameOverScene(Game game ):base(game)
        {
            Game1 g = (Game1)game;

            this.spriteBatch = g.SpriteBatch;

            _menuScene = new MenuScene(g);

            g.Components.Add( _menuScene );

            _menuScene.hide();

        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();

            if(ks.IsKeyDown(Keys.Escape))
            {
                _menuScene.show();
                this.hide();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            gameOver = "Game Over \n" + "Score : " + Score;


            string msg2 = "Press Esc to Exit";

            spriteBatch.Draw(SharedVars.blackbg, SharedVars.background_rect, Color.Black);

            spriteBatch.DrawString(SharedVars.highLightedFont,
                                        gameOver,
                                        new Vector2(SharedVars.background_rect.Width / 3,
                                                    SharedVars.background_rect.Height / 3),
                                        Color.Red,
                                        0,
                                        Vector2.Zero,
                                        2,
                                        SpriteEffects.None,
                                        0);

            spriteBatch.DrawString(SharedVars.regularFont,
                                    msg2,
                                    new Vector2(0, SharedVars.background_rect.Height-35 ),
                                    Color.Red,
                                    0,
                                        Vector2.Zero,
                                        0.5f,
                                        SpriteEffects.None,
                                        0);

            spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
