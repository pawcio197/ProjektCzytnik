using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace DataAccess
{
    public class UserData
    {
        public byte Byte1 { get; set; }
        public byte Byte2 { get; set; }
        public byte Byte3 { get; set; }
        public byte Byte4 { get; set; }
        public List<int> Rooms { get; set; }

    }
}
