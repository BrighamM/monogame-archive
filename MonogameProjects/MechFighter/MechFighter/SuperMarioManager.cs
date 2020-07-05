using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MechFighter
{
    class SuperMarioManager
    {
        private Texture2D marioSpriteMap;

        bool littleMarioStanding; // standing
        bool littleMarioWalking; // littleMarioWalking
        Rectangle littleMarioStandingLeft;
        Rectangle littleMarioWalkingLeft;

        public Rectangle currentMarioRectangleFrame;

        int internalTickCounter;

        public SuperMarioManager(Texture2D inputTexture)
        {
            marioSpriteMap = inputTexture;
            littleMarioStandingLeft = new Rectangle(1,10,16,24);
            littleMarioWalkingLeft = new Rectangle(18, 11, 16, 23);
            internalTickCounter = 0;
            currentMarioRectangleFrame = new Rectangle(littleMarioStandingLeft.X, littleMarioStandingLeft.Y, littleMarioStandingLeft.Width, littleMarioStandingLeft.Height);
            littleMarioStanding = true;
            littleMarioWalking = false;
        }

        public Texture2D getMarioSpriteMap()
        {
            return marioSpriteMap;
        }
        

        public void marioUpdater()
        {
            internalTickCounter++;


            if (internalTickCounter % 6 == 0)
            {
                if (littleMarioStanding)
                {
                    currentMarioRectangleFrame = littleMarioStandingLeft;
                    littleMarioStanding = false;
                }
                else
                {
                    littleMarioStanding = true;
                    currentMarioRectangleFrame = littleMarioWalkingLeft;
                }
            }



            internalTickCounter %= 60;
        }




    }
}
