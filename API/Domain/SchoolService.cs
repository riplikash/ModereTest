using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using API.Infrastructure;
using API.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Domain
{
    public class SchoolService : ISchoolService
    {
        private readonly ISchoolContext _context;

        public SchoolService(ISchoolContext context)
        {
            this._context = context;
        }

        public async Task<ServiceResponse<SchoolClass>> GetAsync(string className, CancellationToken token)
        {
            className = className.ToLower();
            if (string.IsNullOrEmpty(className))
                return new ServiceResponse<SchoolClass>() { Data = null, Message = $"Invalid class name. Class name can not be null.", Success = false, Cause = ServiceResponse<SchoolClass>.CauseEnum.BAD_REQUEST};
            var c = await _context.Classes.FirstOrDefaultAsync(x => x.Name.ToLower() == className, cancellationToken: token);
            return c == null ? new ServiceResponse<SchoolClass>() {Data = new SchoolClass() {Name = className}, Message = $"Could not find class {className}.", Success = false, Cause = ServiceResponse<SchoolClass>.CauseEnum.NOT_FOUND} 
                : new ServiceResponse<SchoolClass>() {Data = c, Success = true};
        }
    }
}