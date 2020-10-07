using Microsoft.JSInterop;

namespace Blazor30days.Services
{
    public class Day22SampleService
    {
        [JSInvokable]
        public int Sum(int a, int b) => a + b;
    }
}