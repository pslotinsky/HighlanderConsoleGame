using HelloWorldConsole.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldConsole.Events
{
    public class GameEndedEventArgs : EventArgs
    {
        public Unit? Winner { get; set; }
    }
}
