using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Pattern
{
    public interface IServiceTest : IService<test>
    {
        ICollection<test> getAllTest();
    }
}
