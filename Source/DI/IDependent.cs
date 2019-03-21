using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoStar.Core
{
    public interface IDependent<T>
    {
        T Dependency { get; set; }
    }
}
