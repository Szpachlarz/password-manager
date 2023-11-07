using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password_manager.Domain.Commands
{
    public interface IDeleteRecordCommand
    {
        Task Execute(Guid recordId);
    }
}
