using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Blazor30days.Pages
{
    public partial class Day13SampleChild
    {
        [Parameter]
        public int Year { get; set; }

        [Parameter]
        public EventCallback<int> YearChanged { get; set; }

        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters);
        }

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine($"{nameof(OnInitializedAsync)},  Start.");
            await Something();
            Console.WriteLine($"{nameof(OnInitializedAsync)}, End.");
        }

        protected override async Task OnParametersSetAsync()
        {
            Console.WriteLine($"{nameof(OnParametersSetAsync)},  Start.");
            await Something();
            Console.WriteLine($"{nameof(OnParametersSetAsync)}, End.");
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                Console.WriteLine($"First {nameof(OnAfterRenderAsync)},  Start.");
                await Something();
                Console.WriteLine($"First {nameof(OnAfterRenderAsync)}, End.");
            }
            else
            {
                Console.WriteLine($"Not First {nameof(OnAfterRenderAsync)},  Start.");
                await Something();
                Console.WriteLine($"Not First {nameof(OnAfterRenderAsync)}, End.");
            }
        }

        protected override bool ShouldRender()
        {
            Console.WriteLine(nameof(ShouldRender));

            var renderUI = true;

            return renderUI;
        }

        private async Task Something()
        {
            await Task.Delay(100);
        }
    }
}