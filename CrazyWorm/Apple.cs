using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyWorm
{
    class Apple : VisibleActor
    {
        public Apple(Texture2D aimg, Vector2 pos)
        {
            ActorSprite = new Sprite(aimg);
            Position = pos;

            InitCollLists();

            AddCollCirc(new BoundingCircle(new Vector2(aimg.Width / 2, aimg.Height / 2), aimg.Width / 2));

            SolidObject = true;
        }

        public void Reposition()
        {
            Position = new Vector2(BaseGame.Rand.Next(1280), BaseGame.Rand.Next(720));
        }
    }
}
