using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Utils.Exceptions;
public class InvalidPasswordException : Exception {

    public InvalidPasswordException(string message, Exception? cause = null) : base(message, cause) { 
    }
}
