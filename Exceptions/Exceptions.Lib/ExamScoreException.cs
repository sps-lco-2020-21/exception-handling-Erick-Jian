using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.Lib
{
    public class ExamScoreException : Exception
    {
        readonly int _codeNumber;

        public ExamScoreException(int codeNumber, string msg) : base(msg)   // msg must be named identically
        {
            _codeNumber = codeNumber;   
        }

        public override string Message
        {
            get
            {
                return string.Format("Code [{0}]: {1}", _codeNumber, base.Message);
            }
        }
    }
}
