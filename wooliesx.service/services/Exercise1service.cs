using System;
using System.Threading.Tasks;
using wooliesx.model.models;

namespace wooliesx.service.services
{
    public class Exercise1Service : IExercise1Service
    {
        public UserResponse GetUser()
        {
            var userResponse = new UserResponse() { Name = "Jasmine Kaur", Token = "1234-455662-22233333-3333" };

            return userResponse;
        }
    }
}
