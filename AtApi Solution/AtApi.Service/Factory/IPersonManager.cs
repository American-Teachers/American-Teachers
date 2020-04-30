using AtApi.Model;
using System.Threading.Tasks;

namespace AtApi.Service.Factory
{
    public interface IPersonManager
    {
        Task<PersonResponse> CreateAsync(PersonRequest personRequest);
    }
}
