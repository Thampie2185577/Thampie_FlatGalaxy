using FlatGalaxySim.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySim.Commands
{
    public class SpeedUpCommand : Command
    {
        public SpeedUpCommand(FlatGalaxy reciever) : base(reciever)
        {
        }

        public override void Execute()
        {
            reciever.RunSimFaster();
        }
    }
}
