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




    class PlayerInputManager
    {
        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;
        private MouseState currentMouseState;
        private MouseState previousMousestate;

        private GamePadState currentGamePadOneState;
        private GamePadState previousGamePadOneState;

        private GamePadState currentGamePadTwoState;
        private GamePadState previousGamePadTwoState;

        private GamePadState currentGamePadThreeState;
        private GamePadState previousGamePadThreeState;

        private GamePadState currentGamePadFourState;
        private GamePadState previousGamePadFourState;

        public PlayerInputManager(KeyboardState kbs, MouseState ms, GamePadState gpones, GamePadState gptwos, GamePadState gpthrees, GamePadState gpfours)
        {
            currentKeyboardState = kbs;
            previousKeyboardState = kbs;
            currentMouseState = ms;
            previousMousestate = ms;

            currentGamePadOneState = gpones;
            previousGamePadOneState = gpones;

            currentGamePadTwoState = gptwos;
            previousGamePadTwoState = gptwos;

            currentGamePadThreeState = gpthrees;
            previousGamePadThreeState = gpthrees;

            currentGamePadFourState = gpfours;
            previousGamePadFourState = gpfours;
        }

        public void updateInput(KeyboardState currentkbs, MouseState currentms, GamePadState currgpsone, GamePadState currgpstwo, GamePadState currgpsthree, GamePadState currgpsfour)
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = currentkbs;
            previousMousestate = currentMouseState;
            currentMouseState = currentms;

            previousGamePadOneState = currentGamePadOneState;
            currentGamePadOneState = currgpsone;

            previousGamePadTwoState = currentGamePadTwoState;
            currentGamePadTwoState = currgpstwo;

            previousGamePadThreeState = currentGamePadThreeState;
            currentGamePadThreeState = currgpsthree;

            previousGamePadFourState = currentGamePadFourState;
            currentGamePadFourState = currgpsfour;
        }

        public string devOutput()
        {
            StringBuilder keyboardLine = new StringBuilder();
            StringBuilder mouseLine = new StringBuilder();
            StringBuilder gamePadLine = new StringBuilder();

            keyboardLine.Append("KEYBOARD: ");

            var keysArr = new List<Keys>();
            keysArr = currentKeyboardState.GetPressedKeys().ToList<Keys>();
            foreach (var key in keysArr)
            {
                keyboardLine.Append(key.ToString() + " ");
            }
            keyboardLine.Append("");
            keyboardLine.AppendLine();

            mouseLine.Append("MOUSE: ");
            mouseLine.Append("X:" + currentMouseState.X.ToString() + " ");
            mouseLine.Append("Y:" + currentMouseState.Y.ToString() + " ");
            mouseLine.Append("LB:" + currentMouseState.LeftButton.ToString() + " ");
            mouseLine.Append("RB:" + currentMouseState.RightButton.ToString() + " ");
            mouseLine.Append("MB:" + currentMouseState.MiddleButton.ToString() + " ");
            mouseLine.Append("HZ:" + currentMouseState.HorizontalScrollWheelValue.ToString() + " ");
            mouseLine.Append("WV:" + currentMouseState.ScrollWheelValue.ToString() + " ");
            mouseLine.AppendLine();

            gamePadLine.Append("GAMEPAD1: ");
            gamePadLine.Append("Connected?: " + currentGamePadOneState.IsConnected.ToString() + " ");
            gamePadLine.AppendLine();
            gamePadLine.Append("GAMEPAD2: ");
            gamePadLine.Append("Connected?: " + currentGamePadTwoState.IsConnected.ToString() + " ");
            gamePadLine.AppendLine();
            gamePadLine.Append("GAMEPAD3: ");
            gamePadLine.Append("Connected?: " + currentGamePadThreeState.IsConnected.ToString() + " ");
            gamePadLine.AppendLine();
            gamePadLine.Append("GAMEPAD4: ");
            gamePadLine.Append("Connected?: " + currentGamePadFourState.IsConnected.ToString() + " ");
            //gamePadLine.Append("DPAD-D: " + currentGamePadOneState.DPad.Down.ToString() + " ");
            //gamePadLine.Append("DPAD-L: " + currentGamePadOneState.DPad.Left.ToString() + " ");
            //gamePadLine.Append("DPAD-R: " + currentGamePadOneState.DPad.Right.ToString() + " ");
            //gamePadLine.AppendLine();
            //gamePadLine.Append("X: " + currentGamePadOneState.Buttons.X.ToString() + " ");
            //gamePadLine.Append("Y: " + currentGamePadOneState.Buttons.Y.ToString() + " ");
            //gamePadLine.Append("A: " + currentGamePadOneState.Buttons.A.ToString() + " ");
            //gamePadLine.Append("B: " + currentGamePadOneState.Buttons.B.ToString() + " ");
            gamePadLine.AppendLine();




            return keyboardLine.ToString() + mouseLine.ToString() + gamePadLine.ToString();
        }


        /* KEYBOARD METHODS */

        /* MOUSE METHODS */

        /* GAMEPAD ONE METHODS */

        public bool gamePadOneDPadLeftWasJustPressed()
        {
            return currentGamePadOneState.DPad.Left == ButtonState.Pressed && previousGamePadOneState.DPad.Left == ButtonState.Released;
        }
        public bool gamePadOneDPadRightWasJustPressed()
        {
            return currentGamePadOneState.DPad.Right == ButtonState.Pressed && previousGamePadOneState.DPad.Right == ButtonState.Released;
        }
        public bool gamePadOneDPadLeftIsCurrentlyPressed()
        {
            return currentGamePadOneState.DPad.Left == ButtonState.Pressed;
        }
        public bool gamePadOneDPadRightIsCurrentlyPressed()
        {
            return currentGamePadOneState.DPad.Right == ButtonState.Pressed;
        }



        /* GAMEPAD TWO METHODS */


    }
}
