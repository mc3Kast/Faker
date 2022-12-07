using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Intefaces
{
    public interface IFaker
    {
        T Create<T>();
        object Create(Type type);

        object GenerateViaDll(Type t);
    }
}
