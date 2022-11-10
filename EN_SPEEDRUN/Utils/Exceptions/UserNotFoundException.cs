using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN_SPEEDRUN.Utils.Exceptions;
public class UserNotFoundException : Exception {

    public string SearchCriterion { get; private set; }

    public UserNotFoundException(string message, string searchCriterion, Exception? cause = null) 
        : base(message, cause) {
        this.SearchCriterion = searchCriterion;
    }
}
