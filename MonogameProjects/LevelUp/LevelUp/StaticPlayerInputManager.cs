using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    static class StaticPlayerInputManager
    {

        public static string getStatus(KeyboardState kbs, MouseState ms, GamePadState gps)
        {

            if (kbs.IsKeyDown(Keys.G))
            {
                return "G on KEYBOARD IS PRESSED";
            }


            return "ERROR";
        }
        
    }
}
