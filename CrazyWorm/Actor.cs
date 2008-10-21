using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace CrazyWorm
{
    abstract class Actor : Entity
    {
        List<Rectangle> CollisionBoxes;
        Boolean SolidObject;

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw()
        {
            
        }

        public List<Rectangle> GetCollBoxes() { return CollisionBoxes; }
        public void SetCollBoxes(List<Rectangle> newcol) { CollisionBoxes = newcol; }
        public void AddCollBox(Rectangle newcol) { CollisionBoxes.Add(newcol); }
        public void ClearCollBoxes() { CollisionBoxes.Clear(); }

        public Boolean Solid() { return SolidObject; }
        public void SetSolid(Boolean sol) { SolidObject = sol; }
    }
}
