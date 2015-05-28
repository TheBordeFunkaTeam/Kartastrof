﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kartastrof.Classes
{
    /// <summary>
    /// An extension class for the between operation
    /// name pattern IsBetweenXX where X = I -> Inclusive, X = E -> Exclusive
    /// </summary>
    public static class BetweenExtensions
    {

        /// <summary>
        /// Between check <![CDATA[min <= value <= max]]> 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">the value to check</param>
        /// <param name="min">Inclusive minimum border</param>
        /// <param name="max">Inclusive maximum border</param>
        /// <returns>return true if the value is between the min and max else false</returns>
        public static bool IsBetweenII<T>(this T value, T min, T max) where T : IComparable
        {
            return (min.CompareTo(value) <= 0) && (value.CompareTo(max) <= 0);
        }

        /// <summary>
        /// Between check <![CDATA[min <= value <= max]]>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">the value to check</param>
        /// <param name="min">Exclusive minimum border</param>
        /// <param name="max">Inclusive maximum border</param>
        /// <returns>return true if the value is between the min and max else false</returns>
        public static bool IsBetweenEI<T>(this T value, T min, T max) where T : IComparable
        {
            return (min.CompareTo(value) < 0) && (value.CompareTo(max) <= 0);
        }

        /// <summary>
        /// between check <![CDATA[min <= value <= max]]>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">the value to check</param>
        /// <param name="min">Inclusive minimum border</param>
        /// <param name="max">Exclusive maximum border</param>
        /// <returns>return true if the value is between the min and max else false</returns>
        public static bool IsBetweenIE<T>(this T value, T min, T max) where T : IComparable
        {
            return (min.CompareTo(value) <= 0) && (value.CompareTo(max) < 0);
        }

        /// <summary>
        /// between check <![CDATA[min <= value <= max]]>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">the value to check</param>
        /// <param name="min">Exclusive minimum border</param>
        /// <param name="max">Exclusive maximum border</param>
        /// <returns>return true if the value is between the min and max else false</returns>

        public static bool IsBetweenEE<T>(this T value, T min, T max) where T : IComparable
        {
            return (min.CompareTo(value) < 0) && (value.CompareTo(max) < 0);
        }
    }
}