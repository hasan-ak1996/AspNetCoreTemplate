using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Domain.Common.Auditing
{
    public interface IHasDeleter<TKey>
    {
        TKey DeleterId { get; set; }
    }
}
