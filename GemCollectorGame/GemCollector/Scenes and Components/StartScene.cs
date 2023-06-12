using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GemCollector.Animations;
using GemCollector.Models;
using Microsoft.Xna.Framework.Input;
using System.Configuration;

namespace GemCollector.Scenes_and_Components
{
    public class StartScene :GameScene
    {
        SpriteBatch _spriteBatch;

        private List<Player> players;

        private List<Gem> gems;

        private List<wheelWeapon> wheels;

        private Gem _gem;

        private ScoreCounter _scoreCounter;

        private wheelWeapon _wheel;

        private GameOverScene _gameOverScene;



        public StartScene(Game game) : base(game)
        {
            Game1 g = (Game1)game;
            this._spriteBatch = g.SpriteBatch;

            var playerMovements = new Dictionary<string, Animation>()
            {
                {"walkUp",new Animation(SharedVars.WalkingUp,9)},
                {"walkDown",new Animation(SharedVars.WalkingDown,9)},
                {"walkLeft",new Animation(SharedVars.WalkingLeft,9)},
                {"walkRight",new Animation(SharedVars.WalkingRight,9)}
            };

            players = new List<Player>()
            {
                new Player(playerMovements)
                {
                    Position = new Vector2(SharedVars.background.X/2,SharedVars.background.Y/2),
                    Input = new Input
                    {
                        Up = Keys.Up,
                        Down = Keys.Down,
                        Left = Keys.Left,
                        Right = Keys.Right,
                        Tab= Keys.Tab,
                        Space= Keys.Space,
                    }

                }
            };


            gems = new List<Gem>()
            {
                {_gem = new Gem(game){GemPos =new Vector2(415,200)} },

                {new Gem(game){GemPos =new Vector2(390,190)} },

                {new Gem(game){GemPos =new Vector2(250,300)} },


            };


            foreach (var gem in gems)
            {
                this.Components.Add(gem);
            }

            _scoreCounter = new ScoreCounter(game);

            this.Components.Add(_scoreCounter);


            wheels = new List<wheelWeapon>()
            {
                { _wheel = new wheelWeapon(game) },
            };

            if (_scoreCounter.Score > 400)
            {
                wheels.Add(new wheelWeapon(game)
                {
                    WheelPos = new Vector2(
                                   SharedVars.background_rect.X,
                                   new Random().Next(50, 360))
                                   
                });

            }


            foreach (var wheel in wheels)
            {
                this.Components.Add(wheel);
            }

            _gameOverScene = new GameOverScene(game);

            g.Components.Add(_gameOverScene);

            _gameOverScene.hide();


        }

        public override void Update(GameTime gameTime)
        {

            foreach(var movement in players)
            {
                foreach(var gem in gems)
                {
                    foreach(var wheel in wheels)
                    {
                        wheel.Update(gameTime);
                        movement.Update(gameTime, players);

                        Rectangle playerRect = movement.getBounds();

                        Rectangle gemRect = gem.getBounds();

                        Rectangle weaponRect = _wheel.getBounds();



                        if (playerRect.Intersects(gemRect))
                        {
                            _scoreCounter.Score += 10;

                            _gameOverScene.Score = _scoreCounter.Score;

                            Vector2 randpos = new Vector2(
                               new Random().Next(20, 780),
                                new Random().Next(20, 460)
                                );
                            if (randpos != gem.GemPos)
                            {
                                gem.GemPos = randpos;

                                gem.Update(gameTime);
                                wheel.Update(gameTime);
                            }


                        }

                        if (playerRect.Intersects(weaponRect))
                        {

                            _scoreCounter.Health -= 15;

                            Vector2 randpos = new Vector2(
                              SharedVars.background_rect.X,
                                new Random().Next(60, 440)
                                );
                            if (randpos != wheel.WheelPos)
                            {
                                wheel.WheelPos = randpos;

                                gem.Update(gameTime);
                                wheel.Update(gameTime);
                            }
                            else
                            {
                                randpos = new Vector2(
                                new Random().Next(20, 780),
                                new Random().Next(20, 460)
                                );

                                wheel.WheelPos = randpos;

                                gem.Update(gameTime);
                                wheel.Update(gameTime);
                            }
                        }
                    }
                }
            }
            
            if(_scoreCounter.Health <= 0)
            {
                _gameOverScene.show();
                this.hide();   
            }

        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            _spriteBatch.Draw(SharedVars.GameBg,
                              SharedVars.background_rect,
                              Color.White
                              );

            foreach(var movement in players)
            {

                movement.Draw(_spriteBatch);


            foreach(var wheel in wheels)
            {

                if (_scoreCounter.Score >0 && _scoreCounter.Score < 50)
                {
                    wheel.WheelPos = new Vector2(0, 0);
                }
                else if(_scoreCounter.Score >= 50 && (_scoreCounter.Score < 100))
                {
                    wheel.Draw(_spriteBatch);
                }
                else if(_scoreCounter.Score >=100 && _scoreCounter.Score < 180)
                {
                    wheel.Speed = 2.0f;
                    wheel.Draw(_spriteBatch);

                }
                else if(_scoreCounter.Score >= 180 && _scoreCounter.Score < 250)
                {
                    wheel.Speed = 2.5f;
                    wheel.Draw(_spriteBatch);
                }
                else if (_scoreCounter.Score >= 250 && _scoreCounter.Score < 400)
                {
                    wheel.Speed = 2.5f;
                    wheel.Draw(_spriteBatch);
                }else if(_scoreCounter.Score >= 400  && _scoreCounter.Score <500)
                {
                    wheel.Speed = 2.5f;
                    wheel.Draw(_spriteBatch);
                }
                else if (_scoreCounter.Score >= 500)
                {
                    wheel.Speed += 0.002f;
                    wheel.Draw(_spriteBatch);
                }

            }

            }


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
