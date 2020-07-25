using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace RBWhitakerLibrary
{
    class ThreeDimensionTutorial
    {

        private Model model;
        private Matrix world = Matrix.CreateTranslation(new Vector3(0, 0, 0));
        private Matrix view = Matrix.CreateLookAt(new Vector3(0, 0, 10), new Vector3(0, 0, 0), Vector3.UnitY);
        private Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.1f, 100f);
        private Vector3 position;
        private float angle;
        private Texture2D otherTexture;

        public ThreeDimensionTutorial(Game1 currentGame)
        {
            /*
             * For some reason we are excluding the default texture from being built.
             * This is so that monogame doesn't manage the texture.
             * 
             * 
             */
            model = currentGame.Content.Load<Model>("ThreeDimensionTutorial/SimpleShip/Ship");
            position = new Vector3(0, 0, 0);
            angle = 0;
            otherTexture = currentGame.Content.Load<Texture2D>("ThreeDimensionTutorial/SimpleShip/GreenShipTexture");

        }

        public void update()
        {
            position += new Vector3(0, 0.01f, 0);
            world = Matrix.CreateRotationY(angle) * Matrix.CreateTranslation(position);
            angle += 0.03f;

        }

        public void draw()
        {

            DrawModel(model, world, view, projection);

        }


        private void DrawModel(Model model, Matrix world, Matrix view, Matrix projection)
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = world;
                    effect.View = view;
                    effect.Projection = projection;
                    //effect.Texture = otherTexture; // otherTexture is of the type "Texture2D"
                    //effect.TextureEnabled = false;
                    effect.EnableDefaultLighting();

                    effect.LightingEnabled = true; // turn on the lighting subsystem.
                    effect.DirectionalLight0.DiffuseColor = new Vector3(0.5f, 0, 0); // a red light
                    effect.DirectionalLight0.Direction = new Vector3(1, 0, 0);  // coming along the x-axis
                    effect.DirectionalLight0.SpecularColor = new Vector3(0, 1, 0); // with green highlights

                    //effect.DirectionalLight0.Enabled = false;

                    effect.AmbientLightColor = new Vector3(0.2f, 0.2f, 0.2f);
                    effect.EmissiveColor = new Vector3(1, 0, 0);


                    effect.FogEnabled = true;
                    effect.FogColor = Color.CornflowerBlue.ToVector3(); // For best results, make this color whatever your background is.
                    effect.FogStart = 9.75f;
                    effect.FogEnd = 10.25f;
                }

                mesh.Draw();
            }
        }
    }
}

/*
 * 
 * Following R.B. Whitaker's site: http://rbwhitaker.wikidot.com/2d-tutorials
 * 
 * 2D-TUTORIAL
 *      You can draw images anywhere on the game screen, along with text
 *      You can also "draw" text and rotate images and use texture atlases.
 *      You can also use additive blending to make texture compliment eachother
 *      on overlapsl. 
 *      Finally you can make a particle engine.
 * 
 * 
 */
