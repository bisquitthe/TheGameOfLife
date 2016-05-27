using System.ComponentModel;

namespace TheGameOfLife
{
    public class Cell : INotifyPropertyChanged
    {
        public Cell(bool defaultState, int row, int column)
        {
            State = defaultState;
            Row = row;
            Column = column;
        }

        public bool State
        {
            get { return _state; }
            set
            {
                _state = value;
                OnPropertyChanged("State");
            }
        }

        public int Row { get;private set; }
        public int Column { get; private set; }

        private bool _state;

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged !=null)
                PropertyChanged(this,new PropertyChangedEventArgs(propertyName));
        }
        public bool ToBeOrNotToBe(Cell[] neighbors)
        {
            int livingCount = 0;
            for (int i = 0; i < neighbors.Length; i++)
            {
                if (neighbors[i].State == true)
                    livingCount++;
            }

            if (State == false)
            {
                if (livingCount == 3)
                {
                    State = true;
                    return true;
                }
            }
            else if (State == true)
            {
                if (livingCount < 2 || livingCount > 3)
                {
                    State = false;
                    return true;
                }
            }
            return false;
        }

        public Cell GetClone()
        {
            return new Cell(State, Row, Column);
        }
    }
}