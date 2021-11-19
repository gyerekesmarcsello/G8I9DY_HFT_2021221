using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G8I9DY_HFT_2021221.Logic
{
    public interface ILogic<T> where T: class
    {
        T GetOne(int id);
        IEnumerable<T> GetAll();

    }
}
