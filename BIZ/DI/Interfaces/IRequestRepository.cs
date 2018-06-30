using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO.Models.Request;
namespace BIZ.DI.Interfaces
{
    public interface IRequestRepository
    {
        IEnumerable<Request> GetRequests();
        Request GetRequest(int id);
    }
}
