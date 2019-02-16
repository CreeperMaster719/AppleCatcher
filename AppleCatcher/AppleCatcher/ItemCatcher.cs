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
        public int Score;

        public ItemCatcher(Vector2 vector2, Texture2D texture2D, Color tint)
                : base(vector2, texture2D, tint)
        {
            Score = 0;
        }


        public void Update(List<FallingItems> items, Viewport viewport, Random random, Keys keyLeft, Keys keyRight)
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
            if(position.X + texture.Width >= viewport.Width + 50)
            {
                position.X += -5;
            }
            else if(position.X < 0)
            {
                position.X += 5;
            }
            for(int i = 0; i < items.Count; i++)
            {
                FallingItems item = items[i];
                if (HitBox.Intersects(item.HitBox))
                {
                    Score++;
                    item.position.Y = -100;
                    item.position.X = random.Next(0, viewport.Width - item.texture.Width);
                }

                item.position.Y += 15;
                
                if (item.position.Y + item.texture.Height > viewport.Height + 100)
                {
                    //item.position.Y = 0;
                    // item.position.X = position.Next(0, GraphicsDevice.Viewport.Width);
                    item.position.Y = -100;
                }
            }

            
            

        }
    }
}
