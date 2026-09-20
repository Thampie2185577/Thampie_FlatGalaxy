using FlatGalaxySim.Builder;
using FlatGalaxySim.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySim.Factories
{
    public static class CelestialBodyFactory
    {
        public static CelestialBody CreateCelestialBody(Dictionary<string, string> data)
        {
            ArgumentNullException.ThrowIfNull(data);
            CelestialBody? body = null;

            if (data.ContainsKey("type"))
            {
                string type = data["type"];

                body = (type.ToLower()) switch
                {
                    "planet" => CreatePlanet(data),
                    "asteroid" => CreateAsteroid(data),
                    _ => throw new ArgumentException($"Invalid celestial body type: {type}")
                };
            }
            
            return body ?? throw new ArgumentException("Celestial body could not be created.");
        }


        private static CelestialBody? CreatePlanet(Dictionary<string, string> data)
        {
            if (data == null) return null;

            PlanetBuilder builder = new PlanetBuilder();
            foreach (var value in data)
            {
               switch (value.Key.ToLower())
                {
                    case "name":
                        builder.SetName(value.Value);
                        break;
                    case "type":
                        builder.SetType(value.Value);
                        break;
                    case "x":
                        if (int.TryParse(value.Value, out int x))
                            builder.SetX(x);
                        else
                            throw new ArgumentException($"Invalid value for X: {value.Value}");
                        break;
                    case "y":
                        if (int.TryParse(value.Value, out int y))
                            builder.SetY(y);
                        else
                            throw new ArgumentException($"Invalid value for Y: {value.Value}");
                        break;
                    case "vx":
                            builder.SetVx(double.Parse(value.Value, System.Globalization.CultureInfo.InvariantCulture));
                        break;
                    case "vy":
                           builder.SetVy(double.Parse(value.Value, System.Globalization.CultureInfo.InvariantCulture));
                        break;
                    case "color":
                        builder.SetColor(value.Value);
                        break;
                    case "radius":
                        if (int.TryParse(value.Value, out int radius))
                            builder.SetRadius(radius);
                        else
                            throw new ArgumentException($"Invalid value for Radius: {value.Value}");
                        break;
                    case "oncollision":
                        break;
                }
            }
            return builder.GetResult();
        }

        private static CelestialBody? CreateAsteroid(Dictionary<string, string> data)
        {
            // Implement asteroid creation logic here
            if (data == null) return null;

            AsteroidBuilder builder = new AsteroidBuilder();
            foreach (var value in data)
            {
                if(value.Key == "name" || value.Key == "neighbours") continue; // Skip name for asteroid, as it may not be relevant

                switch (value.Key.ToLower())
                {
                    case "type":
                        builder.SetType(value.Value);
                        break;
                    case "x":
                        if (int.TryParse(value.Value, out int x))
                            builder.SetX(x);
                        else
                            throw new ArgumentException($"Invalid value for X: {value.Value}");
                        break;
                    case "y":
                        if (int.TryParse(value.Value, out int y))
                            builder.SetY(y);
                        else
                            throw new ArgumentException($"Invalid value for Y: {value.Value}");
                        break;
                    case "vx":
                        if (double.TryParse(value.Value, out double vx))
                            builder.SetVx(vx);
                        else
                            throw new ArgumentException($"Invalid value for VX: {value.Value}");
                        break;
                    case "vy":
                        if (double.TryParse(value.Value, out double vy))
                            builder.SetVy(vy);
                        else
                            throw new ArgumentException($"Invalid value for VY: {value.Value}");
                        break;
                    case "color":
                        builder.SetColor(value.Value);
                        break;
                    case "radius":
                        if (int.TryParse(value.Value, out int radius))
                            builder.SetRadius(radius);
                        else
                            throw new ArgumentException($"Invalid value for Radius: {value.Value}");
                        break;
                    case "oncollision":
                        builder.SetOnCollision(value.Value);
                        break;
                }
                
            }

            return builder.GetResult();
        }
    }
}
