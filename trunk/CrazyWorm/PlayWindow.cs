using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyWorm
{
    class PlayWindow : Window
    {
        const int NUM_OF_APPLES = 10;

        Player play;
        AppleManager Apples;

        public PlayWindow()
        {
            Name = "PlayWindow";
            Mode = WindowMode.Active;

            play = new Player();
            Apples = new AppleManager();

            Initialize();
        }

        protected override void Initialize()
        {
            Texture2D aimg = BaseGame.GetContent().Load<Texture2D>("apple");

            for (int i = 0; i < NUM_OF_APPLES; i++)
                Apples.AppleList.Add(new Apple(aimg, new Vector2(BaseGame.Rand.Next(1280), BaseGame.Rand.Next(720))));
        }

        protected override void Update(GameTime gameTime)
        {
            Apples.Update(gameTime, play);    
            play.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            Apples.Draw();
            play.Draw();
        }
    }
}
