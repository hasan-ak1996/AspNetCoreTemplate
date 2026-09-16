using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Domain.Common.Auditing
{
    public abstract class AuditedEntity<TKey>
        : CreationAuditedEntity<TKey>,
          IHasModificationTime,
          IHasModifier<string>
    {
        public DateTime? LastModificationTime { get; set; }

        public string? LastModifierId { get; set; }
    }
}
