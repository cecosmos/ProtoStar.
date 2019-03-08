// Copyright © 2018 ceCosmos, Brazil. All rights reserved.
// Project: ProtoStar
// Author: Johni Michels

using System.Collections.Generic;

namespace ProtoStar.Core
{
    public enum RelativePositionType
    {
        Above = 1,
        Inside = 0,
        Bellow = -1
    }

    public static class RangeExtensions
    {
        #region Public Methods

        public static bool IsAbove<T>(this IRange<T> range, T value, IComparer<T> comparer)=>
            comparer.Compare(range.Maximum, value) < 0;

        public static bool IsAbove<T>(this IRange<T> range, T value)=>
            range.IsAbove(value, Comparer<T>.Default);

        public static bool IsBellow<T>(this IRange<T> range, T value, IComparer<T> comparer)=>
            comparer.Compare(value, range.Minimum) < 0;

        public static bool IsBellow<T>(this IRange<T> range, T value)=>
            range.IsBellow(value, Comparer<T>.Default);
        

        public static bool IsInside<T>(this IRange<T> range, T value, IComparer<T> comparer)=>
            !(range.IsAbove(value, comparer) || range.IsBellow(value, comparer));

        public static bool IsInside<T>(this IRange<T> range, T value)=>
            range.IsInside(value, Comparer<T>.Default);
    
        public static RelativePositionType RelativePosition<T>(this IRange<T> range, T value, IComparer<T> comparer)
        {
            if (range.IsBellow(value, comparer)) { return RelativePositionType.Bellow; }
            if (range.IsAbove(value, comparer)) { return RelativePositionType.Above; }
            return RelativePositionType.Inside;
        }

        public static RelativePositionType RelativePosition<T>(this IRange<T> range, T value)=>
            range.RelativePosition(value, Comparer<T>.Default);
        

        #endregion Public Methods
    }
}