using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InlamningUppgift_ConsoleApp_P3
{
    public class Forest
    {
        public string CurrentDirection { get; set; }
        public Forest()
        {
            CurrentDirection = "start";
        }
        public void Go(string direction)
        {
            CurrentDirection = direction;
        }
        public string GetCurrentLocation()
        {
            return CurrentDirection;
        }
    }
}

