using System;
namespace BILLSToPAY.Domain.Shared.Models
{
    public class EnumModel<T> where T : struct
    {
        public EnumModel(T value, string text)
        {
            Value = value;
            Text = text;
        }

        public T Value { get; set; }
        public string Text { get; set; }
    }
}
