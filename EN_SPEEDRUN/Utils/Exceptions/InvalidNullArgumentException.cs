using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Utils.Exceptions;
internal class InvalidNullArgumentException : Exception {

    public string ParamName { get; private set; }
    public string FunctionName { get; private set; }

    public InvalidNullArgumentException(
        string message, 
        string paramName, 
        string functionName, 
        Exception? cause = null) : base($"Invalid null argument value for parameter {paramName} of function {functionName}: {message}", cause) {

        this.ParamName = paramName;
        this.FunctionName = functionName;
    }
}
