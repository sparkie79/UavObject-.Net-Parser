using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UavObjectParser
{
    public enum UPDATEMODE
    {
        UPDATEMODE_NEVER = 0,
        UPDATEMODE_MANUAL = 1,
        UPDATEMODE_ONCHANGE = 2,
        UPDATEMODE_PERIODIC = 3,
	    UPDATEMODE_THROTTLED = 4
    }
}
