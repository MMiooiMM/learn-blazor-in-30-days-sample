using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Blazor30days.Services
{
    public class LocalStorageService : ILocalStorageService
    {
        private readonly IJSRuntime _jsRuntime;

        public LocalStorageService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<T> GetItemAsync<T>(string key)
        {
            var json = await _jsRuntime.InvokeAsync<string>("localStorage.getItem", key);

            if (json == null)
                return default;

            return JsonSerializer.Deserialize<T>(json);
        }

        public async Task SetItemAsync<T>(string key, T value)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.setItem", key, JsonSerializer.Serialize(value));
        }

        public async Task RemoveItemAsync(string key)
        {
            await _jsRuntime.InvokeVoidAsync("localStorage.removeItem", key);
        }

        public T GetItem<T>(string key)
        {
            var js = (IJSInProcessRuntime)_jsRuntime;
            var json = js.Invoke<string>("localStorage.getItem", key);

            if (json == null)
                return default;

            return JsonSerializer.Deserialize<T>(json);
        }

        public void SetItem<T>(string key, T value)
        {
            var js = (IJSInProcessRuntime)_jsRuntime;
            js.InvokeVoid("localStorage.setItem", key, JsonSerializer.Serialize(value));
        }
    }
}