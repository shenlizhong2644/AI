using System;
using System.Collections.Generic;

namespace BehaviorTreeLib
{
    public class BehaviorTree<T>
    {
        private long m_ID;
        private static long m_MaxID = 0;
        public BevBaseNode<T> m_Root;
        private Tick<T> m_Tick;
        public long ID
        {
            get { return m_ID; }
        }

        public BehaviorTree()
        {
            _initialize();
        }
        private void _initialize()
        {
            m_ID = m_MaxID++;
            m_Root = null;
        }
        public void Tick(T target, Blackboard blackBoard)
        {
            m_Tick = new Tick<T>();
            m_Tick.m_Target = target;
            m_Tick.m_BlackBoard = blackBoard;
            m_Root.Execute(m_Tick);

        }
    }
}
