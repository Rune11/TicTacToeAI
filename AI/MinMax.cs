using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI.Tree;
using GameModel;

namespace AI
{
    public class MinMax
    {
        Field _field;
        int _depth;
        Node tree;
        public MinMax(Field field, int depth = 3)
        {
            _field = field;
            _depth = depth;
        }

        public void Step() {

            tree = new Node(_field);

        }

        private void BuildTree()
        {
            for (int i = 0; i < _field.Size; i++)
            {
                for (int j = 0; j < _field.Size; j++)
                {
                    if (_field.GetValue(i,j) == 0)
                    {
                        Field f = new Field(_field);
                        f.Step(i, j);
                        tree.AddChild(f);
                    }
                }
            }
        }


    }
}
