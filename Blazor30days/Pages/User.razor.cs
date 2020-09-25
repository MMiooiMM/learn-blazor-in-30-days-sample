using System.Linq;
using Blazor30days.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging;

namespace Blazor30days.Pages
{
    public partial class User
    {
        [Inject]
        private ILogger<User> Logger { get; set; }

        private EditContext editContext;
        private UserViewModel user = new UserViewModel();

        protected override void OnInitialized()
        {
            editContext = new EditContext(user);
        }

        private void HandleSubmit()
        {
            if (editContext.Validate())
            {
                Logger.LogInformation($"Success: {user.ToString()}");
            }
            else
            {
                Logger.LogInformation($"Fail: {editContext.GetValidationMessages()?.Aggregate((x, y) => $"{x}, {y}")}");
                // var a = editContext.GetValidationMessages(accessor: () => editContext.Model.Address).ToList();
                var b = editContext.GetValidationMessages(new FieldIdentifier(editContext.Model, "Name")).ToList();
                var bd = editContext.GetValidationMessages(new FieldIdentifier(editContext.Model, "Email")).ToList();
                var c = editContext.GetValidationMessages().ToList();
            }
        }
    }
}