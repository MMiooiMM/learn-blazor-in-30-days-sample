using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace Blazor30days.Pages
{
    public partial class Counter
    {
        [Inject]
        private ILogger<Counter> Logger { get; set; }

        private int currentCount = 0;

        private void IncrementCount()
        {
            currentCount++;
            Logger.LogInformation(currentCount.ToString());
        }
    }
}