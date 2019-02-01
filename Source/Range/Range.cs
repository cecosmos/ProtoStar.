// Copyright © 2018 ceCosmos, Brazil. All rights reserved.
// Project: ProtoStar
// Author: Johni Michels

namespace ProtoStar.Core
{
    public struct Range<T> : IRange<T>
    {
        #region Public Properties

        public T Maximum { get; set; }

        public T Minimum { get; set; }

        #endregion Public Properties
    }
}