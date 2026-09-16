using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Domain.Common.Auditing
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; }
    }
}
