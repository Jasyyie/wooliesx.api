using System;
using System.Collections.Generic;
using wooliesx.model.models;
using System.Threading.Tasks;

namespace wooliesx.service.services
{
    public interface IExercise2Service
    {

        Task<List<Product>> SortProducts(string sortOptions);
    }
}