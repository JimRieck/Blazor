
using Revver.Interviews.Blazor.Services;
using System.Threading.Tasks;

namespace Revver.Interviews.API.Services
{
    public class UserService
    {
        public async Task RegisterAsync(UserForRegistrationDto user) 
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