using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace CrazyWorm
{
    class BoundingCircle
    {
        protected Vector2 position;
        protected float radius;

        public BoundingCircle(Vector2 pos, float rad)
        {
            position = pos;
            radius = rad;
        }

        public BoundingCircle(float x, float y, float rad)
        {
            position = new Vector2(x, y);
            radius = rad;
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public float Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public bool Intersects(BoundingCircle c)
        {
            if (Vector2.Distance(position, c.Position) <= (radius + c.Radius))
                return true;
            else
                return false;
        }

        //implement later
        public bool Intersects(BoundingRectangle r)
        {
            return false;
        }
    }
}
