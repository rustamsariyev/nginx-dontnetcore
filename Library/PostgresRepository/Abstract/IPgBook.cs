using Library.Models.Inputs;
using Library.Models.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.PostgresRepository.Abstract
{
    public interface IPgBook : IGenericPgRepository<IBook>
    {
    }
}
