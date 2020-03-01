using BoardGameMeet.Helpers;
using System;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace BoardGameMeet.Network.Helpers
{
    public static class UrlHelpers
    {
        private static string GetPropertyName(PropertyInfo propertyInfo)
        {
            var attribute = Attribute.GetCustomAttributes(propertyInfo).First(x => x is RequestPropertyAttribute);
            var requestPropertyAttribute = attribute as RequestPropertyAttribute;

            return requestPropertyAttribute?.PropertyName ?? propertyInfo.Name;
        }

        public static string ToQueryString(this object request, string separator = ",")
        {
            if (request == null)
                throw new ArgumentNullException("request");

            var attribute = Attribute.GetCustomAttribute(request.GetType(), typeof(RequestObjectAttribute));

            // Get all properties on the object
            var properties = request.GetType().GetProperties()
                    .Where(x => x.CanRead)
                    .Where(x => x.GetValue(request, null) != null)
                    .ToDictionary(x => attribute is null ? x.Name : GetPropertyName(x), x => x.GetValue(request, null));

            // Get names for all IEnumerable properties (excl. string)
            var propertyNames = properties
                .Where(x => !(x.Value is string) && x.Value is IEnumerable)
                .Select(x => x.Key)
                .ToList();

            // Concat all IEnumerable properties into a comma separated string
            foreach (var key in propertyNames)
            {
                var valueType = properties[key].GetType();
                var valueElemType = valueType.IsGenericType
                                        ? valueType.GetGenericArguments()[0]
                                        : valueType.GetElementType();
                if (valueElemType.IsPrimitive || valueElemType == typeof(string))
                {
                    var enumerable = properties[key] as IEnumerable;
                    properties[key] = string.Join(separator, enumerable.Cast<object>());
                }
            }

            // Concat all key/value pairs into a string separated by ampersand
            return string.Join("&", properties
                .Select(x => string.Concat(
                    Uri.EscapeDataString(x.Key), "=",
                    Uri.EscapeDataString(x.Value is bool ? x.Value.ToString().ToLower() : x.Value.ToString()))));
        }
    }
}
