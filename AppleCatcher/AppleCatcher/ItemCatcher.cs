﻿using System;
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
        int itemGain;
        public int TotalScore;
        int numberOfEnemies = 1;
        public ItemCatcher(Vector2 vector2, Texture2D texture2D, Color tint)
                : base(vector2, texture2D, tint)
        {
            Score = 0;
            TotalScore = 0;
        }


        public void Update(List<FallingItems> items, List<Texture2D> textures, Viewport viewport, Random random, Keys keyLeft, Keys keyRight, int numberOfItems)
        {
            
            Random itemRandomizer = new Random();
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
                    if(i <= numberOfItems - numberOfEnemies)
                    {
                        Score += 1;
                        TotalScore += 1;
                        item.position.Y = -100;
                        item.position.X = random.Next(0, viewport.Width - item.texture.Width);
                        item.texture = textures[itemRandomizer.Next(0, 7)];
                    }
                    else
                    {
                        Score += -10;
                        TotalScore += -10;
                        item.position.Y = -100;
                        item.position.X = random.Next(0, viewport.Width - item.texture.Width);
                        item.texture = textures[itemRandomizer.Next(8, 11)];
                    }

                }

                item.position.Y += 10;
                
                if (item.position.Y + item.texture.Height > viewport.Height + 100)
                {
                    //item.position.Y = 0;
                    // item.position.X = position.Next(0, GraphicsDevice.Viewport.Width);
                    item.position.Y = -100;
                    item.position.X = random.Next(0, viewport.Width - texture.Width);
                }
            }
            if(Score > 25)
            {
                numberOfEnemies++;
                Score = 0;
            }





        }
    }
}
