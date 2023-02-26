using ConnectApi.Core.Common.Enums;

namespace ConnectApi.Core.Common.Exceptions
{
    public class BaseException : Exception
    {
        public ExceptionStatus Status { get; set; } = ExceptionStatus.none;

        public string Details { get; set; } = "None";

        public BaseException(string message) 
            : base(message)
        {

        }
    }

    public class MyException : Exception
    {
        public MyException(string message): base(message)
        {
            
        }
    }
}
