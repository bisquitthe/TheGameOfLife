using System.Collections.Generic;
using TheGameOfLife.Models.Abstract;

namespace TheGameOfLife.Models.Interfaces
{
    public interface IGenerationService
    {
        IList<Cell> CreateNextGeneration(IList<Cell> generation);
    }
}