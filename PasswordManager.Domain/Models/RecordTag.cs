using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Domain.Models
{
    public class RecordTag
    {
        public Guid RecordId { get; set; }
        public Record Record { get; set; }

        public Guid TagId { get; set; }
        public Tag Tag { get; set; }
    }
}