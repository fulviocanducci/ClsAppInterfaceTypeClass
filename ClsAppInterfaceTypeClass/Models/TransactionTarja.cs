using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClsAppInterfaceTypeClass.Models
{
    public class TransactionTarja: ITransaction
    {
        public int Id { get; set; }
        public decimal Value { get; set; }

        public string Number { get; set; }
    }
}
