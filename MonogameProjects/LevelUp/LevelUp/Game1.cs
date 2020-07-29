using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/*
 * 
 * Some software to keep in mind... 
 * https://www.mapeditor.org/
 * https://rxi.itch.io/tilekit
 * 
 * 
 * 
 * 
 *      
*/

namespace LevelUp
{


    public class Game1 : Game
    {



        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private float frameRate;

        int frameCounter;

        GamePadState gamePadState;

        
        string myString;

        private SuperMarioManager marioManager;
        private SpriteFont inputFont;

        private PlayerInputManager playerInputManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.GraphicsProfile = GraphicsProfile.HiDef; /*I needed this to import the mario atlas*/
            Content.RootDirectory = "Content";

            // http://rbwhitaker.wikidot.com/changing-the-window-size
            graphics.PreferredBackBufferWidth = 1280;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 720;   // set this value to the desired height of your window
            graphics.ApplyChanges();
        }


        protected override void Initialize()
        {
            base.Initialize();

            frameCounter = 0;

            playerInputManager = new PlayerInputManager(Keyboard.GetState(),
                                                        Mouse.GetState(),
                                                        GamePad.GetState(PlayerIndex.One),
                                                        GamePad.GetState(PlayerIndex.Two),
                                                        GamePad.GetState(PlayerIndex.Three),
                                                        GamePad.GetState(PlayerIndex.Four));
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            marioManager = new SuperMarioManager(Content.Load<Texture2D>("MarioSpriteSheetAtlas/mssa"));

            inputFont = Content.Load<SpriteFont>("Fonts/inputManagerFont");
        }

        protected override void UnloadContent()
        {
            
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            playerInputManager.updateInput(Keyboard.GetState(), 
                                           Mouse.GetState(),
                                           GamePad.GetState(PlayerIndex.One),
                                           GamePad.GetState(PlayerIndex.Two),
                                           GamePad.GetState(PlayerIndex.Three),
                                           GamePad.GetState(PlayerIndex.Four));

            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //{
            //    Exit();
            //}

            frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;
            frameCounter++;
            
            //marioManager.update(playerInputManager);

            base.Update(gameTime);
        }

        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);
            this.Window.Title = "LevelUp FPS: " + frameRate.ToString();

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, null);

            //marioManager.Draw(spriteBatch);

            spriteBatch.DrawString(inputFont, playerInputManager.devOutput().ToString(), new Vector2(100, 100), Color.Black);

            spriteBatch.End();            

            base.Draw(gameTime);
        }
    }
}
