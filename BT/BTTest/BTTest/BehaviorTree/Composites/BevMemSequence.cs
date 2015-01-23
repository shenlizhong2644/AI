using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviorTreeLib
{
    class BevMemSequence<T> : BevBaseNode<T>
    {
        private List<BevBaseNode<T>> m_Childs;
        public BevMemSequence(params BevBaseNode<T>[] childs)
        {
            m_Childs = new List<BevBaseNode<T>>();
            m_Childs.AddRange(childs);
        }
        public BevMemSequence()
        {
 
        }
        public void AddChilds(params BevBaseNode<T>[] childs)
        {
            m_Childs.AddRange(childs);
        }
        public override BevStatus Tick(Tick<T> t)
        {
            if (!JudgeCondition(t))
                return BevStatus.FAILURE;
            int begin = t.m_BlackBoard.GetNodeMemory<int>("NextBegin", t.m_Tree.ID.ToString(), t.m_CurNode.ID.ToString());
            for (int i = begin; i < m_Childs.Count; i++)
            {
                BevStatus status = m_Childs[i].Execute(t);
                if (status != BevStatus.SUCCESS)
                {
                    if (status == BevStatus.RUNNING)
                    {
                        t.m_BlackBoard.SetNodeMemory<int>("NextBegin", t.m_Tree.ID.ToString(), t.m_CurNode.ID.ToString(), i);
                    }
                    return status;
                }
            }
            return BevStatus.SUCCESS;
        }
    }
}
