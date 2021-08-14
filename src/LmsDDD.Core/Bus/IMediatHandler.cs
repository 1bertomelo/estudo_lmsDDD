using LmsDDD.Core.Messages;
using System.Threading.Tasks;

namespace LmsDDD.Core.Bus
{
    public interface IMediatrHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
    }
}
