using System;

namespace ProtoStar.Core.IoC
{
    public interface IContainer<in T>:IContainer
    {
        TAbstract Resolve<TAbstract>() 
            where TAbstract : T;
    }

}