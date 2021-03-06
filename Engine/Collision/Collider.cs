﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pedestrian.Engine.Graphics;
using System;
using System.Collections.Generic;

namespace Pedestrian.Engine.Collision
{
    public abstract class Collider
    {
        protected Rectangle bounds;
        protected Vector2 position;
        protected bool invalidBounds = true;

        public int Width { get; set; }
        public int Height { get; set; }
        public Vector2 Offset { get; set; } = Vector2.Zero;
        public IEntity[] PreviousCollidingEntities { get; set; } = new IEntity[] { };
        public IEntity[] CurrentCollidingEntities { get; set; } = new IEntity[] { };
        public Action<IEnumerable<IEntity>> OnCollisionEntered { get; set; }
        public Action<IEnumerable<IEntity>> OnCollision { get; set; }
        public Action<IEnumerable<IEntity>> OnCollisionExited { get; set; }
        
        // Defines which categories of colliders this collider can collide with
        // By default it will collide with all categories of colliders
        public Enum CollisionFilter { get; set; }
        public Enum Category { get; set; }

        public Rectangle Bounds
        {
            get
            {
                if (invalidBounds)
                {
                    bounds = new Rectangle(
                        (int)(Position.X + Offset.X - Width / 2),
                        (int)(Position.Y + Offset.Y - Height / 2),
                        Width,
                        Height
                    );
                    invalidBounds = false;
                }
                return bounds;
            }
        }

        public Vector2 Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
                invalidBounds = true;
            }
        }

        public Collider(Enum category, Enum collisionFilter)
        {
            Category = category;
            CollisionFilter = collisionFilter;
        }

        public abstract bool Collides(BoxCollider other);
        public abstract bool Collides(ContainerCollider other);
        public bool Collides(Collider other)
        {
            return Collides((dynamic)other);
        }

        public void Clear()
        {
            Array.Clear(CurrentCollidingEntities, 0, CurrentCollidingEntities.Length);
            Array.Clear(PreviousCollidingEntities, 0, PreviousCollidingEntities.Length);
        }

        public void SetCollisionFilter(Enum categories)
        {
            CollisionFilter = categories;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, Color.Red);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Color color)
        {
            Border.Draw(
                spriteBatch,
                Bounds,
                color
            );
        }
    }
}
