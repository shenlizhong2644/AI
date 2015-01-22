using System.Collections;
using System;
namespace BehaviorTreeLib
{
    public class BevAction<T> : BevBaseNode<T>
    {

        private Func<Tick<T>, BevStatus> m_ActionHandle;

        public BevAction(Func<Tick<T>, BevStatus> ActionHandle)
            : base()
        {
            if (ActionHandle != null)
            {
                m_ActionHandle = ActionHandle;
            }
        }

        public override BevStatus Tick(Tick<T> t)
        {
            t.m_CurNode = this;
            if (!JudgeCondition(t)) return BevStatus.FAILURE;
            if (m_ActionHandle != null) return m_ActionHandle.Invoke(t);
            return BevStatus.FAILURE;
        }
    }
}