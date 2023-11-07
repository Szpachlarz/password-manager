using password_manager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password_manager.Domain.Commands
{
    public interface IUpdateRecordCommand
    {
        Task Execute(Record record);
    }
}
