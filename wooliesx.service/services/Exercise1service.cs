using System;
using System.Threading.Tasks;
using wooliesx.model.models;

namespace wooliesx.service.services
{
    public class Exercise1service : IExercise1service
    {
        public UserResponse GetUser()
        {
            var userResponse = new UserResponse() { Name = "test", Token = "1234-455662-22233333-3333" };

            return userResponse;
        }
    }
}
