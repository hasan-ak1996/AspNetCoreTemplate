using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Domain.Common.Auditing
{
    public abstract class FullAuditedEntity<TKey>
        : AuditedEntity<TKey>,
          ISoftDelete,
          IHasDeletionTime,
          IHasDeleter<string>
    {
        public bool IsDeleted { get; protected set; }

        public DateTime? DeletionTime { get; set; }

        public string? DeleterId { get; set; }
    }
}
