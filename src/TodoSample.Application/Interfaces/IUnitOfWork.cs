using System.Threading.Tasks;

namespace TodoSample.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();

        int Save();
    }
}
