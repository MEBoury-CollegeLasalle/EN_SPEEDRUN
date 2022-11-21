using EN_SPEEDRUN.DataAccess.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Utils.Exceptions;
public class InvalidStatusException : Exception {

    public InvalidStatusException(
        string message, 
        StatusDTO invalidStatus, 
        StatusDTO expectedStatus,
        Exception? cause = null)
        : base(String.Format(
            message, 
            invalidStatus.StatusCode.ToString(), 
            expectedStatus.StatusCode.ToString()
            ), cause) { 
    
    }

}
