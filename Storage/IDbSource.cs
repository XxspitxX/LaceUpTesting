using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaceUpTesting.Storage 
{ 
    public interface IDbSource
    {
        Task Init();
    }
}
