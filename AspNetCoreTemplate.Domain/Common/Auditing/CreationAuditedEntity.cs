using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Domain.Common.Auditing
{
    public abstract class CreationAuditedEntity<TKey>
        : Entity<TKey>,
          IHasCreationTime,
          IHasCreator<string>
    {
        public DateTime CreationTime { get; set; }

        public string? CreatorId { get; set; }
    }
}
