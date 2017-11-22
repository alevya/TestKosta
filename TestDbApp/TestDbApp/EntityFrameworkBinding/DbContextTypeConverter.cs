using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;

namespace TestDbApp.EntityFrameworkBinding
{
    internal class DbContextTypeConverter : ReferenceConverter
    {
        public DbContextTypeConverter(Type type) : base(type)
        {

        }

        #region Overrides

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            var values = new List<Type> {null};
            values.AddRange(GetDbContextTypes(context));

            return new StandardValuesCollection(values);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var s = value as string;
            if (s == null) return base.ConvertFrom(context, culture, value);
            var values = GetDbContextTypes(context);
            return values.FirstOrDefault(t => t.ToString() == s);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is Type)
            {
                return value.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        private static IEnumerable<Type> GetDbContextTypes(ITypeDescriptorContext context)
        {
            var values = new List<Type>();
            var tds = context.GetService(typeof(ITypeDiscoveryService)) as ITypeDiscoveryService;
            if (tds == null) return values;

            foreach (Type t in tds.GetTypes(typeof(System.Data.Entity.DbContext), true))
            {
                if (t.IsPublic && t.IsVisible && !t.IsAbstract && t != typeof(System.Data.Entity.DbContext))
                {
                    values.Add(t);
                }
            }
            return values;
        }
        #endregion
    }
}
