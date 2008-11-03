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
    }
}
