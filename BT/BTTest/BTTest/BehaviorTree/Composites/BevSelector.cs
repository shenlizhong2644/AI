using System.Collections;
using System.Collections.Generic;

namespace BehaviorTreeLib
{
    public class BevSelector<T> : BevBaseNode<T>
    {
        public List<BevBaseNode<T>> m_Childs;

        public BevSelector()
        {
            m_Childs = new List<BevBaseNode<T>>();
            Condition = null;
        }
        public BevSelector(params BevBaseNode<T>[] childs)
        {
            m_Childs = new List<BevBaseNode<T>>();
            Condition = null;
            m_Childs.AddRange(childs);
        }

        public void AddChild(BevBaseNode<T> child)
        {
            m_Childs.Add(child);
        }

        public void AddChilds(params BevBaseNode<T>[] childs)
        {
            m_Childs.AddRange(childs);
        }

        public void RemoveChild(BevBaseNode<T> child)
        {
            m_Childs.Remove(child);
        }

        public override BevStatus Tick(Tick<T> t)
        {
            if (!JudgeCondition(t))
                return BevStatus.FAILURE;
            foreach (BevBaseNode<T> child in m_Childs)
            {
                if (BevStatus.SUCCESS == child.Execute(t))
                {
                    return BevStatus.SUCCESS;
                }
            }
            return BevStatus.FAILURE;
        }
    }
}