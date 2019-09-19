using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDI.In.Archiver.Repositories
{
    public interface IDbHelper
    {
        Task<int> Insert<T>(IEnumerable<T> items);
    }
}
