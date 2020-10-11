using System.Threading.Tasks;

namespace Blazor30days.Services
{
    public interface IAuthService
    {
        Task<bool> Check();
    }
}