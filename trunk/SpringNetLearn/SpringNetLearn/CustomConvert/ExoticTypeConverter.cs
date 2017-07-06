using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetLearn.CustomConvert
{
    using System.ComponentModel;
    using System.Globalization;

    public class ExoticTypeConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context,Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context,CultureInfo culture, object value)
        {
            if (value is string)
            {
                string s = value as string;
                return new ExoticType(s);
            }
            return base.ConvertFrom(context, culture, value);
        }

    }
}
