using System.Collections.Generic;
using TheGameOfLife.Models.Abstract;
using TheGameOfLife.Models.Interfaces;

namespace TheGameOfLife.BL.Services
{
    public class GenerationService : IGenerationService
    {
        public IList<Cell> CreateNextGeneration(IList<Cell> generation)
        {
            var result = new List<Cell>();
            foreach (var cell in generation)
            {
                var cellNeighborhoodsCoordinates = cell.Neighborhoods;
                
            }
        }
    }
}