using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyWorm
{
    class AppleManager
    {
        List<Apple> appleList;

        public List<Apple> AppleList
        {
            get { return appleList; }
            set { appleList = value; }
        }

        public AppleManager()
        {
            appleList = new List<Apple>();
        }

        public void Update(GameTime gameTime, Player col)
        {
            foreach (Apple a in appleList)
            {
                if (a.CollidesWith(col))
                {
                    a.Reposition();
                    col.AddSegments(Player.ADDED_SEGMENTS);
                }

                a.Update(gameTime);
            }
        }

        public void Draw()
        {
            foreach (Apple a in appleList)
                a.Draw();
        }
    }
}
