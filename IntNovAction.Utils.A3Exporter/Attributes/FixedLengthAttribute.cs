using System;
using System.Collections.Generic;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FixedLengthAttribute : Attribute
    {
        public int Index { get; set; }

        public int Length { get; set; }

        public PaddingType PaddingType { get; set; }

        public char PaddingChar { get; set; }

        public FixedLengthAttribute(int index, int length) : this (index, length, PaddingType.Right)
        {
        }

        public FixedLengthAttribute(int index, int length, PaddingType paddingType) : this(index, length, paddingType, ' ')
        {
        }

        public FixedLengthAttribute(int index, int length, PaddingType paddingType, char paddingChar)
        {
            this.Index = index;
            this.Length = length;
            this.PaddingType = paddingType;
            this.PaddingChar = paddingChar;
        }
    }
    
}
