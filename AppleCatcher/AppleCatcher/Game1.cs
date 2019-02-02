using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

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
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Vector2 testPosition = new Vector2(100, 50);
            Texture2D testTexture = Content.Load <Texture2D>("Test_Item");
            Color testTint = Color.White;
            testItem = new FallingItems(testPosition, testTexture, testTint);
            Vector2 testPositionC = new Vector2(200, 550);
            Texture2D testTextureC = Content.Load<Texture2D>("Test_Catcher");
            Color testTintC = Color.White;
            testCatcher = new ItemCatcher(testPositionC, testTextureC, testTintC);
            // TODO: use this.Content to load your game content here
        }



        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            testItem.position.Y += 5;
            position = new Random();
            if(testItem.position.Y + testItem.texture.Height> GraphicsDevice.Viewport.Height)
            {
                //testItem.position.Y = 0;
                // testItem.position.X = position.Next(0, GraphicsDevice.Viewport.Width);
                testItem.position.Y += -5;
            }

            testCatcher.Update(testItem, GraphicsDevice.Viewport, position, Keys.A, Keys.D);
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            testItem.Draw(spriteBatch);
            testCatcher.Draw(spriteBatch);
            // TODO: Add your drawing code here
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
