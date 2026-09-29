using FlatGalaxySim.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySim.Builder
{
    public interface ICelestialBuilder
    {
        void Reset();
        void SetType(string type);
        void SetName(string name);
        void SetX(double x);
        void SetY(double y);
        void SetVx(double vx);
        void SetVy(double vy);
        void SetColor(string color);
        void SetRadius(int radius);
        void SetState(string onCollision);
    }
}
