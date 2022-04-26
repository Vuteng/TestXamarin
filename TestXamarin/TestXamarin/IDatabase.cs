using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestXamarin
{
    public interface IDatabase
    {
        Task<int> DeleteTaskAsync(Tasks task);
        Task<List<Tasks>> GetTaskAsync();
        Task<int> SaveTaskAsync(Tasks task);
    }
}