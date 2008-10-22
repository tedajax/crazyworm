using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace CrazyWorm
{
    class Circle
    {
        protected Vector2 position;
        protected float radius;

        public Circle(Vector2 pos, float rad)
        {
            position = pos;
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

        public bool Intersects(Circle c)
        {
            if (Vector2.Distance(position, c.Position) <= (radius + c.Radius))
                return true;
            else
                return false;
        }
    }
}
