using System;
using System.Collections.Generic;
using System.Text;

namespace AspNetCoreTemplate.Application.Contract.Common.Authorization
{
    public interface ICurrentUser
    {
        string? Id { get; }
        bool IsAuthenticated { get; }
    }
}
