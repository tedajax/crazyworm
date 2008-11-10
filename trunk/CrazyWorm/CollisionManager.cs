using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace CrazyWorm
{
    class CollisionManager
    {
        private List<Actor> CollisionObjects;
        private List<Collision> Collisions;

        public CollisionManager()
        {
            CollisionObjects = new List<Actor>();
            Collisions = new List<Collision>();
        }

        public void AddObject(Actor a)
        {
            CollisionObjects.Add(a);
        }

        public void RemoveObject(Actor a)
        {
            CollisionObjects.Remove(a);
        }

        //Should be called a the end of every game update loop
        public void ClearCollision()
        {
            Collisions.Clear();
        }

        //iterate over all possible actors and check for collisions between them
        public void CheckCollisions()
        {
            for (int x = 0; x < CollisionObjects.Count - 1; x++)
            {
                for (int y = x + 1; y < CollisionObjects.Count; y++)
                {
                    if (CollisionObjects[x].CollidesWith(CollisionObjects[y]))
                    {
                        Collision newcol = new Collision(CollisionObjects[x], CollisionObjects[y]);
                        Collisions.Add(newcol);
                    }
                }
            }
        }
    }
}
