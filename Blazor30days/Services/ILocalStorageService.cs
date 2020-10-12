using System.Threading.Tasks;

namespace Blazor30days.Services
{
    public interface ILocalStorageService
    {
        Task<T> GetItemAsync<T>(string key);

        Task SetItemAsync<T>(string key, T value);

        Task RemoveItemAsync(string key);

        T GetItem<T>(string key);
        void SetItem<T>(string key, T value);
    }
}