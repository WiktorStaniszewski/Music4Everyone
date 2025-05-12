using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Exceptions;

public class CardNumberInvalidException : Exception
{
    public CardNumberInvalidException() : base("invalid card number") { }
    public CardNumberInvalidException(string message) : base(message) { }
    public CardNumberInvalidException(string message, Exception innerException) : base(message, innerException) { }

    static void ThrowCustomException()
    {
        throw new CardNumberInvalidException();
    }
}
