using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Request
{
    /// <summary>
    /// This is just a marker interface to mark a request as a certain type.
    /// A request represents a request from the client to perform an action.
    /// Requests must be validated to be "valid" before they may be executed. 
    /// For this purpose we use FluentValidation nuGet package
    /// </summary>
    public interface IRequest
    {
    }
}
