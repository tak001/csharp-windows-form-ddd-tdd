using DDD.WinForm.Common;

namespace DDD.Domain.ValueObjects
{
    public sealed class Temperature : ValueObject<Temperature>
    {
        public const string UnitName = "℃";
        public const int DecimalPoint = 2;

        public Temperature(float value)
        {
            Value = value;
        }

        public float Value { get; }
        public string DisplayValue
        {
            get
            {
                return CommonFunc.RoundString(Value, DecimalPoint);
            }
        }

        public string DisplayValueWithUnit
        {
            get
            {
                return CommonFunc.RoundString(Value, DecimalPoint) + UnitName;
            }
        }

        public string DisplayValueWithUnitSpace
        {
            get
            {
                return CommonFunc.RoundString(Value, DecimalPoint) + " " + UnitName;
            }
        }

        protected override bool EqualsCore(Temperature other)
        {
            return Value == other.Value;
        }
    }
}
