using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorTreeLib
{
    public class Tick<T>
    {
        public BehaviorTree<T> m_Tree;
        public T m_Target;
        public Blackboard m_BlackBoard;
        public List<BevBaseNode<T>> m_NodeList;
        public Tick()
        {
            _initialize();

        }
        private void _initialize()
        {
            m_Tree = null;
            m_Target = default(T);
            m_BlackBoard = null;
            m_NodeList = new List<BevBaseNode<T>>();
        }
        public void EnterNode(BevBaseNode<T> node)
        {
            this.m_NodeList.Add(node);
        }
    }
}
