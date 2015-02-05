using System.Collections;
using System.Collections.Generic;

namespace BehaviorTreeLib
{
    public class BevSequence<T> : BevBaseNode<T>
    {
        private List<BevBaseNode<T>> m_Childs;

        public BevSequence()
            : base()
        {
            m_Childs = new List<BevBaseNode<T>>();
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
            foreach (BevBaseNode<T> child in m_Childs)
            {
                if (BevStatus.FAILURE == child.Execute(t))
                    return BevStatus.FAILURE;
            }
            return BevStatus.SUCCESS;
        }
    }
}