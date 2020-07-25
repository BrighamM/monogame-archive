using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace RBWhitakerLibrary
{


    class Particle
    {

        public Texture2D Texture { get; set; }        // The texture that will be drawn to represent the particle
        public Vector2 Position { get; set; }        // The current position of the particle        
        public Vector2 Velocity { get; set; }        // The speed of the particle at the current instance
        public float Angle { get; set; }            // The current angle of rotation of the particle
        public float AngularVelocity { get; set; }    // The speed that the angle is changing
        public Color Color { get; set; }            // The color of the particle
        public float Size { get; set; }                // The size of the particle
        public int TTL { get; set; }                // The 'time to live' of the particle


        public Particle(Texture2D texture, Vector2 position, Vector2 velocity,
            float angle, float angularVelocity, Color color, float size, int ttl)
        {
            Texture = texture;
            Position = position;
            Velocity = velocity;
            Angle = angle;
            AngularVelocity = angularVelocity;
            Color = color;
            Size = size;
            TTL = ttl;
        }


        public void Update()
        {
            TTL--;
            Position += Velocity;
            Angle += AngularVelocity;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, Texture.Width, Texture.Height);
            Vector2 origin = new Vector2(Texture.Width / 2, Texture.Height / 2);

            spriteBatch.Draw(Texture, Position, sourceRectangle, Color,
                Angle, origin, Size, SpriteEffects.None, 0f);
        }



    }


    class ParticleEngine
    {
        private Random random;
        public Vector2 EmitterLocation { get; set; }
        private List<Particle> particles;
        private List<Texture2D> textures;

        public ParticleEngine(List<Texture2D> textures, Vector2 location)
        {
            EmitterLocation = location;
            this.textures = textures;
            this.particles = new List<Particle>();
            random = new Random();
        }


        private Particle GenerateNewParticle()
        {
            Texture2D texture = textures[random.Next(textures.Count)];
            Vector2 position = EmitterLocation;
            Vector2 velocity = new Vector2(
                    1f * (float)(random.NextDouble() * 2 - 1),
                    1f * (float)(random.NextDouble() * 2 - 1));
            float angle = 0;
            float angularVelocity = 0.1f * (float)(random.NextDouble() * 2 - 1);
            Color color = new Color(
                    (float)random.NextDouble(),
                    (float)random.NextDouble(),
                    (float)random.NextDouble());
            float size = (float)random.NextDouble();
            int ttl = 200 + random.Next(40);

            return new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl);
        }

        public void Update()
        {
            int total = 20;

            for (int i = 0; i < total; i++)
            {
                particles.Add(GenerateNewParticle());
            }

            for (int particle = 0; particle < particles.Count; particle++)
            {
                particles[particle].Update();
                if (particles[particle].TTL <= 0)
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            for (int index = 0; index < particles.Count; index++)
            {
                particles[index].Draw(spriteBatch);
            }
            spriteBatch.End();
        }




    }








    class TwoDimensionTutorial
    {
        private Texture2D blue;
        private Texture2D green;
        private Texture2D red;
        private Texture2D arrow;
        private Texture2D background;
        private Texture2D shuttle;
        private Texture2D earth;
        private Texture2D circle;
        private Texture2D star;
        private Texture2D diamond;
        private SpriteFont basicFont;
        private Texture2D textureAtlas;
        private ParticleEngine particleEngine;

        private int score;
        private float arrowAngle;
        private float blueAngle;
        private float greenAngle;
        private float redAngle;
        private float blueSpeed;
        private float greenSpeed;
        private float redSpeed;
        private float distance;
        private int Rows;
        private int Columns;
        private int currentFrame;
        private int totalFrames;


        public TwoDimensionTutorial(Game1 currentGame)
        {

            
            this.red = currentGame.Content.Load<Texture2D>("TwoDimensionTutorial/red");
            this.blue = currentGame.Content.Load<Texture2D>("TwoDimensionTutorial/blue");
            this.green = currentGame.Content.Load<Texture2D>("TwoDimensionTutorial/green");
            this.arrow = currentGame.Content.Load<Texture2D>("TwoDimensionTutorial/arrow");
            this.background = currentGame.Content.Load<Texture2D>("TwoDimensionTutorial/stars");
            this.shuttle = currentGame.Content.Load<Texture2D>("TwoDimensionTutorial/shuttle");
            this.earth = currentGame.Content.Load<Texture2D>("TwoDimensionTutorial/earth");
            this.circle = currentGame.Content.Load<Texture2D>("TwoDimensionTutorial/circle");
            this.star = currentGame.Content.Load<Texture2D>("TwoDimensionTutorial/star");
            this.diamond = currentGame.Content.Load<Texture2D>("TwoDimensionTutorial/diamond");
            this.basicFont = currentGame.Content.Load<SpriteFont>("TwoDimensionTutorial/simpleFont");
            this.textureAtlas = currentGame.Content.Load<Texture2D>("TwoDimensionTutorial/SmileyWalk");


            arrowAngle = 0;
            blueAngle = 0;
            greenAngle = 0;
            redAngle = 0;
            blueSpeed = 0.025f;
            greenSpeed = 0.017f;
            redSpeed = 0.022f;
            distance = 100;

            score = 893234;

            Rows = 4;
            Columns = 4;
            totalFrames = 16;
            currentFrame = 0;





            List<Texture2D> textures = new List<Texture2D>();
            textures.Add(this.circle);
            textures.Add(this.star);
            textures.Add(this.diamond);
            particleEngine = new ParticleEngine(textures, new Vector2(400, 240));
        }

        public void update()
        {
            arrowAngle += 0.01f;
            blueAngle += blueSpeed;
            greenAngle += greenSpeed;
            redAngle += redSpeed;



            currentFrame++;
            if (currentFrame == totalFrames)
            {
                currentFrame = 0;
            }

            particleEngine.EmitterLocation = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            particleEngine.Update();
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Rectangle(0, 0, 1280, 720), Color.White);
            spriteBatch.Draw(earth, new Vector2(400, 240), Color.White);
            spriteBatch.Draw(shuttle, new Vector2(450, 240), Color.White);
            spriteBatch.DrawString(basicFont, "Score: " + score, new Vector2(100, 100), Color.White);
            spriteBatch.End();

            spriteBatch.Begin();
            Vector2 location = new Vector2(400, 240);
            Rectangle sourceRectangle = new Rectangle(0, 0, arrow.Width, arrow.Height);
            Vector2 origin = new Vector2(arrow.Width / 2, arrow.Height);
            spriteBatch.Draw(arrow, location, sourceRectangle, Color.White, arrowAngle, origin, 1.0f, SpriteEffects.FlipVertically, 1);
            spriteBatch.End();

            Vector2 bluePosition = new Vector2((float)Math.Cos(blueAngle) * distance, (float)Math.Sin(blueAngle) * distance);
            Vector2 greenPosition = new Vector2((float)Math.Cos(greenAngle) * distance, (float)Math.Sin(greenAngle) * distance);
            Vector2 redPosition = new Vector2((float)Math.Cos(redAngle) * distance, (float)Math.Sin(redAngle) * distance);
            Vector2 center = new Vector2(300, 140);
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Additive);
            spriteBatch.Draw(blue, center + bluePosition, Color.White);
            spriteBatch.Draw(green, center + greenPosition, Color.White);
            spriteBatch.Draw(red, center + redPosition, Color.White);
            spriteBatch.End();



            int width = textureAtlas.Width / Columns;
            int height = textureAtlas.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
            Rectangle sourceRectangle2 = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);
            spriteBatch.Begin();
            spriteBatch.Draw(textureAtlas, destinationRectangle, sourceRectangle2, Color.White);
            spriteBatch.End();

            particleEngine.Draw(spriteBatch);



        }
    }    
}
