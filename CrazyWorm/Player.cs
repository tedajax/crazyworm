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
        List<VisibleActor> BodySegments;
        Texture2D segmentimg;

        float speed = 5; //speed multiplier
        float rotspeed = MathHelper.Pi / 32f; //rotation speed

        bool dead = false; //you would hopefully start out alive, otherwise it's not a very fun game
        bool reanimating = false; //just for giggles, will allow an animation to be played of the segments going back to the player if they're reanimated, why they would be reanimated I have no idea

        public Player()
        {
            Texture2D img = BaseGame.GetContent().Load<Texture2D>("wormhead");
            segmentimg = BaseGame.GetContent().Load<Texture2D>("bodysegment");
            PlayerSprite = new Sprite(img);

            Position = new Vector2(1280 / 2, 720 / 2);

            BodySegments = new List<VisibleActor>();

            AddSegments(1000);
        }

        public override void Update(GameTime gameTime)
        {
            if (BaseGame.Input.GetKeyPressedState(Keys.Space) == KeyPressedState.JustPressed)
                if (!dead)
                    Death();
                else
                    ReAnimate();

            if (BaseGame.Input.GetKeyPressedState(Keys.LeftControl) == KeyPressedState.Pressed)
                AddSegments(1);

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
            else
            {
                if (!reanimating)
                {
                    foreach (VisibleActor v in BodySegments)
                    {
                        v.Update(gameTime);
                    }
                }
                else
                {
                    reanimating = false;
                    dead = false;
                    foreach (VisibleActor v in BodySegments)
                    {
                        v.SetPosition(Vector2.Lerp(v.GetPosition(), Position, 0.1f));
                        if (Vector2.Distance(v.GetPosition(), Position) > 0.1f)
                        {
                            reanimating = true;
                            dead = true;
                        }

                        v.Update(gameTime);
                    }
                }
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
            if (BodySegments.Count > 0)
                startpos = BodySegments[BodySegments.Count - 1].GetPosition();
            else
                startpos = Position;

            for (int i = 0; i < num; i++)
            {
                BodySegments.Add(new VisibleActor(segmentimg, startpos));
            }
        }

        private void UpdateSegments(GameTime gameTime)
        {
            if (BodySegments.Count > 0)
            {
                for (int i = BodySegments.Count - 1; i > 0; i--)
                {
                    BodySegments[i].SetPosition(BodySegments[i - 1].GetPosition());
                    BodySegments[i].Update(gameTime);
                }

                BodySegments[0].SetPosition(Position);
                BodySegments[0].Update(gameTime);
            }
        }

        private void DrawSegments()
        {
            //draw in reverse order because we want the images closest to the head drawn on top
            for (int i = BodySegments.Count - 1; i >= 0; i--)
                BodySegments[i].Draw();
        }

        private void Death()
        {
            dead = true;

            for (int i = 0; i < BodySegments.Count; i++)
            {
                BodySegments[i].SetVelocity(new Vector2((float)Math.Cos((double)(BaseGame.Rand.NextDouble() * MathHelper.TwoPi)),
                                                        (float)Math.Sin((double)(BaseGame.Rand.NextDouble() * MathHelper.TwoPi))));
            }
        }

        //will probably never happen in game... ever
        private void ReAnimate()
        {
            reanimating = true;

            foreach (VisibleActor v in BodySegments)
            {
                v.SetVelocity(Vector2.Zero);
            }
        }
    }
}

    