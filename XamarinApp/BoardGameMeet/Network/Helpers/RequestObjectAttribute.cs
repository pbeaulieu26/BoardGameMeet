using System;

namespace BoardGameMeet.Network.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = false)]
    public sealed class RequestObjectAttribute : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public sealed class RequestPropertyAttribute : Attribute
    {
        public string PropertyName { get; set; }

        public RequestPropertyAttribute()
        {
        }

        public RequestPropertyAttribute(string propertyName)
        {
            PropertyName = propertyName;
        }
    }
}
