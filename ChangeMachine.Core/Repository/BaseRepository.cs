using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Repository
{
    public abstract class BaseRepository
    {
        protected string connectionString;

        protected BaseRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
