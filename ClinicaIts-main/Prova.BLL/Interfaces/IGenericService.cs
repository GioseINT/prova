using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova.BLL.Interfaces
{
    public interface IGenericService<TModel, TEntity>
        where TModel : class
        where TEntity : class
    {
        IEnumerable<TModel> GetAll();
        TModel? GetById(int id);
        void Add(TModel model);
        void Update(TModel model);
        void Delete(int id);
    }
}
