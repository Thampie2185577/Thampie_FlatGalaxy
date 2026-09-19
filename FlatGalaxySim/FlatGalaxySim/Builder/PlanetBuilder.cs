using FlatGalaxySim.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySim.Builder
{
    public class PlanetBuilder : ICelestialBuilder
    {
        private Planet planet = new  Planet();
        public void Reset()
        {
            planet = new Planet();
        }

        public void SetName(string name) => planet.Name = name;

        public void SetType(string type) => planet.Type = type;

        public void SetX(int x)
        {
            var position = planet.Position;
            position.x = x;
            planet.Position = position;
        }

        public void SetY(int y)
        {
            var position = planet.Position;
            position.y = y;
            planet.Position = position;
        }

        public void SetVx(double vx)
        {
            var velocity = planet.Velocity;
            velocity.vx = vx;
            planet.Velocity = velocity;
        }

        public void SetVy(double vy)
        {
            var velocity = planet.Velocity;
            velocity.vy = vy;
            planet.Velocity = velocity;
        }

        public void SetColor(string color)
        {
            planet.BodyColor = new BodyColor(color);
        }

        public void SetRadius(int radius)
        {
            planet.Raduis = (int)radius;
        }

        public void SetOnCollision(string onCollision)
        {
            planet.OnCollision = onCollision;
        }

        public Planet GetResult()
        {
            return planet;
        }
    }
}