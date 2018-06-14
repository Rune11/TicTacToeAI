using System;
using System.Collections.Generic;

namespace Field
{
    public class Field
    {
        List<List<int>> _field;
        int _size;
        Field(int size)
        {
            _size = size;
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
        /// 
        /// </summary>
        public void Expand()
        {
            var newSize = _size + 2;
            var newField = new List<List<int>>();
            

            for (int i = 0; i < newSize; i++)
            {
                var list = new List<int>();
                for (int j = 0; j < newSize; j++)
                {
                    if (i == 0 || i == newSize - 1)
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
    }
}
