using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password_manager.Domain.Models
{
    public class Record
    {
        public Guid RecordId { get; }
        public string Title { get; }
        public string Website { get; }
        public string Email { get; }
        public string Password { get; }
        public string Description { get; }
        public DateTime Created { get; }

        public Record(Guid recordId, string title, string website, string email, string password, string description, DateTime created)
        {
            RecordId = recordId;
            Title = title;
            Website = website;
            Email = email;
            Password = password;
            Description = description;
            Created = created;
        }

    }
}
