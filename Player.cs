using System;
using Utilities;

namespace Console_Game
{
    internal class Player : GameObject
    {
        float x;
        float y;
        float speed = 5;
        byte graphic = (byte)"X"[0];
        public Player()
        {
            x = 10;
            y = 15;
        }
        internal override void Update(int deltaMs)
        {
            float delta = (float)deltaMs / (float)1000; //ms to seconds
            if(Keyboard.IsKeyPressed(Keyboard.VirtualKeyStates.VK_UP))
            {
                y -= speed * delta;
            }
            if (Keyboard.IsKeyPressed(Keyboard.VirtualKeyStates.VK_DOWN))
            {
                y += speed * delta;
            }
            if (Keyboard.IsKeyPressed(Keyboard.VirtualKeyStates.VK_LEFT))
            {
                x -= speed * delta;
            }
            if (Keyboard.IsKeyPressed(Keyboard.VirtualKeyStates.VK_RIGHT))
            {
                x += speed * delta;
            }
        }
        internal override Point GetGraphicPos()
        {
            //Round floats by adding 0.5
            return new Point((int)(x + 0.5), (int)(y + 0.5));
        }
        internal override string GetGraphic()
        {
            char graphicChar = (char)graphic;
            return "X";
        }
    }
}