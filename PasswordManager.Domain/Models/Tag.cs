namespace PasswordManager.Domain.Models
{
    public class Tag : DomainObject
    {
        public string Name { get; set; }
        public List<RecordTag> RecordTags { get; set; } = new List<RecordTag>();
    }
}