using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BitRacePlayer.Enums;
using static BitRacePlayer.Enums.ConnectionState;
using static BitRacePlayer.Enums.ConnectionType;

namespace BitRacePlayer
{
    static class Enums
    {
        public enum ConnectionState
        {
            disconnected,
            building,
            connected
        }
        public enum ConnectionType
        {
            MSSQL,
            TCPIP
        }

        public static ConnectionState ToConnectionState(string s)
        {
            if (s == "disconnected")
            {
                return disconnected;
            }
            if (s == "building")
            {
                return building;
            }
            if (s=="connected")
            {
                return connected;
            }
            throw new InvalidCastException();
        }

        public static ConnectionType ToConnectionType(string s)
        {
            if (s == "mssql")
            {
                return MSSQL;
            }
            if (s == "tcpip")
            {
                return TCPIP;
            }
            throw new InvalidCastException();
        }
    }
}
