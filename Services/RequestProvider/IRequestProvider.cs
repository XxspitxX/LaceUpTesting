using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaceUpTesting.Services.RequestProvider
{
    public interface IRequestProvider
    {
        Task<TResult?> GetAsync<TResult>(string uri);

        Task<TResult?> PostAsync<TResult>(string uri, TResult data);


    }
}
