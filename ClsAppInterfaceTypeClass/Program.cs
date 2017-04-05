using ClsAppInterfaceTypeClass.Models;
using System.Data.SqlClient;
namespace ClsAppInterfaceTypeClass
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Server=.\\SQLExpress;Database=Database;User Id=sa;Password=senha;MultipleActiveResultSets=true;");
            DalTransaction dal = new DalTransaction(connection);

            //INSERT --------------------------------------------------------------------
            //TransactionChip chip = new TransactionChip()
            //{
            //    Id = 0,
            //    Description = "Chip 001",
            //    Value = 120M
            //};

            //TransactionTarja tarja = new TransactionTarja()
            //{
            //    Id = 0,
            //    Number = "001-2569-96",
            //    Value = 120M
            //};


            //chip = (TransactionChip)dal.Insert(chip);
            //tarja = (TransactionTarja)dal.Insert(tarja);


            //EDIT --------------------------------------------------------------------
            //TransactionChip chip = new TransactionChip()
            //{
            //    Id = 1,
            //    Description = "Chip 001 - UPDATE",
            //    Value = 300.69M
            //};
            //bool result = dal.Edit(chip);



            //FIND --------------------------------------------------------------------
            //TransactionChip tChip = (TransactionChip)dal.Find(1);
            //TransactionTarja tTarja = (TransactionTarja)dal.Find(2);

        }
    }
}
