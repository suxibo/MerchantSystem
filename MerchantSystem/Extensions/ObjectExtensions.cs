using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MerchantSystem
{
    public static class ObjectExtensions
    {
        public static TResult Map<TResult>(this Object source, TResult target = default) where TResult : new()
        {
            if (source == null)
            {
                return default;
            }

            var sourceType = source.GetType();

            var targetProperties = typeof(TResult).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.SetProperty);

            if (targetProperties != null && targetProperties.Length > 0)
            {
                foreach (var targetProperty in targetProperties)
                {
                    var sourceProperty = sourceType.GetProperty(targetProperty.Name, BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty);
                    if (sourceProperty != null)
                    {
                        try
                        {
                            var value = sourceProperty.GetValue(source);
                            if (value != null)
                            {
                                targetProperty.SetValue(target, value);
                            }
                        }
                        catch { }
                    }
                }
            }

            return target;
        }

        public static TResult Map<TResult>(this Object source) where TResult : new()
        {
            return Map(source, new TResult());
        }
    }
}