using System;
using System.Collections.Generic;
using wooliesx.model.models;
using System.Threading.Tasks;

namespace wooliesx.service.services
{
    /// <summary>
    /// Exercise 1 interface
    /// </summary>
    public interface IExercise3Service
    {

        Task<decimal> TrolleyTotal(Request postRequest);
    }
}