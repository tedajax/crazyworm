using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace CrazyWorm
{
    public class ResolutionManager
    {
        Vector2 Resolution;
        Vector2 BaseResolution;
        Vector2 Scaler;

        public ResolutionManager(Vector2 res)
        {
            Resolution = res;
            BaseResolution = new Vector2(1280, 720);

            Scaler = Resolution / BaseResolution;
        }

        public Vector2 GetResolution() { return Resolution; }
        public int GetResX() { return (int)Resolution.X; }
        public int GetResY() { return (int)Resolution.Y; }
        public Vector2 GetResScaler() { return Scaler; }
    }

    public class BaseGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        InputManager GameInput;
        static ResolutionManager GameRes;
        WindowManager WinMan;

        public BaseGame()
        {
            graphics = new GraphicsDeviceManager(this);

            GameRes = new ResolutionManager(new Vector2(1280, 720));

            graphics.PreferredBackBufferWidth = GameRes.GetResX();
            graphics.PreferredBackBufferHeight = GameRes.GetResY();

            Content.RootDirectory = "Content";

            GameInput = new InputManager();
            WinMan = new WindowManager();
            
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            GameInput.UpdateNewInput();

            if (GameInput.GetKeyPressedState(Keys.Escape) == KeyPressedState.JustPressed)
                this.Exit();


            GameInput.UpdateOldInput();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }

        //public method to get the Resolution Scaler
        public static Vector2 GetResScaler() { return GameRes.GetResScaler(); }
    }
}
