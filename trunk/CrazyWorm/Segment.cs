using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyWorm
{
    public class Segment : VisibleActor
    {
        private float reanimatespeed = 0f;

        public Segment(Texture2D simg, Vector2 pos, bool collision)
        {
            ActorSprite = new Sprite(simg);
            Position = pos;

            InitCollLists();

            if (collision)
                this.AddCollCirc(new BoundingCircle(new Vector2(simg.Width / 2, simg.Height / 2), (simg.Width / 2) - (simg.Width / 16)));
        }

        public float ReanimateSpeed
        {
            get { return reanimatespeed; }
            set { reanimatespeed = value; }
        }
    }
}
