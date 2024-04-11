

namespace Domain.Common
{
    public abstract class AuditableEnitity
    {
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime LastModified { get; set; }
        public string? LastModifiedBy { get; set;}
    }
}
