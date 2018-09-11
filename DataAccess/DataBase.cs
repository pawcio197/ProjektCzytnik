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
                id0 = 64,
                id1 = 76,
                id2 = 192,
                id3 = 73,
                /*Rooms = new List<int>()
                {
                    1,3,4,8
                }*/
            },
            new UserData()
            {
            id0 = 43,
            id1 = 46,
            id2 = 228,
            id3 = 137
            /*Rooms = new List<int>()
            {11
                1,3,4,8
            }*/
        }
        };

        public static bool ValidateUser(int byte1, int byte2, int byte3, int byte4)
        {
            foreach (var userData in Users)
            {
                if(userData.id0 == byte1)
                    if(userData.id1 == byte2)
                        if(userData.id2 == byte3)
                            if(userData.id3 == byte4)
                                //if (userData.Rooms.Contains(room))
                                    return true;
            }

            return false;
        }
    }
}
