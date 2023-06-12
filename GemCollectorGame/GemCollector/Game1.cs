using GemCollector.Models;
using GemCollector.Scenes_and_Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;


namespace GemCollector
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;

        private SpriteBatch _spriteBatch;

        private MenuScene _menuScene;

        private StartScene _startScene;

        private GameMasterScene _gameMasterscene;

        private HelpScene _helpScene;

        private AboutScene _aboutScene;

        public SpriteBatch SpriteBatch { get => _spriteBatch; set => _spriteBatch = value; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            #region SharedVars Initialization
            SharedVars.background = new Vector2(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            SharedVars.background_rect = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            SharedVars.WalkingLeft = Content.Load<Texture2D>("Images/walkingLeft");
            SharedVars.WalkingRight = Content.Load<Texture2D>("Images/walkingRight");
            SharedVars.WalkingUp = Content.Load<Texture2D>("Images/walkingUp");
            SharedVars.WalkingDown = Content.Load<Texture2D>("Images/walkingDown");
            SharedVars.regularFont = Content.Load<SpriteFont>("Fonts/regularFont");
            SharedVars.highLightedFont = Content.Load<SpriteFont>("Fonts/highLightedFont");
            SharedVars.gem = Content.Load<Texture2D>("Images/diamond");
            SharedVars.GameBg = Content.Load<Texture2D>("Images/maingameBg");
            SharedVars.ScoreFont = Content.Load<SpriteFont>("Fonts/scoreCardFont");
            SharedVars.Weapon = Content.Load<Texture2D>("Images/wheel");
            SharedVars.blackbg = Content.Load<Texture2D>("Images/blackscreen");
            SharedVars.gameMaster = Content.Load<Texture2D>("Images/gameMaster");
            SharedVars.helpScene = Content.Load<Texture2D>("Images/helpScene");
            #endregion

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            _menuScene = new MenuScene(this);

            this.Components.Add(_menuScene);

            _startScene = new StartScene(this);

            this.Components.Add(_startScene);

            _gameMasterscene= new GameMasterScene(this);

            this.Components.Add(_gameMasterscene);

            _helpScene = new HelpScene(this);

            this.Components.Add(_helpScene);

            _aboutScene = new AboutScene(this);

            this.Components.Add(_aboutScene);

            Song bgMusic1 = this.Content.Load<Song>("Sounds/background");

            Song bgMusic2 = this.Content.Load<Song>("Sounds/backgroundSoothing");

            MediaPlayer.IsRepeating = true;

            MediaPlayer.Play(bgMusic2);

            _gameMasterscene.hide();
            _helpScene.hide();
            _aboutScene.hide();


            _menuScene.show();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            KeyboardState ks = Keyboard.GetState();

            int index = _menuScene.MenuComponent.SelectedIndex;

            if (_menuScene.MenuComponent.SelectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
            {
                _menuScene.hide();
                _startScene.show();
            }
            else if(_menuScene.MenuComponent.SelectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
            {
                _menuScene.hide();
                _gameMasterscene.show();
            }
            else if (_menuScene.MenuComponent.SelectedIndex == 2 && ks.IsKeyDown(Keys.Enter))
            {
                _menuScene.hide();
                _helpScene.show();
            }
            else if (_menuScene.MenuComponent.SelectedIndex == 3 && ks.IsKeyDown(Keys.Enter))
            {
                _menuScene.hide();
                _aboutScene.show();
            }
            else if (index == 4 && ks.IsKeyDown(Keys.Enter))
            {
                hideAllScenes();
                Exit();
            }
            else if (ks.IsKeyDown(Keys.Escape))
            {
                _menuScene.show();
                _startScene.hide();
            }

            
           


            base.Update(gameTime);
        }

        private void hideAllScenes()
        {
                foreach (GameScene item in Components)
                    item.hide();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}