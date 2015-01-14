using System.Collections;
using System;
namespace BehaviorTreeLib
{
    public class BevAction : BevBaseNode
    {
        public delegate void BevActionHandleDelegate();

        private Func<BevStatus> m_ActionHandle;

        public BevAction(Func<BevStatus> ActionHandle)
            : base()
        {
            if (ActionHandle != null)
            {
                m_ActionHandle = ActionHandle;
            }
        }

        public override BevStatus Tick()
        {
            if (!JudgeCondition()) return BevStatus.FAILURE;
            if (m_ActionHandle != null) return m_ActionHandle.Invoke();
            return BevStatus.FAILURE;
        }
    }
}