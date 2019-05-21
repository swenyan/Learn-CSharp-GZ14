using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloGeneric
{
    public interface IGetNextElem<T>
    {
        T Next();
    }
}
