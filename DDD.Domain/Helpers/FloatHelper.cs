using System;

namespace DDD.Domain.Helpers
{
    public static class FloatHelper
    {
        /// <summary>
        /// 小数点以下を指定桁数で四捨五入します
        /// </summary>
        /// <param name="value"></param>
        /// <param name="decimalPoint"></param>
        /// <returns></returns>
        public static string RoundString(this float value, int decimalPoint)
        {
            var temp = Convert.ToSingle(Math.Round(value, decimalPoint));
            return temp.ToString("F" + decimalPoint);
        }
    }
}
