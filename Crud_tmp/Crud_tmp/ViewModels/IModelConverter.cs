using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crud_tmp.ViewModels
{
    interface IModelConverter<T,M>
    {
        M ConvertTo(T model);

        T ConvertFrom(M model);
    }
}
