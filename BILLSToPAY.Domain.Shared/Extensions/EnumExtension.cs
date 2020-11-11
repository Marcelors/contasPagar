using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using BILLSToPAY.Domain.Shared.Models;

namespace BILLSToPAY.Domain.Shared.Extensions
{
    public static class EnumExtension
    {
        public static IList<EnumModel<T>> EnumToModel<T, TEnum>()
           where T : struct
           where TEnum : struct
        {
            var list = new List<EnumModel<T>>();

            foreach (var valueEnum in EnumToList<T, TEnum>())
            {
                var text = ((Enum)(object)valueEnum).GetDescription();
                var value = (T)(object)valueEnum;

                var model = new EnumModel<T>(value, text);

                list.Add(model);
            }

            return list;
        }

        public static T GetValueType<T>(this Enum value)
        {
            return (T)(object)value;
        }

        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());

            DisplayAttribute[] description =
                (DisplayAttribute[])field.GetCustomAttributes(typeof(DisplayAttribute), false);

            if (description.Length > 0)
            {
                var result = description[0].GetName();
                if (result.HasValue())
                {
                    return result;
                }
            }

            return value.ToString();
        }


        public static IList<TEnum> EnumToList<T, TEnum>()
           where T : struct
           where TEnum : struct
        {
            var type = typeof(TEnum);

            if (!type.GetTypeInfo().IsEnum)
                throw new ArgumentException("T deve ser um System.Enum");

            var array = Enum.GetValues(type);
            var list = new List<TEnum>(array.Length);

            foreach (var item in array)
            {
                list.Add((TEnum)Enum.Parse(type, item.ToString()));
            }

            return list;
        }
    }
}
}
