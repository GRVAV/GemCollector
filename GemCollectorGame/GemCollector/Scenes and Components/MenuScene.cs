using GemCollector;
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
    public class MenuScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private MenuComponent menuComponent;
        private string[] menuItems = { "Start", "Game Master", "Help", "About", "Exit" };
        public MenuComponent MenuComponent { get => menuComponent; }
        private Texture2D tex;

        public MenuScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this.spriteBatch = g.SpriteBatch;
            SpriteFont font1 = g.Content.Load<SpriteFont>("Fonts/highLightedFont");
            SpriteFont font2 = g.Content.Load<SpriteFont>("Fonts/regularFont");
            tex = g.Content.Load<Texture2D>("Images/menubg2");
            menuComponent = new MenuComponent(g, spriteBatch, font1, font2, 0, menuItems);
            Components.Add(menuComponent);
        }

        public override void Draw(GameTime gameTime)
        {
            Rectangle rect = SharedVars.background_rect;

            spriteBatch.Begin();

            spriteBatch.Draw(tex, rect, Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
