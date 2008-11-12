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
        List<Apple> Apples;

        public PlayWindow()
        {
            Name = "PlayWindow";
            Mode = WindowMode.Active;

            play = new Player();
            Apples = new List<Apple>();

            Initialize();
        }

        protected override void Initialize()
        {
            Texture2D aimg = BaseGame.GetContent().Load<Texture2D>("apple");

            for (int i = 0; i < NUM_OF_APPLES; i++)
                Apples.Add(new Apple(aimg, new Vector2(BaseGame.Rand.Next(1280), BaseGame.Rand.Next(720))));
        }

        protected override void Update(GameTime gameTime)
        {

            play.Update(gameTime);

            foreach (Apple a in Apples)
            {
                if (a.CollidesWith(play))
                {
                    a.Reposition();
                    play.AddSegments(Player.ADDED_SEGMENTS);
                }
                a.Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            foreach (Apple a in Apples)
                a.Draw();

            play.Draw();
        }
    }
}
