using ShopsRU.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.Services
{
    public abstract class CalculateInvoice
    {
        public abstract UserEntity Calculate(decimal amount);
    }
}
