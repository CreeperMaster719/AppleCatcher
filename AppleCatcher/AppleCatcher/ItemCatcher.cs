using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AppleCatcher
{
    class ItemCatcher : Sprite
    {
        int xSpeed = 1;

        public ItemCatcher(Vector2 vector2, Texture2D texture2D, Color tint)
                : base(vector2, texture2D, tint)
        {

        }


        public void Update(FallingItems testitem, Viewport viewport, Random random, Keys keyLeft, Keys keyRight)
        {
          
            KeyboardState keyboard = Keyboard.GetState();
            if(keyboard.IsKeyDown(keyLeft))
                { 
                position.X -= 15;

            }
            else if(keyboard.IsKeyDown(keyRight))
            {
                position.X += 15;
            }
            if(position.X + texture.Width > viewport.Width)
            {
                position.X = 0;
            }
            if (HitBox.Intersects(testitem.HitBox))
            {
                testitem.position.Y = 0;
                testitem.position.X = random.Next(0, viewport.Width);
            }
        }
    }
}
