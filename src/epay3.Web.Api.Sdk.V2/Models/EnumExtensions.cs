using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace epay3.Web.Api.Sdk.V2.Models
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            try
            {
                if (enumValue == null)
                {
                    return string.Empty;
                }

                return enumValue.GetType()
                .GetMember(enumValue.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .GetName();
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}