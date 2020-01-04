//-----------------------------------------------------------------------
// <copyright file="Alphabet.cs" company="My Company">
//    Created by yurik_322 on 19/11/13.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Def
{
    /// <summary>
    /// dictionary class
    /// </summary>
    class Alphabet
    {
        /// <summary>
        /// constant for dimension:
        /// </summary>
        static public int n = 6;
        
        /// <summary>
        ///  use their matrix for encryption, which is provided for the use of a two-dimensional array:
        /// </summary>
        static public char[,] alf =
        {
             { 'у', 'ч', 'в', 'г', 'д', 'е' },
             { 'є', 'ж', 'з', 'и', 'і', 'ї' },
             { 'й', 'к', 'л', 'м', 'н', 'о' },
             { 'п', 'р', 'с', 'т', 'а', 'ф' },
             { 'х', 'ц', 'б', 'ш', 'щ', 'ю' },
             { 'я', 'ь', 'q', 'w', 'e', 'i' }
        };
    }
}
