using System;

namespace Bankv1.error
{
    public class SpingTransactionException : Exception
    {
        public SpingTransactionException(string message) : base(message){
            
        }
    }
}