using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace CrazyWorm
{
    class BoundingRectangle
    {
        private Vector2 position;
        private Vector2 dimensions;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public float X
        {
            get { return position.X; }
            set { position.X = value; }
        }

        public float Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }

        public float Width
        {
            get { return dimensions.X; }
            set { dimensions.X = value; }
        }

        public float Height
        {
            get { return dimensions.Y; }
            set { dimensions.Y = value; }
        }

        public float Top
        {
            get { return position.Y; }
        }

        public float Bottom
        {
            get { return position.Y + dimensions.Y; }
        }

        public float Left
        {
            get { return position.X; }
        }

        public float Right
        {
            get { return position.X + dimensions.X; }
        }

        /// <summary>
        /// Create a bounding rectangle using individual floats
        /// </summary>
        /// <param name="x">Position X coordinate</param>
        /// <param name="y">Position Y coordinate</param>
        /// <param name="w">Width</param>
        /// <param name="h">Height</param>
        public BoundingRectangle(float x, float y, float w, float h)
        {
            position = new Vector2(x, y);
            dimensions = new Vector2(w, h);
        }

        /// <summary>
        /// Create rectangle using vector2 for position and floats for dimensions
        /// </summary>
        /// <param name="pos">Position coordinates stored in a Microsoft.XNA.Framework.Vector2</param>
        /// <param name="w">Width</param>
        /// <param name="h">Height</param>
        public BoundingRectangle(Vector2 pos, float w, float h)
        {
            position = pos;
            dimensions = new Vector2(w, h);
        }

        /// <summary>
        /// Create a rectangle using Vector2 for both sets of data
        /// </summary>
        /// <param name="pos">Position coordinates stored in a Microsoft.XNA.Framework.Vector2</param>
        /// <param name="dim">Dimensions stored in a Microsoft.XNA.Framework.Vector2</param>
        public BoundingRectangle(Vector2 pos, Vector2 dim)
        {
            position = pos;
            dimensions = dim;
        }

        public bool Intersects(BoundingRectangle r)
        {
            if (Bottom < r.Top) return false;
            if (Top > r.Bottom) return false;
            if (Right < r.Left) return false;
            if (Left > r.Right) return false;

            return true;
        }

        public bool Intersects(BoundingCircle c)
        {
            //Calculate the smallest distance from the center of the Rectangle to the nearest edge
            float mindist = (MathHelper.Min(Width, Height) == Width ? Width / 2 : Height / 2);
            //Read the above as "If the width dimension is less than the height dimension set the minimum distance to width / 2, otherwise set the distance to height / 2
            float maxdist = (float)Math.Sqrt(Math.Pow((double)Width / 2, 2) + Math.Pow((double)Height / 2, 2));
            //Use pythagorean theorem to work out the maximum distance

            if (Vector2.Distance(position, c.Position) - (mindist + c.Radius) < mindist)
                return true;
            else if (Vector2.Distance(position, c.Position) - (maxdist + c.Radius) > maxdist)
                return false;
            else //fuck, the entirely likely chance that the previous cases do not apply
            {

            }
        }
    }
}
