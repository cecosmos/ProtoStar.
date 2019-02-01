// Copyright © 2018 ceCosmos, Brazil. All rights reserved.
// Project: ProtoStar
// Author: Johni Michels

namespace ProtoStar.Core
{
    public interface ISelfSerializer<TOut> : ISerializer<ISelfSerializer<TOut>, TOut>, ISerializer<TOut,ISelfSerializer<TOut>>
    {
    }

    public static class SelfSerializerExtensions
    {
        public static TOut Serialize<TOut>(this ISelfSerializer<TOut> selfSerializer) => selfSerializer.Serialize(selfSerializer);
        public static ISelfSerializer<TOut> Deserialize<TOut>(this ISelfSerializer<TOut> selfSerializer, TOut @out) => selfSerializer.Serialize(@out);
    }


}
