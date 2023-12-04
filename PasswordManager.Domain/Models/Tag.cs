using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Models
{
    public class Tag : DomainObject
    {
        public string Name { get; set; }
        public List<RecordTag> RecordTags { get; set; } = new List<RecordTag>();
    }
}