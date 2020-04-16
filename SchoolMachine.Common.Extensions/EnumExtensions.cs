using System;

namespace SchoolMachine.Common.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum element)
        {
            return Enum.GetName(element.GetType(), element);
        }
    }
}
