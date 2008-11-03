using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace CrazyWorm
{
    //storage class for holding two actors that have collided
    class Collision
    {
        Actor actor1;
        Actor actor2;

        public Collision(Actor a1, Actor a2)
        {
            actor1 = a1;
            actor2 = a2;
        }

        public Actor Actor1
        {
            get { return actor1; }
        }

        public Actor Actor2
        {
            get { return actor2; } 
        }
    }
}
