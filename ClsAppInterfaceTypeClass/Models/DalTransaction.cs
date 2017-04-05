using System;
using System.Data;
using System.Data.SqlClient;
namespace ClsAppInterfaceTypeClass.Models
{
    public class DalTransaction
    {
        private SqlConnection _connect;
        public DalTransaction(SqlConnection connect)
        {
            _connect = connect ?? throw new Exception("Conexão inativa, por favor configure");
        }

        public ITransaction Insert(ITransaction transaction)
        {            
            using (SqlCommand command = _connect.CreateCommand())
            {
                if (_connect.State == ConnectionState.Closed) _connect.Open();

                command.CommandText = " INSERT INTO Trans(Value,Description,Number,Type) ";
                command.CommandText += " VALUES(@Value,@Description,@Number,@Type); SELECT @@IDENTITY;";                
                command.Parameters.Add("@Value", SqlDbType.Decimal).Value = transaction.Value;

                ChangeTypeValue(transaction, command); // atributos correspondente a cada classe

                int id = 0;
                if (int.TryParse(command.ExecuteScalar().ToString(), out id))
                {
                    transaction.Id = id;
                }

                if (_connect.State == ConnectionState.Open)  _connect.Close();
            }
            return transaction;
        }

        public bool Edit(ITransaction transaction)
        {
            using (SqlCommand command = _connect.CreateCommand())
            {
                if (_connect.State == ConnectionState.Closed) _connect.Open();

                command.CommandText = " UPDATE Trans SET Value=@Value,Description=@Description,Number=@Number,Type=@Type ";
                command.CommandText += " WHERE Id = @Id ";
                command.Parameters.Add("@Value", SqlDbType.Decimal).Value = transaction.Value;

                ChangeTypeValue(transaction, command); // atributos correspondente a cada classe

                command.Parameters.Add("@Id", SqlDbType.Int).Value = transaction.Id;
                return command.ExecuteNonQuery() > 0;
            }
        }

        private void ChangeTypeValue(ITransaction transaction, SqlCommand command)
        {
            if (transaction is TransactionTarja)
            {
                var tarja = transaction as TransactionTarja;
                command.Parameters.Add("@Description", SqlDbType.VarChar).Value = DBNull.Value;
                command.Parameters.Add("@Number", SqlDbType.VarChar).Value = tarja.Number;
                command.Parameters.Add("@Type", SqlDbType.VarChar).Value = "Tarja";

            }
            else if (transaction is TransactionChip)
            {
                var chip = transaction as TransactionChip;
                command.Parameters.Add("@Description", SqlDbType.VarChar).Value = chip.Description;
                command.Parameters.Add("@Number", SqlDbType.VarChar).Value = DBNull.Value;
                command.Parameters.Add("@Type", SqlDbType.VarChar).Value = "Chip";
            }
        }


        public ITransaction Find(int id)
        {
            using (SqlCommand command = _connect.CreateCommand())
            {
                if (_connect.State == ConnectionState.Closed) _connect.Open();

                command.CommandText = " SELECT  Id, Value, Description, Number, Type FROM Trans ";
                command.CommandText += " WHERE Id = @Id ";
                command.Parameters.Add("@Id", SqlDbType.Decimal).Value = id;

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows && reader.Read())
                    {
                        if (reader.GetString(4) == "Chip")
                        {
                            TransactionChip chip = new TransactionChip();
                            chip.Id = reader.GetInt32(0);
                            chip.Value = reader.GetDecimal(1);
                            chip.Description = reader.GetString(2);
                            return chip;
                        }
                        else if (reader.GetString(4) == "Tarja")
                        {
                            TransactionTarja tarja = new TransactionTarja();
                            tarja.Id = reader.GetInt32(0);
                            tarja.Value = reader.GetDecimal(1);
                            tarja.Number = reader.GetString(3);
                            return tarja;
                        }
                    }
                    reader.Close();
                }
            }
            return default(ITransaction);
        }
    }
}
