// Copyright © 2018 ceCosmos, Brazil. All rights reserved.
// Project: ProtoStar
// Author: Johni Michels

namespace ProtoStar.Core
{
    public interface ISerializer<in TIn,out TOut>
    {
        TOut Serialize(TIn @in);
    }

    
}
