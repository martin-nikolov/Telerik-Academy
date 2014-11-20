namespace ForumSystem.Data.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public abstract class DeletableEntity : AuditInfo, IDeletableEntity
    {
        [Editable(false)]
        public bool IsDeleted { get; set; }

        [Editable(false)]
        public DateTime? DeletedOn { get; set; }
    }
}