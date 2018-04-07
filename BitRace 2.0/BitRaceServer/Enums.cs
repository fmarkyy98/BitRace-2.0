﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitRaceServer
{
    class Enums
    {
        public enum Difficulty
        {
            easy,
            normal,
            hard
        }

        public enum ConnectionState
        {
            disconnected,
            building,
            connected
        }
    }
}
