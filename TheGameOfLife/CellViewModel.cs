
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace TheGameOfLife
{
    public class CellViewModel : INotifyPropertyChanged
    {
        public static int ColumnsCount { get; private set; }
        public static int RowsCount { get; private set; }

        public ObservableCollection<Cell> Board { get; private set; }
        public int Generation
        {
            get
            {
                return _generationNum;
            }
            private set
            {
                _generationNum = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Generation"));
            }
        }

        public int Speed
        {
            get { return _speed; }
            set
            {
                _speed = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("State"));
            }
        }

        private int _speed;
        public ICommand CellClickCommand { get; private set; }
        public ICommand NextBtnClickCommand { get; private set; }
        public ICommand AnimateBtnClickCommand { get; private set; }
        public ICommand ClearBtnClickCommand { get; private set; }

        private Cell[] _lastGeneration;
        private int _generationNum;
        private volatile bool _animateRunning;
        

        public CellViewModel()
        {
            ColumnsCount = 40;
            RowsCount = 40;
            Board = new ObservableCollection<Cell>();
            InitBoard();
            CellClickCommand = new GalaSoft.MvvmLight.Command.RelayCommand<object>(CellClickMethod);
            NextBtnClickCommand = new RelayCommand(NextBtnClickMethod);
            AnimateBtnClickCommand = new RelayCommand(AnimateBtnClickMethod);
            ClearBtnClickCommand = new RelayCommand(ClearBoard);
        }

        private void CellClickMethod(object cellChild)
        {
            Cell temp;
            Border cell = cellChild as Border;
            int row = Grid.GetRow(cell);
            int column = Grid.GetColumn(cell);
            temp = Board[row*RowsCount + column];
            temp.State = !temp.State;
        }

        private void NextBtnClickMethod()
        {
            Task.Run(() => NextGeneration());
        }

        private void AnimateBtnClickMethod()
        {
            if (_animateRunning == false)
            {
                Task.Run(() => StartAnimating());
            }
            else
            {
                _animateRunning = false;
            }
        }

        private void StartAnimating()
        {
            _animateRunning = true;
            do
            {
                if (!NextGeneration())
                    _animateRunning = false;
                Thread.Sleep(100 - Speed);
            } while (_animateRunning);
        }

        private bool NextGeneration()
        {
            bool stateChanged = false;
            List<Cell> PresentGenerationClones = new List<Cell>();
            foreach (var pgc in Board)
            {
                PresentGenerationClones.Add(pgc.GetClone());
            }
            _lastGeneration = PresentGenerationClones.ToArray();
            foreach (var cell in Board)
            {
                if (cell.ToBeOrNotToBe(GetNeighbors(cell)))
                    stateChanged = true;
            }
            if (stateChanged)
            {
                Generation++;
            }
            return stateChanged;
        }

        private Cell[] GetNeighbors(Cell cell)
        {
            List<Cell> neighbors = new List<Cell>();
            int row, column;
                for (int j = cell.Row - 1; j <= cell.Row + 1; j++)
                {
                    for (int i = cell.Column - 1; i <= cell.Column + 1; i++)
                    {
                        column = i;
                        row = j;
                        Cell temp;
                        if (i < 0)
                        {
                            column = ColumnsCount + i;
                        }
                        if (j < 0)
                        {
                            row = RowsCount + j;
                        }
                        if (i > ColumnsCount - 1)
                        {
                            column = i - ColumnsCount;
                        }
                        if (j > RowsCount - 1)
                        {
                            row = j - RowsCount;
                        }
                        temp = GetLastCellByRowColumn(row, column);
                        if ((temp.Column == cell.Column) &&
                            (temp.Row == cell.Row))
                            continue;
                        neighbors.Add(temp);
                    }
                }
            return neighbors.ToArray();
        }

        private Cell GetPresentCellByRowColumn(int row, int column)
        {
            for (int i = 0;i<Board.Count;i++)
            {
                if (Board[i].Row == row && Board[i].Column == column)
                    return Board[i];
            }
            return null;
        }

        private Cell GetLastCellByRowColumn(int row, int column)
        {
            for (int i = 0; i < _lastGeneration.Length; i++)
            {
                if (_lastGeneration[i].Row == row && _lastGeneration[i].Column == column)
                    return _lastGeneration[i];
            }
            return null;
        }

        private void InitBoard()
        {
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    Board.Add(new Cell(false, i,j));
                }
            }
        }

        private void ClearBoard()
        {
            Generation = 0;
            _animateRunning = false;
            foreach (var cell in Board)
            {
                cell.State = false;
            }
            _lastGeneration = Board.ToArray();
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}