using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRepository;
using KusPh.Data.Models;

namespace KusPh.Data.Repositories
{
    public class KusRepository : RepositoryBase<Kus>
    {
        protected override DbContext GetContext()
        {
            return new KusPhContext();
        }
    }
}
