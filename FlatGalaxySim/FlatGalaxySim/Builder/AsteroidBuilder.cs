using FlatGalaxySim.Entities;
using FlatGalaxySim.Factories;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public void SetName(string name) => throw new NotImplementedException();
       
        public void SetX(double x)
        {
            var position = asteroid.Position;
            position.x = x;
            asteroid.Position = position;
        }
        
        public void SetY(double y)
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
            asteroid.Radius = (int)radius;
        }

        public void SetState(string state)
        {
            asteroid.OnCollisionState = StateFactory.CreateState(this.asteroid, state);
            
        }

        public Asteroid GetResult()
        {
            return asteroid;
        }

    }
}