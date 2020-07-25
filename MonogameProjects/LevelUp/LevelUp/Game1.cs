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
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private float frameRate;

        int frameCounter;

        GamePadState gamePadState;


        Rectangle someRectangle;
        string myString;
        bool still;

        private SuperMarioManager marioManager;
        private SpriteFont inputFont;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.GraphicsProfile = GraphicsProfile.HiDef; /*I needed this to import the atlas*/
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
            still = false;
            someRectangle = new Rectangle(0, 0, 16, 24);
            frameCounter = 0;          
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            marioManager = new SuperMarioManager(Content.Load<Texture2D>("MarioSpriteSheetAtlas/mssa"));

            inputFont = Content.Load<SpriteFont>("Fonts/inputManagerFont");

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
            myString = StaticPlayerInputManager.getStatus(Keyboard.GetState(), Mouse.GetState(), GamePad.GetState(1));

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;
            frameCounter++;

            gamePadState = GamePad.GetState(PlayerIndex.One);

            if (gamePadState.DPad.Left == ButtonState.Pressed)
            {
                marioManager.leftWasPressed();
            }
            if(gamePadState.DPad.Right == ButtonState.Pressed)
            {
                marioManager.rightWasPressed();
            }
            marioManager.marioUpdater();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);
            this.Window.Title = "LevelUp FPS: " + frameRate.ToString();

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, null);

            marioManager.Draw(spriteBatch);

            spriteBatch.DrawString(inputFont, myString, new Vector2(100, 100), Color.Black);

            spriteBatch.End();


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
