using System;
using System.Collections.Generic;
using TheGameOfLife.Models.Abstract;
using TheGameOfLife.Models.Interfaces;

namespace TheGameOfLife.Models
{
    public class MooreNeighborCalculator : INeighborCalculator
    {
        public IEnumerable<Coordinates> GetNeighbors(Coordinates coordinates, int rank)
        {
            var firstCoordinates = new Coordinates(coordinates.X - rank, coordinates.Y + rank);
            var result = new List<Coordinates>
            {
                firstCoordinates
            };
            var a = 2 * rank - 1;
            for (int y = 0;y < a; y++)
            {
                for (int x = 0; x < a; x++)
                {
                    var neighborCoordinates = new Coordinates(firstCoordinates.X + x, firstCoordinates.Y+y);
                    if(neighborCoordinates.X != coordinates.X && neighborCoordinates.Y != coordinates.Y)
                        result.Add(neighborCoordinates);
                }
            }

            return result;
        }
    }
}