using ShopsRU.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.DTOs
{
    public class UserDto : BaseResponse
    {
        public Guid Id { get; set; }

        public bool IsGrocery { get; set; }

        public decimal Amount { get; set; }

    }
}
