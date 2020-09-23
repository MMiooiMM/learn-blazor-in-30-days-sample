using Blazor30days.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace Blazor30days.Pages
{
    public partial class User
    {
        [Inject]
        private ILogger<User> Logger { get; set; }

        private UserViewModel user = new UserViewModel();

        private void HandleValidSubmit()
        {
            Logger.LogInformation($"Success: {user.ToString()}");
        }
    }
}