using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class DataBase
    {
        private static ICollection<UserData> Users = new List<UserData>()
        {
            new UserData()
            {
                Byte1 = 64,
                Byte2 = 76,
                Byte3 = 192,
                Byte4 = 73,
                /*Rooms = new List<int>()
                {
                    1,3,4,8
                }*/
            },
            new UserData()
            {
            Byte1 = 43,
            Byte2 = 46,
            Byte3 = 228,
            Byte4 = 137
            /*Rooms = new List<int>()
            {11
                1,3,4,8
            }*/
        }
        };

        public static bool ValidateUser(byte byte1, byte byte2, byte byte3, byte byte4, int room)
        {
            foreach (var userData in Users)
            {
                if(userData.Byte1 == byte1)
                    if(userData.Byte2 == byte2)
                        if(userData.Byte3 == byte3)
                            if(userData.Byte4 ==byte4)
                                //if (userData.Rooms.Contains(room))
                                    return true;
            }

            return true;
        }
    }
}
