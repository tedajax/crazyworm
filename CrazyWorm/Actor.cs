using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace CrazyWorm
{
    abstract class Actor : Entity
    {
        protected List<Rectangle> CollisionBoxes;
        protected List<Circle> CollisionCircles;
        protected Boolean SolidObject;

        public override void Update(GameTime gameTime)
        {
            throw new Exception("This method should not be used!");
        }

        public override void Draw()
        {
            throw new Exception("This method should not be used!");
        }
                
        public List<Rectangle> GetCollBoxes() { return CollisionBoxes; }
        public void SetCollBoxes(List<Rectangle> newcol) { CollisionBoxes = newcol; }
        public void AddCollBox(Rectangle newcol) { CollisionBoxes.Add(newcol); }
        public void ClearCollBoxes() { CollisionBoxes.Clear(); }

        public List<Circle> GetCollCircs() { return CollisionCircles; }
        public void SetCollCircs(List<Circle> newcol) { CollisionCircles = newcol; }
        public void AddCollCirc(Circle newcol) { CollisionCircles.Add(newcol); }
        public void ClearCollCircs() { CollisionCircles.Clear(); }
        
        public Boolean Solid() { return SolidObject; }
        public void SetSolid(Boolean sol) { SolidObject = sol; }
    }
}
