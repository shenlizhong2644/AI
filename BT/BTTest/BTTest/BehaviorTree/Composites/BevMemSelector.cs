using System.Collections;
using System.Collections.Generic;

namespace BehaviorTreeLib
{
    class BevMemSelector<T> : BevBaseNode<T>
    {
        private List<BevBaseNode<T>> m_Childs;
        public BevMemSelector(params BevBaseNode<T>[] childs)
        {
            m_Childs = new List<BevBaseNode<T>>();
            m_Childs.AddRange(childs);
        }
        public BevMemSelector()
        {
            m_Childs = new List<BevBaseNode<T>>();
        }
        public override void Open(Tick<T> t)
        {
            t.m_BlackBoard.SetNodeMemory<int>("NextBegin", t.m_Tree.ID.ToString(), t.m_CurNode.ID.ToString(), 0);
        }
        public override void Close(Tick<T> t)
        {
            t.m_BlackBoard.RemoveNodeMemory<int>("NextBegin", t.m_Tree.ID.ToString(), t.m_CurNode.ID.ToString());
        }
        public override BevStatus Tick(Tick<T> t)
        {
            int begin = t.m_BlackBoard.GetNodeMemory<int>("NextBegin", t.m_Tree.ID.ToString(), t.m_CurNode.ID.ToString());
            for (int i = begin; i < m_Childs.Count; i++)
            {
                BevStatus status = m_Childs[i].Execute(t);
                if (status != BevStatus.FAILURE)
                {
                    if (status == BevStatus.RUNNING)
                    {
                        t.m_BlackBoard.SetNodeMemory<int>("NextBegin", t.m_Tree.ID.ToString(), t.m_CurNode.ID.ToString(), i);
                    }
                    return status;
                }
            }
            return BevStatus.FAILURE;
        }
    }
}
