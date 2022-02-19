using DDD.WinForm.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DDDTest.Tests
{
    [TestClass]
    public class WeatherSaveViewModelTest
    {

        [TestMethod]
        public void 天気登録シナリオ()
        {
            var viewModel = new WeatherSaveViewModel();
            viewModel.SelectedAreaId.IsNull();
            viewModel.DataDateValue.Is(Convert.ToDateTime("2018/01/01 12:24:56"));
            viewModel.SelectedCondition.Is(1);
            viewModel.TemperatureText.Is("");
        }
    }
}
