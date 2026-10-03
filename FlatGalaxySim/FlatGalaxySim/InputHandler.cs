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
        private Dictionary<Key, Command> keyMap = [];
        public Dictionary<Key, Command> KeyMapPairs { get { return keyMap; } }

        public void SetDefaultKeys(FlatGalaxy reciever)
        {
            keyMap[Key.F] = new SpeedUpCommand(reciever);
            keyMap[Key.D] = new SlowDownCommand(reciever);
            keyMap[Key.Space] = new PauseResumeCommand(reciever);
            keyMap[Key.R] = new RewindCommand(reciever);
            keyMap[Key.T] = new ToggleCollisionStrategyCommand(reciever);
        }

        public void OnkeyDown(object sender, KeyEventArgs e)
        {
            if (!keyMap.ContainsKey(e.Key)) { return; }
            Command cmd = keyMap[e.Key];
            cmd.Execute();
        }


        public bool ChangeKeys(Key orginalKey, Key newKey)
        {
            if (!KeyMapPairs.ContainsKey(orginalKey)) return false;

            Command command = KeyMapPairs[orginalKey];
            KeyMapPairs.Remove(orginalKey);
            KeyMapPairs[newKey] = command;

            return true;
        }

    }
}
