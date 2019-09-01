using wooliesx.model.models;

namespace wooliesx.service.services
{
    /// <summary>
    /// Get User 
    /// </summary>
    public class Exercise1Service : IExercise1Service
    {
        /// <summary>
        /// Returns user response
        /// </summary>
        public UserResponse GetUser()
        {
            var userResponse = new UserResponse() { Name = "Jasmine Kaur", Token = "1234-455662-22233333-3333" };

            return userResponse;
        }
    }
}
