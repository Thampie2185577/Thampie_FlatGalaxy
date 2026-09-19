using FlatGalaxySim.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySim.Builder
{
    public class AsteroidBuilder : ICelestialBuilder
    {
        private Asteroid asteroid = new Asteroid();

        public void Reset()
        {
            asteroid = new Asteroid();
        }

        public void SetType(string type) => asteroid.Type = type;

        public void SetX(int x)
        {
            var position = asteroid.Position;
            position.x = x;
            asteroid.Position = position;
        }
        
        public void SetY(int y)
        {
            var position = asteroid.Position; 
            position.y = y;
            asteroid.Position = position;
        }

        public void SetVx(double vx)
        {
           var velocity = asteroid.Velocity;
           velocity.vx = vx;
           asteroid.Velocity = velocity;
        }

        public void SetVy(double vy)
        {
            var velocity = asteroid.Velocity;
            velocity.vy = vy;
            asteroid.Velocity = velocity;   
        }

        public void SetColor(string color)
        {
            asteroid.BodyColor = new BodyColor(color);
        }

        public void SetRadius(int radius)
        {
            asteroid.Raduis = (int)radius;
        }

        public void SetOnCollision(string onCollision)
        {
            asteroid.OnCollision = onCollision;
        }

        public void SetState(string state)
        {
            //asteroid.State = state;
        }

        public Asteroid GetResult()
        {
            return asteroid;
        }

    }
}