using DDD.WinForm.Common;

namespace DDD.Domain.ValueObjects
{
    public sealed class Temperature
    {
        public const string UnitName = "℃";
        public const int DecimalPoint = 2;

        public Temperature(float value)
        {
            Value = value;
        }

        public float Value { get; }
        public string DisplayValue {
            get
            {
                return CommonFunc.RoundString(Value, DecimalPoint) + UnitName;
            }
        }

        public override bool Equals(object obj)
        {
            var vo = obj as Temperature;
            if (vo == null) return false;
            return Value == vo.Value;
        }
    }
}
