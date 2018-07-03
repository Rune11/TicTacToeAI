using System;
using System.Collections.Generic;

namespace GameModel
{
    public class Field
    {
        List<List<int>> _field;
        int _size;
        bool _player;

        int winner;

        #region Constructor
        /// <summary>
        /// Constructor for the playfield.
        /// </summary>
        /// <param name="size">Size of the field</param>
        public Field(int size)
        {
            _size = size;
            _player = true;
            winner = 0;
            _field = new List<List<int>>();
            for (int i = 0; i < _size; i++)
            {
                var list = new List<int>();
                for (int j = 0; j < _size; j++)
                {
                    list.Add(0);
                }
                _field.Add(list);
            }
        }

        public Field(Field field)
        {
            _size = field.Size;
            _player = field.Player;
            winner = field.GetWinner();

            _field = new List<List<int>>();
            for (int i = 0; i < _size; i++)
            {
                var list = new List<int>();
                for (int j = 0; j < _size; j++)
                {
                    list.Add(field.GetValue(i,j));
                }
                _field.Add(list);
            }
        }
        #endregion

        #region Getters
        /// <summary>
        /// Gets the value of the [x,y] position in the playfield.
        /// </summary>
        /// <param name="x">x coord</param>
        /// <param name="y">x coord</param>
        /// <returns>0 if the position is blank, 1 if X, 2 if O</returns>
        public int GetValue(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < _size && y < _size)
                return _field[x][y];
            throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// Getter for the size attribue of the Field.
        /// </summary>
        public int Size { get { return _size; } set { _size = value; } }

        /// <summary>
        /// Getter for the active player. True is player1, False is player2.
        /// </summary>
        public bool Player { get { return _player; } }

        public int GetWinner() { return winner; }

        #endregion

        #region Public functions
        /// <summary>
        /// Expands the playing field (eg. 3x3 -> 5x5).
        /// </summary>
        /// 
        public void Expand()
        {
            var newSize = _size + 2;
            var newField = new List<List<int>>();
            

            for (int i = 0; i < newSize; i++)
            {
                var list = new List<int>();
                for (int j = 0; j < newSize; j++)
                {
                    if (i == 0 || i == newSize - 1 || j == 0 || j == newSize - 1)
                    {
                        list.Add(0);
                    }
                    else
                    {
                        list.Add(_field[i-1][j-1]);
                    }
                }
                newField.Add(list);
            }

            _size = newSize;
            _field = newField;
        }

        /// <summary>
        /// Active player makes a step, in the [x,y] position.
        /// </summary>
        /// <param name="x">X coord</param>
        /// <param name="y">Y coord</param>
        public void Step(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < _size && y < _size)
            {
                if (_field[x][y] == 0)
                {
                    if (_player)
                    {
                        _field[x][y] = 1;
                    }
                    else
                    {
                        _field[x][y] = 2;
                    }
                    if (CheckWinCondition(x, y))
                    {
                        GameEnded();
                        return;
                    }
                    _player = !_player;
                }
                else
                {
                    throw new ArgumentException();
                }

            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
                
            
        }
        #endregion

        #region Private functions

        /// <summary>
        /// Cheks if the active player have won the game with the latest step.
        /// </summary>
        /// <param name="x">X coord</param>
        /// <param name="y">Y coord</param>
        /// <returns>True if won, false otherwise</returns>
        private bool CheckWinCondition(int x, int y)
        {
            bool row = CountConsecutive(x, y, 1, 0);
            bool column = CountConsecutive(x, y, 0, 1);
            bool diag1 = CountConsecutive(x, y, 1, 1);
            bool diag2 = CountConsecutive(x, y, 1, -1);
            return row || column || diag1 || diag2;
        }

        /// <summary>
        /// Counts consecutive cells of active player, starting from the [x,y] postition, followig the [v,w] vector.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns>Returns true if the count is >= 5, false otherwise.</returns>
        private bool CountConsecutive(int x, int y, int v, int w)
        {
            int num = 1; // number of consecutive matching cells
            int a = x + v;
            int b = y + w;
            int p; // active player's number
            if (_player)
            {
                p = 1;
            }
            else
            {
                p = 2;
            }
            while (a >= 0 && a < _size && b >= 0 && b < _size && _field[a][b] == p)
            {
                num++;
                a += v;
                b += w;
            }
            if (num >= 5)
            {
                return true;
            }
            a = x - v;
            b = y - w;
            while (a >= 0 && a < _size && b >= 0 && b < _size && _field[a][b] == p)
            {
                num++;
                a -= v;
                b -= w;
            }
            if (num >= 5)
            {
                return true;
            }
            return false;
        }

        private void GameEnded()
        {
            if (_player)
            {
                winner = 1;
            }
            else
            {
                winner = 2;
            }
        }
        #endregion
    }
}
