using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

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
            goodItems = new List<FallingItems>();
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Vector2 testPosition = new Vector2(100, 50);
            Texture2D testTexture = Content.Load <Texture2D>("Test_Item");
            Color testTint = Color.White;
            for(int i = 0; i < 20; i++)
            {
                goodItems.Add(new FallingItems(testPosition, testTexture, testTint));
            }

            Vector2 testPositionC = new Vector2(200, 860);
            Texture2D testTextureC = Content.Load<Texture2D>("Test_Catcher");
            font = Content.Load<SpriteFont>("Font");
            Color testTintC = Color.White;
            testCatcher = new ItemCatcher(testPositionC, testTextureC, testTintC);
            // TODO: use this.Content to load your game content here
        }



        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            position = new Random();

            testCatcher.Update(goodItems, GraphicsDevice.Viewport, position, Keys.A, Keys.D);
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
            spriteBatch.DrawString(font, $"{testCatcher.Score}", new Vector2(100, 100), Color.Orange);
            testCatcher.Draw(spriteBatch);
            // TODO: Add your drawing code here
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
