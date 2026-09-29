using FlatGalaxySim.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySim.Commands
{
    public class RewindCommand : Command
    {
        public RewindCommand(FlatGalaxy reciever) : base(reciever)
        {
        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
