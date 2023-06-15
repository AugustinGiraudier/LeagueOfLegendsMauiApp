using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VM.Utils
{
    public class EnumUtil<TEnum> where TEnum : struct, System.Enum
    {
        public IEnumerable<TEnum> Values => Enum.GetValues<TEnum>();
    }
}
