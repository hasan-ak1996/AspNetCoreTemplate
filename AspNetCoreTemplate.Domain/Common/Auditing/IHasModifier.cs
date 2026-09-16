using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Domain.Common.Auditing
{
    public interface IHasModifier<TKey>
    {
        TKey LastModifierId { get; set; }
    }
}
