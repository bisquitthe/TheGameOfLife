﻿using System.Collections.Generic;
using TheGameOfLife.Models.Abstract;
using TheGameOfLife.Models.Interfaces;

namespace TheGameOfLife.Models
{
    public class MooreNeighborCalculator : INeighborCalculator
    {
        public IEnumerable<Cell> GetCellNeighbors(Cell cell, Universe universe)
        {
            
        }
    }
}