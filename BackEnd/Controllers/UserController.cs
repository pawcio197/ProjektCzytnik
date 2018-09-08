using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BackEnd.Models.User;
using DataAccess;
using WebGrease.Css.Extensions;

namespace BackEnd.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/User
        [HttpPost]
        public UserValidateUserResponse ValidateUser(UserValidateUserRequest request)
        {
            

            return new UserValidateUserResponse()
            {
                Success = DataBase.ValidateUser(
                    request.Bytes[0],
                    request.Bytes[1],
                    request.Bytes[2],
                    request.Bytes[3],
                    request.RoomId
                    )
            };
        }

        // GET: api/User/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
