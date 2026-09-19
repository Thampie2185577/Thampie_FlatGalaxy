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
        void SetX(int x);
        void SetY(int y);
        void SetVx(double vx);
        void SetVy(double vy);
        void SetColor(string color);
        void SetRadius(int radius);
        void SetOnCollision(string onCollision);
    }
}
