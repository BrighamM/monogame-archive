using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MechFighter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private float frameRate;

        int frameCounter;


        Texture2D background;
        /*
        GamePadState gamePadState;

       
        Rectangle someRectangle;
        bool still;

        private SuperMarioManager marioManager;
        */

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // http://rbwhitaker.wikidot.com/changing-the-window-size
            graphics.PreferredBackBufferWidth = 1280;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 720;   // set this value to the desired height of your window
            graphics.ApplyChanges();

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            //still = false;
            //someRectangle = new Rectangle(0,0,16,24);
            //frameCounter = 0;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            background = Content.Load<Texture2D>("PossibleContent/bg1");



            //marioManager = new SuperMarioManager(Content.Load<Texture2D>("PossibleContent/53664trans"));



            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //gamePadState = GamePad.GetState(PlayerIndex.One);

            frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;
            frameCounter++;
            // TODO: Add your update logic here

            /*
            if (gamePadState.DPad.Left == ButtonState.Pressed)
            {
                marioManager.marioUpdater();
            }
            else
            {

            }
            */


            //theMarioTextureMap.Thext = 


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            this.Window.Title = "MechFighter FPS: " + frameRate.ToString();

            // TODO: Add your drawing code here

            spriteBatch.Begin(SpriteSortMode.Deferred,BlendState.AlphaBlend, SamplerState.PointClamp,null, null, null, null);
            spriteBatch.Draw(background, new Rectangle(0,0,512,640), Color.White);

            // spriteBatch.Draw(background, new Rectangle(512, 0, 512, 640), null, Color.White, 0.0f, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
            
            
            //spriteBatch.Draw(marioManager.getMarioSpriteMap(), new Rectangle(100, 100, 160, 240),marioManager.currentMarioRectangleFrame, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}



/**
 * Here is where I lay out my first stage deliverables
 * 
 * 1. little mario must move left with left button, and right with right button
 * 
 * 
 */
