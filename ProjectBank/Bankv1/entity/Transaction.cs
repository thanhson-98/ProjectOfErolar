using System;

namespace Bankv1.entity
{
    public class Transaction
    {
        public enum ActiveStatus
        {
            PROCESSING = 1, // Đang Thực Hiện
            DONE = 2,       // Xong
            REJECT = 0,     // Từ chối
            DELETED = -1    // Xóa
        }

        public enum TransactionType
        {
            DEPOSIT = 1,  // Gửi tiền
            WITHDRAW = 2, // Rút tiền
            TRANSFER = 3  // Chuyển khoản
        }

        public string _id {get;set;}
        public TransactionType _type {get;set;}
        public string _amount {get;set;} // Số tiền.
        public string _content {get;set;} // Nội dung.
        public string _senderAccountNumber {get;set;} // Số tài khoản người gửi
        public string _receiverAccountNumber {get;set;} //Số tài khoản người nhận
        public ActiveStatus _status {get;set;}

        public Transaction(){

        }

        public Transaction(string _id,TransactionType _type,string _amount,string _content, string _senderAccountNumber, string _receiverAccountNumber, ActiveStatus _status){

        }

    }
}