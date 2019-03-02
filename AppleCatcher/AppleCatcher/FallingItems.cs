using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AppleCatcher
{
    public class FallingItems : Sprite
    {

        int x = 0;
        int y = 0;
        int ySpeed = 5;
        public double FallingSpeed = 0f;
        public int ScoreValue = 0;
        public FallingItems(Vector2 vector2, Texture2D texture2D, Color color)
            : base(vector2, texture2D, color) { }

        public void Move(Viewport viewport)
        {
            y += ySpeed;
        }
    }
}
