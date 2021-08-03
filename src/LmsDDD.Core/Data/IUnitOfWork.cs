
using System.Threading.Tasks;

namespace LmsDDD.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
