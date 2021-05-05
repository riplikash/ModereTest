using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using API.Infrastructure;
using API.Model;

namespace API.Domain
{
    public interface ISchoolService
    {
        Task<ServiceResponse<SchoolClass>> GetAsync(string className, CancellationToken token);
    }
}