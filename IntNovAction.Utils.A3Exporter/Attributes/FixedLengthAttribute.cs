using IntNovAction.Utils.A3Exporter.A3Models;
using IntNovAction.Utils.A3Exporter.DataFormatters;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntNovAction.Utils.A3Exporter.Attributes
{
    /// <summary>
    /// Mediante este atributo indicamos cómo se formatea el campo en texto:
    /// - Index: posición dentro de la línea
    /// - Length: tamaño total que ha de ocupar
    /// - PaddingType: rellenar hasta length por la izquierda o por la derecha
    /// - PaddingChar: carater de relleno
    /// - FormatType: si el campo no se formatea de manera general (decimales y enum)
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    internal class FixedLengthAttribute : Attribute
    {
        internal int Index { get; set; }

        internal int Length { get; set; }

        internal PaddingType PaddingType { get; set; }

        internal char PaddingChar { get; set; }

        internal FormatType FormatType { get; set; }

        internal FixedLengthAttribute(int index, int length) : this (index, length, PaddingType.Right)
        {
        }

        internal FixedLengthAttribute(int index, int length, FormatType formatType) : this(index, length, PaddingType.Right, ' ', formatType)
        {
        }


        internal FixedLengthAttribute(int index, int length, PaddingType paddingType) : this(index, length, paddingType, ' ')
        {
        }

        internal FixedLengthAttribute(int index, int length, PaddingType paddingType, char paddingChar) : this (index, length, paddingType, paddingChar, FormatType.General)
        {
        }

        internal FixedLengthAttribute(int index, int length, PaddingType paddingType, char paddingChar, FormatType formatType)
        {
            this.Index = index;
            this.Length = length;
            this.PaddingType = paddingType;
            this.PaddingChar = paddingChar;
            this.FormatType = formatType;
        }


    }
    
}
