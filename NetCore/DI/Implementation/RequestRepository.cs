using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetCore.DI.Interfaces;
using NetCore.Data;
using NetCore.Models.Request;

namespace NetCore.DI.Implementation
{
    public class RequestRepository : IRequestRepository
    {
        private ApplicationDbContext ctx;
        public RequestRepository(ApplicationDbContext applicationDbContext)
        {
            this.ctx = applicationDbContext;
        }
        public IEnumerable<Request> GetRequests()
        {
            var request = ctx.Requests.ToList();
            return request;
        }
        public Request GetRequest(int id)
        {
            var r = ctx.Requests.Find(id);
            return r;
        }
    }
}
