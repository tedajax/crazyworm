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

        //determines if two actors are colliding
        private bool CheckActorCollision(Actor a1, Actor a2)
        {
            //do some quick exclusions, (i.e. one or more of the actors is not solid or neither has any bounding objects)
            if (!a1.Solid() || !a2.Solid() || a1.TotalCollCount() == 0 || a2.TotalCollCount() == 0)
                return false;
            else
            {
                //check for circle collisions
                for (int i = 0; i < a1.CollCircCount() - 1; i++)
                {
                    BoundingCircle c1 = a1.GetCollCircs()[i];
                    c1.Position += a1.GetPosition();

                    for (int j = 0; j < a2.CollCircCount(); j++)
                    {
                        BoundingCircle c2 = a2.GetCollCircs()[j];
                        c2.Position += a2.GetPosition();

                        if (c1.Intersects(c2))
                            return true;
                    }

                    for (int h = i; h < a2.CollBoxCount(); h++)
                    {
                        BoundingRectangle b2 = a2.GetCollBoxes()[h];
                        b2.Position += a2.GetPosition();

                        if (c1.Intersects(b2))
                            return true;
                    }
                }
            
                //check for rectangle collisions
                for (int i = 0; i < a1.CollBoxCount(); i++)
                {
                    BoundingRectangle b1 = a1.GetCollBoxes()[i];
                    b1.Position += a1.GetPosition();

                    for (int j = 0; j < a2.CollCircCount(); j++)
                    {
                        BoundingCircle c2 = a2.GetCollCircs()[j];
                        c2.Position += a2.GetPosition();

                        if (b1.Intersects(c2))
                            return true;
                    }

                    for (int h = i; h < a2.CollBoxCount(); h++)
                    {
                        BoundingRectangle b2 = a2.GetCollBoxes()[h];
                        b2.Position += a2.GetPosition();

                        if (b1.Intersects(b2))
                            return true;
                    }
                }
            }

            return false;
        }

        //iterate over all possible actors and check for collisions between them
        public void CheckCollisions()
        {
            for (int x = 0; x < CollisionObjects.Count - 1; x++)
            {
                for (int y = x + 1; y < CollisionObjects.Count; y++)
                {
                    if (CheckActorCollision(CollisionObjects[x], CollisionObjects[y]))
                    {
                        Collision newcol = new Collision(CollisionObjects[x], CollisionObjects[y]);
                        Collisions.Add(newcol);
                    }
                }
            }
        }
    }
}
