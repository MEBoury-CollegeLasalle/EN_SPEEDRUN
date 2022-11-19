using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Utils.Exceptions;
public class InvalidValueException : Exception {

    public string? FailedCondition { get; private set; }

    public InvalidValueException(string message, string? failedCondition = null, Exception? cause = null) : base(message, cause) {
        this.FailedCondition = failedCondition;
    }
}
