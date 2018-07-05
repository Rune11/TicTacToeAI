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
        private Field _field;
        private List<Node> children;
        private Node _parent;
        private int _value;

        public int Value { get { return _value; } set { _value = value; } }
        public Node Parent { get { return _parent; } set { _parent = value; } }
        public Node(Field field)
        {
            _field = field;
            _value = 0;
            _parent = null;
        }

        public void AddChild(Field field, int v = 0)
        {
            Node child = new Node(field);
            child.Parent = this;
            child.Value = v;
            children.Add(child);
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
