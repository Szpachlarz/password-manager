using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using password_manager.Domain.Models;

namespace password_manager.Domain.Queries
{
    public interface IGetAllRecordsQuery
    {
        Task<IEnumerable<Record>> Execute();
    }
}
