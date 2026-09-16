using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Domain.Common.Auditing
{
    public interface IHasCreator<TKey>
    {
        TKey CreatorId { get; set; }
    }
}
