using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Wrappers
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Succeeded = true;
            Errors = new List<string>();
        }

        public BaseResponse(string message)
        {
            Succeeded = false;
            Errors = new List<string> { message };
        }

        public BaseResponse(IEnumerable<string> errors)
        {
            Succeeded = false;
            Errors = errors;
        }

        public bool Succeeded { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
