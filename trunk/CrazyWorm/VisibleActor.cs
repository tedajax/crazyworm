using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrazyWorm
{
    class VisibleActor : Actor
    {
        Sprite ActorSprite;
        public VisibleActor(string img)
        {
            ActorSprite = new Sprite(BaseGame.GetContent().Load<Texture2D>(img));
        }

        public VisibleActor(string img, Vector2 pos)
        {
            ActorSprite = new Sprite(BaseGame.GetContent().Load<Texture2D>(img));
            Position = pos;
        }

        public VisibleActor(Texture2D img, Vector2 pos)
        {
            ActorSprite = new Sprite(img);
            Position = pos;
        }

        public override void Update(GameTime gameTime)
        {
            ActorSprite.SetPosition(Position);
            ActorSprite.SetRotation(Rotation);
        }

        public override void Draw()
        {
            ActorSprite.Draw();
        }

        public Sprite GetSprite() { return ActorSprite; }
    }
}
