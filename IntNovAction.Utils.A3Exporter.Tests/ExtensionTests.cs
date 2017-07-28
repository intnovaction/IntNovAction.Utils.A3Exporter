using FluentAssertions;
using IntNovAction.Utils.A3Exporter.DataFormatters;
using IntNovAction.Utils.A3Exporter.Helpers;
using IntNovAction.Utils.A3Exporter.Models;
using System;
using Xunit;

namespace IntNovAction.Utils.A3Exporter.Tests
{
    public class ExtensionTests
    {
        [Fact]
        public void CheckExtension_DateTime_ToA3String()
        {
            var date = new DateTime(2009, 4, 26);
            var expectedResult = "20090426";

            var strDate = new A3DateTimeDataFormatter().Formatter(date);
            strDate.Should().BeEquivalentTo(expectedResult);
            
        }

        [Fact]
        public void CheckExtension_PositiveAmount_ToA3String()
        {
            decimal amount = 12500.5M;
            var expectedResult = "+0000012500.50";

            var strAmount = new A3DecimalDataFormatter().Formatter(amount);
            strAmount.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void CheckExtension_NegativeAmoun_ToA3String()
        {
            decimal amount = -12500.5M;
            var expectedResult = "-0000012500.50";

            var strAmount = new A3DecimalDataFormatter().Formatter(amount);
            strAmount.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void CheckExtension_PositiveAmount_NoDecimal_ToA3String()
        {
            decimal amount = -12500;
            var expectedResult = "-0000012500.00";

            var strAmount = new A3DecimalDataFormatter().Formatter(amount);
            strAmount.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void CheckExtension_Bool_TrueValue_ToA3String()
        {
            bool boolValue = true;
            var expectedResult = "S";

            var strBool = new A3BoolDataFormatter().Formatter(boolValue);
            strBool.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void CheckExtension_Bool_FalseValue_ToA3String()
        {
            bool boolValue = false;
            var expectedResult = "N";

            var strBool = new A3BoolDataFormatter().Formatter(boolValue);
            strBool.Should().BeEquivalentTo(expectedResult);
        }
    }
}
