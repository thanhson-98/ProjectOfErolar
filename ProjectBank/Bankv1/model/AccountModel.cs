using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Bankv1.utility;
using Bankv1.model;
using Bankv1.error;
using Transaction = Bankv1.entity.Transaction;
using Bankv1.entity;


namespace Bankv1.model
{
    public class AccountModel
    {
        public Boolean Save(Account account)
        {
            Dbconnection.Instance().OpenConnection();
            var salt = Hash.RandomString(7); // sinh ra chuỗi muối random
            account._salt = salt; // Đưa muối vào thuộc tính của account để lưu vào database 
            account._password = Hash.GenerateSaltedSHA1(account._password, account._salt); // Mã hỏa pass của người dùng kèm theo muối, set thuộc tính pass mới
            var queryString = "insert into `AccountInformation` (`_username`, `_password`, `_accountNumber`, `_identityCard`, `_fullName`, `_email`, `_phone`, `_balance`, `_salt`, `_status`)" +
             " values(@_username, @_password, @_accountNumber, @_identityCard, @_fullName, @_email, @_phone, @_balance, @_salt, @_status)";
            var cmd = new MySqlCommand(queryString, Dbconnection.Instance().Connection);
            cmd.Parameters.AddWithValue("@_username", account._username);
            cmd.Parameters.AddWithValue("@_password", account._password);
            cmd.Parameters.AddWithValue("@_accountNumber", account._accountNumber);
            cmd.Parameters.AddWithValue("@_identityCard", account._identityCard);
            cmd.Parameters.AddWithValue("@_fullName", account._fullName);
            cmd.Parameters.AddWithValue("@_username", account._email);
            cmd.Parameters.AddWithValue("@_password", account._phone);
            cmd.Parameters.AddWithValue("@_identityCard", account._balance);
            cmd.Parameters.AddWithValue("@_identityCard", account._salt);
            cmd.Parameters.AddWithValue("@_identityCard", account._status);
            var result = cmd.ExecuteNonQuery();
            Dbconnection.Instance().CloseConnection();
            return result == 1;
        }

        public bool UpdateBalance(Account account, Transaction TransactionType)
        {
            Dbconnection.Instance().OpenConnection(); // Đảm bảo kết nối đến DB thành công.
            var Transaction = Dbconnection.Instance().Connection.BeginTransaction(); // Khởi tạo Transaction.

            try
            {
                // lấy thông tin số dư mới nhất của tài khoản.
                var queryBalance = "select _balance from `AccountInformation` where _username = @_username and _status = @_status";
                MySqlCommand queryBalanceCommand = new MySqlCommand(queryBalance, Dbconnection.Instance().Connection);
                queryBalanceCommand.Parameters.AddWithValue("@_username", account._username);
                queryBalanceCommand.Parameters.AddWithValue("@_status", account._status);
                var balanceReader = queryBalanceCommand.ExecuteReader();
                // Không tìm thấy tài khoản tương ứng, thu ra lỗi.
                if (!balanceReader.Read())
                {
                    // không tồn tại bản ghi tương ứng lập tức rollback transaction, và trả về false.
                    //Hàm dừng ở đây
                    throw new SpingTransactionException("Invalid username");
                }

                // đảm bảo có bản ghi
                var currentBalance = balanceReader.GetDecimal("_balance");
                balanceReader.Close();
                // kiểm tra transaction, chỉ chấp nhận deposit và withdraw.
                if(TransactionType.deposit){

                }

            }
            catch (SpingTransactionException e)
            {

                Transaction.Rollback();
                return false;
            }
        }
    }
}