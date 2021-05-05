using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace API.Infrastructure
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; } = null;
        public T Data { get; set; }
        public CauseEnum Cause { get; set; }

        public
            enum CauseEnum
        {
            NOT_FOUND,
            BAD_REQUEST
        }
    }
}