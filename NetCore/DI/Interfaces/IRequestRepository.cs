using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCore.Models.Request;
namespace NetCore.DI.Interfaces
{
    public interface IRequestRepository
    {
        IEnumerable<Request> GetRequests();
        Request GetRequest(int id);
    }
}
