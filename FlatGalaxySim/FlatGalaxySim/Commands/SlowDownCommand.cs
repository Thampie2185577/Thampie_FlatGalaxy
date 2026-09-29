using FlatGalaxySim.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySim.Commands
{
    public class SlowDownCommand : Command
    {
        public SlowDownCommand(FlatGalaxy reciever) : base(reciever)
        {
        }

        public override void Execute()
        {
           reciever.RunSimSlower();
        }
    }
}
