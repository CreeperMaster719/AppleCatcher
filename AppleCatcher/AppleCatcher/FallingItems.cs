using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AppleCatcher
{
    class FallingItems : Sprite
    {
        int x = 0;
        int y = 0;
        int ySpeed = 5;
        //double xSpeed = 0.1;
        public FallingItems(Vector2 vector2, Texture2D texture2D, Color color )
            : base(vector2, texture2D, color)
        {


        }
        public void Move(Viewport viewport)
        {

                y += ySpeed;


        }
    }
}
