using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyWorm
{
    class PlayWindow : Window
    {
        Player play;

        public PlayWindow()
        {
            Name = "PlayWindow";
            Mode = WindowMode.Active;

            play = new Player();

            Initialize();
        }

        protected override void Initialize()
        {
           
        }

        protected override void Update(GameTime gameTime)
        {
            play.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            play.Draw();
        }
    }
}
