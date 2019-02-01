using System;

namespace ProtoStar.Core.IoC
{
    public interface IContainer<in T>:IContainer
    {
        void Register<TAbstract>(Func<TAbstract> concreteObject)
            where TAbstract : T;

        TAbstract Resolve<TAbstract>() 
            where TAbstract : T;
    }

}