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

        public override BevStatus Tick(Tick<T> t)
        {
            if (!JudgeCondition(t))
                return BevStatus.FAILURE;
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
