using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace CrazyWorm
{
    public abstract class Entity
    {
        protected Vector2 Position; //2D position
        protected Vector2 Velocity; //Change position by this much
        protected Vector2 Origin; //Where to rotate around on the entity
        protected Vector2 Scale; //(1, 1) would be default scaling, (2, 2) would be twice as large, (0.5f, 0.5f) half size
        protected float Rotation; //angle, top-down rotation in radians

        protected Vector2 ResScaler; //Scaler for position, scale, and velocity based on resolution

        public abstract void Update(GameTime gameTime);
        public abstract void Draw();

        //Returns position multiplied by resolution scaler
        public Vector2 ResPosition() { return Position * BaseGame.GetResScaler(); }
        public Vector2 ResVelocity() { return Velocity * BaseGame.GetResScaler(); }
        public Vector2 ResOrigin() { return Origin * BaseGame.GetResScaler(); }
        public Vector2 ResScale() { return Scale * BaseGame.GetResScaler(); }
        //no need to scale rotation

        //Accessors
        public Vector2 GetPosition() { return Position; }
        public Vector2 GetVelocity() { return Velocity; }
        public Vector2 GetOrigin() { return Origin; }
        public Vector2 GetScale() { return Scale; }
        public float GetRotation() { return Rotation; }
        public Vector2 GetResScaler() { return ResScaler; } //why not

        //Mutators
        public void SetPosition(Vector2 pos) { Position = pos; }
        public void SetVelocity(Vector2 vel) { Velocity = vel; }
        public void SetOrigin(Vector2 orgn) { Origin = orgn; }
        public void SetScale(Vector2 scl) { Scale = scl; }
        public void SetRotation(float rot) { Rotation = rot; }
        public void SetResScaler(Vector2 rscl) { ResScaler = rscl; } //again, why not
    }
}
