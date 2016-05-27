using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace TheGameOfLife
{
    public class Generation
    {
        public ObservableCollection<Cell> Cells { get; private set; }
        public int GenerationNumber { get; private set; }

        public Generation()
        {
            Cells = new ObservableCollection<Cell>();
        }

        public void SetFirstGeneration(IEnumerable<Cell> cells)
        {
            _lastGeneration = Cells.ToList();
            Cells = cells as ObservableCollection<Cell>;
        }

        public void CreateEmptyGeneration()
        {
            for (int i = 0; i < CellViewModel.RowsCount; i++)
            {
                for (int j = 0; j < CellViewModel.ColumnsCount; j++)
                {
                    Cells.Add(new Cell(false, i, j));
                }
            }

            _lastGeneration = Cells;
        }

        public void NextGeneration()
        {
            foreach (var cell in Cells)
            {
                cell.ToBeOrNotToBe(GetNeighbors(cell));
            }
        }

        private Cell[] GetNeighbors(Cell cell)
        {
            List<Cell> neighbors = new List<Cell>();
            int row, column;
            for (int i = cell.Column - 1; i <= cell.Column + 1; i++)
            {
                for (int j = cell.Row - 1; j <= cell.Row + 1; j++)
                {
                    column = i;
                    row = j;
                    Cell temp;
                    if (i < 0)
                    {
                        column = CellViewModel.ColumnsCount + i;
                    }
                    if (j < 0)
                    {
                        row = CellViewModel.RowsCount + j;
                    }
                    if (i > CellViewModel.ColumnsCount-1)
                    {
                        column = i - CellViewModel.ColumnsCount;
                    }
                    if (j > CellViewModel.RowsCount - 1)
                    {
                        row = j - CellViewModel.RowsCount;
                    }
                    temp = GetCellByRowColumn(row, column);
                    if(temp != cell)
                        neighbors.Add(temp);
                }
            }
            return neighbors.ToArray();
        }
      
        private Cell GetCellByRowColumn(int row, int column)
        {
            foreach (var cell in _lastGeneration)
            {
                if (cell.Row == row && cell.Column == column)
                    return cell;
            }
            return null;
        }
    }
}