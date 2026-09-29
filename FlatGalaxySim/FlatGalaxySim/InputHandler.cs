using FlatGalaxySim.Commands;
using FlatGalaxySim.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlatGalaxySim
{
    public class InputHandler
    {
        private Dictionary<Key, Command> KeyMap = [];

        public void SetDefaultKeys(FlatGalaxy reciever)
        {
            KeyMap[Key.F] = new SpeedUpCommand(reciever);
            KeyMap[Key.D] = new SlowDownCommand(reciever);
            KeyMap[Key.Space] = new PauseResumeCommand(reciever);
            KeyMap[Key.R] = new RewindCommand(reciever);
            KeyMap[Key.T] = new ToggleCollisionStrategyCommand(reciever);
        }

        public void OnkeyDown(object sender, KeyEventArgs e)
        {
            Command cmd = KeyMap[e.Key];
            cmd.Execute();
        }
    }
}
