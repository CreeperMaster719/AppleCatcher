using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Media;

namespace AppleCatcher
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        FallingItems testItem;
        Random position;
        ItemCatcher testCatcher;
        List <FallingItems> goodItems;
        List<Texture2D> textures;
        Random RandomTextures = new Random();
        KeyboardState keyboard = Keyboard.GetState();
        SoundEffect sound;
        int numberOfItems = 10;
        int youWin = 0;
        
        int score = 0;
        SpriteFont font;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 980;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            sound = Content.Load<SoundEffect>("gnomed");
            textures = new List<Texture2D>();
            for (int i = 1; i <= 8; i++)
            {
                textures.Add(Content.Load<Texture2D>("Falling_Item_" + i));
            }
            for (int i = 1; i <= 4; i++)
            {
                textures.Add(Content.Load<Texture2D>("Falling_Enemy_" + i));
            }

            //textures.Add(Content.Load<Texture2D>("Falling_Item_1"));
            //textures.Add(Content.Load<Texture2D>("Falling_Item_2"));
            //textures.Add(Content.Load<Texture2D>("Falling_Item_3"));
            //textures.Add(Content.Load<Texture2D>("Falling_Item_4"));
            //textures.Add(Content.Load<Texture2D>("Falling_Item_5"));
            //textures.Add(Content.Load<Texture2D>("Falling_Item_6"));
            //textures.Add(Content.Load<Texture2D>("Falling_Item_7"));
            //textures.Add(Content.Load<Texture2D>("Falling_Item_8"));
            //textures.Add(Content.Load<Texture2D>("Falling_Enemy_1"));
            //textures.Add(Content.Load<Texture2D>("Falling_Enemy_2"));
            //textures.Add(Content.Load<Texture2D>("Falling_Enemy_3"));
            //textures.Add(Content.Load<Texture2D>("Falling_Enemy_4"));
            position = new Random();
            goodItems = new List<FallingItems>();
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Vector2 testPosition = new Vector2(position.Next(0,1000), -50);
            Texture2D testTexture = Content.Load <Texture2D>("Test_Item");
            Color testTint = Color.White;
            for(int i = 0; i < numberOfItems; i++)
            {
                //goodItems.Add(new FallingItems(testPosition, textures[RandomTextures.Next(0,7)], testTint));
                goodItems.Add(new FallingItems(testPosition, textures[i + 1], testTint));
            }
            //for (int i = 0; i < 1; i++)
           // {
                //goodItems.Add(new FallingItems(testPosition, textures[0], testTint));
            // }
            //goodItems[0].ScoreValue = 8;
            //goodItems[1].ScoreValue = 4;
            //goodItems[2].ScoreValue = 6;
            //goodItems[3].ScoreValue = 1;
            //goodItems[4].ScoreValue = 2;
            //goodItems[5].ScoreValue = 4;
            //goodItems[6].ScoreValue = 1;
            //goodItems[7].ScoreValue = 2;
            //goodItems[8].ScoreValue = -25;
            //goodItems[9].ScoreValue = -5;
           //goodItems[10].ScoreValue = -15;
           //goodItems[11].ScoreValue = -10;
            Vector2 testPositionC = new Vector2(200, 860);
            Texture2D testTextureC = Content.Load<Texture2D>("Falling_Selector_1_Scaled");
            font = Content.Load<SpriteFont>("Font");
            Color testTintC = Color.White;
            testCatcher = new ItemCatcher(testPositionC, testTextureC, testTintC);
            // TODO: use this.Content to load your game content here
        }



        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            keyboard = Keyboard.GetState();

            if (youWin == 0)
            {
                testCatcher.Update(goodItems, textures, GraphicsDevice.Viewport, position, Keys.A, Keys.D, numberOfItems, sound);
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            for(int i = 0; i < goodItems.Count; i++)
            {
                goodItems[i].Draw(spriteBatch);
            }
            if(testCatcher.TotalScore >= 250)
            {
                spriteBatch.DrawString(font, $"You Win!!!", new Vector2(300, 300), Color.Orange);
                youWin = 1;
            }
            spriteBatch.DrawString(font, $"{testCatcher.TotalScore}", new Vector2(100, 100), Color.Orange);
            spriteBatch.DrawString(font, $"{testCatcher.Score}", new Vector2(100, 180), Color.Orange);
            testCatcher.Draw(spriteBatch);
            // TODO: Add your drawing code here
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
