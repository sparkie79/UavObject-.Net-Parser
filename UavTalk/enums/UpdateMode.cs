using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UavTalk.enums
{
    public enum UpdateMode
    {
        UPDATEMODE_NEVER = 0,
        UPDATEMODE_MANUAL = 1,
        UPDATEMODE_ONCHANGE = 2,
        UPDATEMODE_PERIODIC = 3,
	    UPDATEMODE_THROTTLED = 4
    }
}
