using Library.Core.ControllerHelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.PostgresRepository.Abstract
{
    public interface IGenericPgRepository<InputClass> where InputClass:class                                                    
    {
        ItemResult Get(int id);
        ItemResult GetAll();
        ItemResult Add(InputClass newItem);
        ItemResult Edit(InputClass editedItem);
        ItemResult Delete(int id);
    }
}
