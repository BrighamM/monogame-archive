using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LevelUp
{
    class SuperMarioManager
    {
        private Texture2D marioSpriteMap;

        bool littleMarioStanding; // standing
        bool littleMarioWalking; // littleMarioWalking
        Rectangle littleMarioStandingLeft;
        Rectangle littleMarioWalkingLeft;

        bool marioIsFacingLeft;

        public Rectangle currentMarioRectangleFrame;

        int internalTickCounter;

        Point marioPosition;

        public SuperMarioManager(Texture2D inputTexture)
        {
            marioSpriteMap = inputTexture;

            littleMarioStandingLeft = new Rectangle(1, 10, 16, 24);
            littleMarioWalkingLeft = new Rectangle(18, 11, 16, 23);
            internalTickCounter = 0;
            currentMarioRectangleFrame = new Rectangle(littleMarioStandingLeft.X, littleMarioStandingLeft.Y, littleMarioStandingLeft.Width, littleMarioStandingLeft.Height);
            littleMarioStanding = true;
            littleMarioWalking = false;
            marioIsFacingLeft = false;
            marioPosition.X = 100;
            marioPosition.Y = 100;
        }

        public Texture2D getMarioSpriteMap()
        {
            return marioSpriteMap;
        }

        public void leftWasPressed()
        {
            marioIsFacingLeft = true;
            marioPosition.X -= 5;
        }

        public void rightWasPressed()
        {
            marioIsFacingLeft = false;
            marioPosition.X += 5;
        }


        public void update(PlayerInputManager pim)
        {
            if(pim.isGamePadOneDPadLeftCurrentlyPressed())
            {
                leftWasPressed();
            }
            if(pim.isGamePadOneDPadRightCurrentlyPressed())
            {
                rightWasPressed();
            }

            //internalTickCounter++;

            //if (internalTickCounter % 6 == 0)
            //{
            //    if (littleMarioStanding)
            //    {
            //        currentMarioRectangleFrame = littleMarioStandingLeft;
            //        littleMarioStanding = false;
            //    }
            //    else
            //    {
            //        littleMarioStanding = true;
            //        currentMarioRectangleFrame = littleMarioWalkingLeft;
            //    }
            //}

            //if (marioPosition.Y < 500)
            //{
            //    marioPosition.Y++;
            //}

            //internalTickCounter %= 60;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(marioIsFacingLeft)
            {
                spriteBatch.Draw(getMarioSpriteMap(), new Rectangle(marioPosition.X, marioPosition.Y, 120, 180), currentMarioRectangleFrame, Color.White, 0, new Vector2(0), SpriteEffects.None, 1);
            }
            else
            {
                spriteBatch.Draw(getMarioSpriteMap(), new Rectangle(marioPosition.X, marioPosition.Y, 120, 180), currentMarioRectangleFrame, Color.White, 0, new Vector2(0), SpriteEffects.FlipHorizontally, 1);
            }
        }



    }
}
