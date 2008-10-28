using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace CrazyWorm
{
    abstract class Actor : Entity
    {
        protected List<BoundingRectangle> CollisionBoxes;
        protected List<BoundingCircle> CollisionCircles;
        protected Boolean SolidObject;

        public override void Update(GameTime gameTime)
        {
            throw new Exception("This method should not be used!");
        }

        public override void Draw()
        {
            throw new Exception("This method should not be used!");
        }
                
        public List<BoundingRectangle> GetCollBoxes() { return CollisionBoxes; }
        public void SetCollBoxes(List<BoundingRectangle> newcol) { CollisionBoxes = newcol; }
        public void AddCollBox(BoundingRectangle newcol) { CollisionBoxes.Add(newcol); }
        public void ClearCollBoxes() { CollisionBoxes.Clear(); }

        public List<BoundingCircle> GetCollCircs() { return CollisionCircles; }
        public void SetCollCircs(List<BoundingCircle> newcol) { CollisionCircles = newcol; }
        public void AddCollCirc(BoundingCircle newcol) { CollisionCircles.Add(newcol); }
        public void ClearCollCircs() { CollisionCircles.Clear(); }
        
        public Boolean Solid() { return SolidObject; }
        public void SetSolid(Boolean sol) { SolidObject = sol; }
    }
}
