using FlatGalaxySim.Entities;
using FlatGalaxySim.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySim.Memento
{
    public class BodyMemento
    {
        public CelestialBody Body { get; }
        public Position Position { get; }
        public Velocity Velocity { get; }
        public int Radius { get; }
        public bool IsDrawable { get; }
        public bool IsColliding { get; }
        public bool WasColliding { get; }
        public State? CollisionState { get; }


        public BodyMemento(CelestialBody body, Position position, Velocity velocity, int radius,
        bool isDrawable, bool isColliding, bool wasColliding, State? collisionState)
        {
            Body = body;
            Position = position;
            Velocity = velocity;
            Radius = radius;
            IsDrawable = isDrawable;
            IsColliding = isColliding;
            WasColliding = wasColliding;
            CollisionState = collisionState;
        }
    }
}
