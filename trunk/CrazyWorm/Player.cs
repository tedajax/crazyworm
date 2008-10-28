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
        Texture2D segmentimg;

        float speed = 7; //speed multiplier
        float rotspeed = MathHelper.Pi / 32f; //rotation speed

        bool dead = false; //you would hopefully start out alive, otherwise it's not a very fun game

        public Player()
        {
            Texture2D img = BaseGame.GetContent().Load<Texture2D>("wormhead");
            segmentimg = BaseGame.GetContent().Load<Texture2D>("bodysegment");
            PlayerSprite = new Sprite(img);

            Position = new Vector2(1280 / 2, 720 / 2);

            BodySections = new List<VisibleActor>();

            AddSegments(100);
        }

        public override void Update(GameTime gameTime)
        {
            if (!dead)
            {
                if (BaseGame.GetInMan().GetKeyPressedState(Keys.Left) == KeyPressedState.Pressed)
                    Rotation -= rotspeed;
                if (BaseGame.GetInMan().GetKeyPressedState(Keys.Right) == KeyPressedState.Pressed)
                    Rotation += rotspeed;

                Velocity.X = speed * (float)Math.Cos((double)Rotation);
                Velocity.Y = speed * (float)Math.Sin((double)Rotation);

                UpdateSegments(gameTime);

                Position += Velocity;

                PlayerSprite.SetPosition(Position);
                PlayerSprite.SetRotation(Rotation);
            }
        }

        public override void Draw()
        {
            DrawSegments();
            PlayerSprite.Draw();
            DrawDebugInfo();
        }

        private void DrawDebugInfo()
        {
            BaseGame.GetSpriteBatch().DrawString(BaseGame.GetDebugFont(),
                                                 Position.ToString(),
                                                 Vector2.One * 5,
                                                 Color.White);
        }

        private void AddSegments(int num)
        {
            Vector2 startpos = Vector2.Zero;
            if (BodySections.Count > 0)
                startpos = BodySections[BodySections.Count - 1].GetPosition();
            else
                startpos = Position;

            for (int i = 0; i < num; i++)
            {
                BodySections.Add(new VisibleActor(segmentimg, startpos));
            }
        }

        private void UpdateSegments(GameTime gameTime)
        {
            if (BodySections.Count > 0)
            {
                for (int i = BodySections.Count - 1; i > 0; i--)
                {
                    BodySections[i].SetPosition(BodySections[i - 1].GetPosition());
                    BodySections[i].Update(gameTime);
                }

                BodySections[0].SetPosition(Position);
                BodySections[0].Update(gameTime);
            }
        }

        private void DrawSegments()
        {
            //draw in reverse order because we want the images closest to the head drawn on top
            for (int i = BodySections.Count - 1; i >= 0; i--)
                BodySections[i].Draw();
        }
    }
}

    