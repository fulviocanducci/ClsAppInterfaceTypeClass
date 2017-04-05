namespace ClsAppInterfaceTypeClass.Models
{
    public class TransactionChip : ITransaction
    {
        public int Id { get; set; }
        public decimal Value { get; set; }

        public string Description { get; set; }
    }
}
