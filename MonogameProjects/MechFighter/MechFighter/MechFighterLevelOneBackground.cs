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
    class MechFighterLevelOneBackground
    {
        // 1280 x 720
        Texture2D scrollingBackground;

        Rectangle firstRectangle;
        Rectangle secondRectangle;
        Rectangle thirdRectangle;

        int textureXPos;

        int updateCounter;

        public MechFighterLevelOneBackground(Texture2D background)
        {
            scrollingBackground = background;

            updateCounter = 0;
            textureXPos = 0;
            firstRectangle = new Rectangle(0, 0, 640, 720);
            secondRectangle = new Rectangle(640, 0, 640, 720);
            thirdRectangle = new Rectangle(1280, 0, 640, 720);

        }

        public void update()
        {
            updateCounter++;
            if(updateCounter >= 1)
            {

                firstRectangle.X--;
                secondRectangle.X--;
                thirdRectangle.X--;

                if(firstRectangle.X <= -640)
                {
                    firstRectangle.X = 1280;
                }
                if (secondRectangle.X <= -640)
                {
                    secondRectangle.X = 1280;
                }
                if (thirdRectangle.X <= -640)
                {
                    thirdRectangle.X = 1280;
                }

                updateCounter = 0;
            }
                
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(scrollingBackground, firstRectangle, Color.White);
            spriteBatch.Draw(scrollingBackground, secondRectangle, Color.White);
            spriteBatch.Draw(scrollingBackground, thirdRectangle, Color.White);
        }
    }
}
