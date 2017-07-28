using FluentAssertions;
using IntNovAction.Utils.A3Exporter.A3Models;
using IntNovAction.Utils.A3Exporter.DataFormatters;
using System;
using Xunit;

namespace IntNovAction.Utils.A3Exporter.InternalTests
{
    public class FormattersTests
    {
        [Fact]
        public void Formatter_DateTime_ToString()
        {
            var date = new DateTime(2009, 4, 26);
            var expectedResult = "20090426";

            var strDate = new A3DateTimeDataFormatter().Formatter(date, FormatType.General);
            strDate.Should().BeEquivalentTo(expectedResult);
            
        }

        [Fact]
        public void Formatter_PositiveAmount_ToString()
        {
            decimal amount = 12500.5M;
            var expectedResult = "+0000012500.50";

            var strAmount = new A3DecimalDataFormatter().Formatter(amount, FormatType.General);
            strAmount.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Formatter_NegativeAmoun_ToString()
        {
            decimal amount = -12500.5M;
            var expectedResult = "-0000012500.50";

            var strAmount = new A3DecimalDataFormatter().Formatter(amount, FormatType.General);
            strAmount.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Formatter_PositiveAmount_NoDecimal_ToString()
        {
            decimal amount = -12500;
            var expectedResult = "-0000012500.00";

            var strAmount = new A3DecimalDataFormatter().Formatter(amount, FormatType.General);
            strAmount.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Formatter_Bool_TrueValue_ToString()
        {
            bool boolValue = true;
            var expectedResult = "S";

            var strBool = new A3BoolDataFormatter().Formatter(boolValue, FormatType.General);
            strBool.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void Formatter_Bool_FalseValue_ToString()
        {
            bool boolValue = false;
            var expectedResult = "N";

            var strBool = new A3BoolDataFormatter().Formatter(boolValue, FormatType.General);
            strBool.Should().BeEquivalentTo(expectedResult);
        }
    }
}
