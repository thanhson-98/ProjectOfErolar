// using System.Collections;
// using System.Collections.Generic;
// using System.Transactions;
// using MySql.Data.MySqlClient;
// using Transactions = Bankv1.entity.Transaction;

// namespace Bankv1.model
// {
//     public class TransactionModel
//     {
//         public List<Transaction> getTransactionByAccountNumber(string accountNumber)
//         {
//             Dbconnection.Instance().OpenConnection();
//             var listTransaction = new List<Transaction>();
//             var sqlQuery = "select * from `History` where receiverAccount = @accountNumber or sendAccount =@accountNumber";
//             var cmd = new MySqlCommand(sqlQuery,Dbconnection.Instance().Connection);
            
//         return listTransaction;
//         }
//     }
// }