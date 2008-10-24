using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CrazyWorm
{
    class Player : Actor
    {
        Sprite PlayerSprite;
        List<VisibleActor> BodySections;

        public Player()
        {
            Texture2D img = BaseGame.GetContent().Load<Texture2D>("wormhead");
            PlayerSprite = new Sprite(img);

            Position = new Vector2(1280 / 2, 720 / 2);

            BodySections = new List<VisibleActor>();
        }

        public override void Update(GameTime gameTime)
        {
            if (BaseGame.GetInMan().GetKeyPressedState(Keys.Left) == KeyPressedState.Pressed)
                Rotation -= MathHelper.PiOver4 / 16f;
            if (BaseGame.GetInMan().GetKeyPressedState(Keys.Right) == KeyPressedState.Pressed)
                Rotation += MathHelper.PiOver4 / 16f;

            Velocity.X = 5 * (float)Math.Cos((double)Rotation);
            Velocity.Y = 5 * (float)Math.Sin((double)Rotation);

            if (BaseGame.GetInMan().GetKeyPressedState(Keys.Up) == KeyPressedState.Released)
                Velocity *= 1;

            Position += Velocity;

            PlayerSprite.SetPosition(Position);
            PlayerSprite.SetRotation(Rotation);
        }

        public override void Draw()
        {
            PlayerSprite.Draw();
            BaseGame.GetSpriteBatch().DrawString(BaseGame.GetDebugFont(),
                                                 PlayerSprite.GetOrigin().ToString(),
                                                 Vector2.One * 5,
                                                 Color.White);
        }
    }
}

    