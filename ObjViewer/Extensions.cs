using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UavTalk;

namespace ObjViewer
{
    public static class Extensions
    {
        public static UavTalk.UAVObjectField getField(this UavTalk.UAVObject obj, string fieldname)
        {
            var field = obj.GetType().GetFields().Where(j => j.FieldType.BaseType == typeof(UAVObjectField) && j.Name == fieldname);
            return (UAVObjectField)field;
        }
    }
}
