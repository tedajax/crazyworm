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
        bool collisionon = false; //because if we spawned on top of ourselves with it on we would die instantly, not a very good game
        TimeSpan tocollisionon; //when it hits 0 turn on collision

        public Player()
        {
            Texture2D img = BaseGame.GetContent().Load<Texture2D>("wormhead");
            segmentimg = BaseGame.GetContent().Load<Texture2D>("bodysegment");
            PlayerSprite = new Sprite(img);

            Position = new Vector2(1280 / 2, 720 / 2);

            BodySegments = new List<VisibleActor>();

            tocollisionon = new TimeSpan(0, 0, 1);

            AddSegments(1000);
        }

        public override void Update(GameTime gameTime)
        {
            if (BaseGame.Input.GetKeyPressedState(Keys.Space) == KeyPressedState.JustPressed)
            {
                if (!dead)
                    Death();
                else
                    ReAnimate();
            }

            if (BaseGame.Input.GetKeyPressedState(Keys.LeftControl) == KeyPressedState.Pressed)
                AddSegments(1);          

            if (!dead)
            {
                if (tocollisionon.TotalMilliseconds > 0)
                {
                    tocollisionon -= gameTime.ElapsedGameTime;
                    if (collisionon)
                        TurnOffCollision();
                }

                if (tocollisionon.TotalMilliseconds <= 0 && !collisionon) TurnOnCollision();

                if (BaseGame.GetInMan().GetKeyPressedState(Keys.Left) == KeyPressedState.Pressed)
                    Rotation -= rotspeed;
                if (BaseGame.GetInMan().GetKeyPressedState(Keys.Right) == KeyPressedState.Pressed)
                    Rotation += rotspeed;

                //Keep rotation within 0 - 2pi range
                Rotation = BaseGame.WrapValueRadian(Rotation);

                Velocity.X = speed * (float)Math.Cos((double)Rotation);
                Velocity.Y = speed * (float)Math.Sin((double)Rotation);

                UpdateSegments(gameTime);

                Position += Velocity;

                PlayerSprite.SetPosition(Position);
                PlayerSprite.SetRotation(Rotation);
            }
            else
            {
                UpdateInDeath(gameTime);
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
                if (BodySegments.Count >= 50)
                {
                    //Collision objects positions are relative to the position of the actor not the world coordinates
                    BodySegments[i].AddCollCirc(new BoundingCircle(new Vector2(segmentimg.Width / 2, segmentimg.Height / 2), segmentimg.Width / 2));
                    if (!collisionon)
                        BodySegments[i].SetSolid(false);
                    else
                        BodySegments[i].SetSolid(true);
                }
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

        private void TurnOnCollision()
        {
            collisionon = true;
            if (BodySegments.Count > 50)
            {
                for (int i = 49; i < BodySegments.Count; i++)
                {
                    BodySegments[i].SetSolid(true);
                }
            }
        }

        private void TurnOffCollision()
        {
            collisionon = false;
            if (BodySegments.Count > 50)
            {
                for (int i = 49; i < BodySegments.Count; i++)
                {
                    BodySegments[i].SetSolid(false);
                }
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
            collisionon = false;
            tocollisionon = new TimeSpan(0, 0, 1);

            for (int i = 0; i < BodySegments.Count; i++)
            {
                float mult = BaseGame.Rand.Next(2, 5);
                BodySegments[i].SetVelocity(new Vector2(mult * (float)Math.Cos((double)(BaseGame.Rand.NextDouble() * MathHelper.TwoPi)),
                                                        mult * (float)Math.Sin((double)(BaseGame.Rand.NextDouble() * MathHelper.TwoPi))));
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

        public void UpdateInDeath(GameTime gameTime)
        {
            if (!reanimating)
            {
                foreach (VisibleActor v in BodySegments)
                {
                    v.Update(gameTime);
                }

                Position = Vector2.Lerp(Position, new Vector2(1280 / 2, 720 / 2), 0.1f);
                Rotation = MathHelper.Lerp(Rotation, 0, 0.1f);

                //Keep rotation within 0 - 2pi range
                Rotation = BaseGame.WrapValueRadian(Rotation);

                PlayerSprite.SetPosition(Position);
                PlayerSprite.SetRotation(Rotation);
            }
            else
            {
                reanimating = false;
                dead = false;
                foreach (VisibleActor v in BodySegments)
                {
                    v.SetPosition(Vector2.Lerp(v.GetPosition(), Position, 0.1f));
                    if (Vector2.Distance(v.GetPosition(), Position) > 0.75f)
                    {
                        reanimating = true;
                        dead = true;
                    }

                    v.Update(gameTime);
                }
            }
        }
    }
}

    