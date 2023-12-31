﻿using GemCollector.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//using SharpDX.Direct2D1;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemCollector.Scenes_and_Components
{
    public class MenuComponent : DrawableGameComponent
    {
        SpriteBatch _spriteBatch;
        SpriteFont _selected;
        Color _selectedColor;
        SpriteFont _notSelected;
        Color _notSelectedColor;
        int _selectedIndex;
        string[] menuItems;
        Vector2 _position;
        KeyboardState _oldState;

        //ADDED
        public int SelectedIndex { get { return _selectedIndex; } }
        public MenuComponent(Game game, SpriteBatch spriteBatch, SpriteFont selected,
            SpriteFont notSelected, int selectedIndex, string[] menuItems) : base(game)
        {
            _spriteBatch = spriteBatch;
            _selected = selected;
            _notSelected = notSelected;
            _selectedIndex = selectedIndex;
            this.menuItems = menuItems;
            _selectedColor = Color.White;
            _notSelectedColor = Color.Gray;
            _position = new Vector2(SharedVars.background.X / (35 / 10), SharedVars.background.Y / (35 / 10));

        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 initPos = _position;
            _spriteBatch.Begin();
            for (int i = 0; i < menuItems.Length; i++)
            {
                if (i == _selectedIndex)
                {
                    _spriteBatch.DrawString(_selected, menuItems[i], initPos, _selectedColor);
                    initPos.Y += _selected.LineSpacing;

                }
                else
                {
                    _spriteBatch.DrawString(_notSelected, menuItems[i], initPos, _notSelectedColor);
                    initPos.Y += _notSelected.LineSpacing;

                }

            }

            _spriteBatch.End();
            base.Draw(gameTime);

        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Down) && _oldState.IsKeyUp(Keys.Down))
            {
                _selectedIndex += 1;
                if (_selectedIndex == menuItems.Length)
                {
                    _selectedIndex = 0;
                }
            }

            if (ks.IsKeyDown(Keys.Up) && _oldState.IsKeyUp(Keys.Up))
            {
                _selectedIndex -= 1;
                if (_selectedIndex == -1)
                {
                    _selectedIndex = menuItems.Length - 1;
                }
            }
            _oldState = ks;

            base.Update(gameTime);
        }
    }
}
