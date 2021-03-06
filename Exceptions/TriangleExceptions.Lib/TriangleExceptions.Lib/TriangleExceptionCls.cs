using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleExceptions.Lib
{
    public class TriangleException : Exception  // inherits from Exception Class
    {
        /// Create a TriangleException class and, instead of having a IsValid property return false, 
        ///     validate the data in the constructor and the setters to forbid illegal triangles being generated.

        readonly string _errortype;
        
        // Apart from Exceptions in Exceptions, TriangleException is able to generate it's UNIQUE method
        public TriangleException(string errortype, string message): base(message)
        {                                                          // ↑ using the .Message feature in Exception (base)
            _errortype = errortype;
        }

        public override string Message  // overriding from base class ?
        {
            get {   return string.Format( $"Error Type [{_errortype}]: {base.Message}");    }
        }
    }
}
