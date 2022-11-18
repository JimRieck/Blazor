

namespace Revver.Interviews.Blazor.API.Services
{
    public class UserService
    {
        public async Task RegisterAsync(dynamic user) 
        {
            if (user.ConfirmPassword != user.Password)
            {
                return;
            }
            if (user.Email != user.Email)
            {
                return;
            }
            await Task.Delay(200000);
        }
    }
}