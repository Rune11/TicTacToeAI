using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameModel;

namespace AI.Tree
{
    class Node
    {
        Field _field;
        List<Node> children;
        public Node(Field field)
        {
            _field = field;
        }

        public void AddChild(Field field)
        {
            children.Add(new Node(field));
        }

        public List<Node> GetChildren()
        {
            return children;
        }

        public bool IsEmpty()
        {
            return children.Count == 0;
        }
    }
}
