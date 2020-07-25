using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RBWhitakerLibrary
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //TwoDimensionTutorial twoDimTutObject;
        //ThreeDimensionTutorial threeDimTutObject;
        





        public Game1()
        {
            // 0,0 is in the top left
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // http://rbwhitaker.wikidot.com/changing-the-window-size
            graphics.PreferredBackBufferWidth = 1280;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 720;   // set this value to the desired height of your window
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            

            base.Initialize();
        }


        protected override void LoadContent()
        {            
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //twoDimTutObject = new TwoDimensionTutorial(this);
            //threeDimTutObject = new ThreeDimensionTutorial(this);
        }


        protected override void UnloadContent()
        {

        }
            

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            //twoDimTutObject.update();
            //threeDimTutObject.update();

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);


            //twoDimTutObject.draw(spriteBatch);
            //threeDimTutObject.draw();


            base.Draw(gameTime);
        }




    }
}


