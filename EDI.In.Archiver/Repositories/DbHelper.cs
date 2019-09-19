using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EDI.In.Archiver.Repositories
{
    public class DbHelper : IDbHelper
    {
        public Task<int> Insert<T>(IEnumerable<T> items)
        {
            return Task.FromResult(0);
        }
    }
}
