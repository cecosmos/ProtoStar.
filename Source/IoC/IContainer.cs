// Copyright © 2018 ceCosmos, Brazil. All rights reserved.
// Project: ProtoStar
// Author: Johni Michels

using System;

namespace ProtoStar.Core.IoC
{
    public interface IContainer
    {
        void Register(Type abstractType, Func<object> concreteType);
        object Resolve(Type abstractType);
    }
}
