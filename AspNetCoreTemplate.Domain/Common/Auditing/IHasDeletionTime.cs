using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Domain.Common.Auditing
{
    public interface IHasDeletionTime
    {
        DateTime? DeletionTime { get; set; }
    }
}
