using System;
using System.Collections.Generic;

namespace BehaviorTreeLib
{
    class Inverter<T> : BevBaseNode<T>
    {
        private BevBaseNode<T> m_Child;
        public Inverter(BevBaseNode<T> child)
            : base()
        {
            m_Child = child;
        }
        public Inverter()
            : base()
        {

        }
        public void Update(BevBaseNode<T> child)
        {
            m_Child = child;
        }
        public override BevStatus Execute(Tick<T> t)
        {
            BevStatus status = m_Child.Execute(t);
            if (BevStatus.FAILURE == status)
                return BevStatus.SUCCESS;
            else if (BevStatus.SUCCESS == status)
                return BevStatus.FAILURE;
            return BevStatus.RUNNING;
        }
    }
}
