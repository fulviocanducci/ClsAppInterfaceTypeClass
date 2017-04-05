using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsAppInterfaceTypeClass.Models
{
    public interface ITransaction
    {
        int Id { get; set; }
        decimal Value { get; set; }
    }
}
