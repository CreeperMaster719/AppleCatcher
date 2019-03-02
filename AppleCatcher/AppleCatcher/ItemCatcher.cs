using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AppleCatcher
{
    class ItemCatcher : Sprite
    {
        int xSpeed = 1;
        double slowDown = 0.94;
        public int Score;
        int itemGain;
        int delay = 0;
        float degrees = 0;
        float radians = 0;
        
        
        double Mx = 0;

        float rotation
        {
            get
            {
                return (degrees * (MathHelper.Pi / 180));
            }
        }

        public int TotalScore;
        int numberOfEnemies = 1;

        public ItemCatcher(Vector2 vector2, Texture2D texture2D, Color tint)
                : base(vector2, texture2D, tint)
        {
            Score = 0;
            TotalScore = 0;
        }
        public void Update(List<FallingItems> items, List<Texture2D> textures, Viewport viewport, Random random, Keys keyLeft, Keys keyRight, int numberOfItems, SoundEffect sound)
        {
            
            Random itemRandomizer = new Random();
           
            KeyboardState keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(keyLeft))
            {
                Mx -= 1.5;
                degrees -= 2.5f;
            }
            else if (keyboard.IsKeyDown(keyRight))
            {
                Mx += 1.5;
                degrees += 2.5f;
            }
            if (position.X + texture.Width >= viewport.Width + 50)
            {
                Mx -= 1.6;
                degrees -= 4;
            }
            else if (position.X < 0)
            {
                Mx += 1.6;
                degrees += 4;
            }
            Mx *= slowDown;
            degrees *= (float)slowDown;
            position.X += (float)(Mx);
            for (int i = 0; i < items.Count; i++)
            {
                FallingItems item = items[i];
                if (HitBox.Intersects(item.HitBox))
                {
                    if (i <= numberOfItems - numberOfEnemies)
                    {
                        //Score += item.ScoreValue;
                        //TotalScore += item.ScoreValue;
                        Score += 2;
                        TotalScore += 2;
                        item.position.Y = -100;
                        item.position.X = random.Next(0, viewport.Width - item.texture.Width);
                        item.texture = textures[itemRandomizer.Next(0, 7)];
                    }
                    else
                    {
                        //Score += item.ScoreValue;
                        //TotalScore += item.ScoreValue;
                        Score += -10;
                        TotalScore += -10;
                        item.position.Y = -100;
                        item.position.X = random.Next(0, viewport.Width - item.texture.Width);
                        item.texture = textures[itemRandomizer.Next(8, 11)];
                    }

                }

                item.position.Y += (float)item.FallingSpeed;
                item.FallingSpeed += 0.05;

                if (item.position.Y + item.texture.Height > viewport.Height + 100)
                {
                    //item.position.Y = 0;
                    item.position.X = random.Next(0, viewport.Width - texture.Width);
                    item.position.Y = -100;
                    item.FallingSpeed = 0;
                    item.position.X = random.Next(0, viewport.Width - texture.Width);
                }
            }
            if (Score > 25)
            {
                numberOfEnemies++;
                Score = 0;
                
            }
            else if (TotalScore < 0)
            {
                numberOfEnemies--;
                TotalScore = 0;
            }
            if (keyboard.IsKeyDown(Keys.Left) || keyboard.IsKeyDown(Keys.Right)) 
            {
                sound.Play();
                //https://www.youtube.com/watch?v=9yEM_OjzfMo for hitting bad character.////
                while (true)
                {
                    
                }
            }
           
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, Color.White, rotation, Vector2.Zero, 1f, SpriteEffects.None, 0);
        }
    }
}
