using Blazor30daysRCL;
using Bunit;
using Bunit.TestDoubles.JSInterop;
using Microsoft.JSInterop;
using Xunit;

namespace blazor30daysTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // Arrange
            using var ctx = new TestContext();
            var cut = ctx.RenderComponent<Component1>();

            // Act
            var div = cut.Find("div.my-component");

            // Assert
            div.MarkupMatches("<div class=\"my-component\">This Blazor component is defined in the <strong>Blazor30daysRCL</strong> package.</div>");
        }

        [Fact]
        public void Test2()
        {
            // Arrange
            using var ctx = new TestContext();
            var mockJS = ctx.Services.AddMockJSRuntime();
            mockJS.SetupVoid("exampleJsFunctions.showPrompt");
            var JSRuntime = ctx.Services.GetService<IJSRuntime>();

            // Act
            ExampleJsInterop.Prompt(JSRuntime, "message");

            // Assert
            mockJS.VerifyInvoke("exampleJsFunctions.showPrompt");
        }
    }
}