using System.Collections;

namespace BehaviorTreeLib
{
    public class BevBaseNode
    {
        public BevCondition Condition;
        private static long m_IDCount;
        private long m_ID;

        public BevBaseNode()
        {
            m_ID = m_IDCount++;
        }

        public virtual BevStatus Tick()
        {
            return BevStatus.FAILURE;
        }

        protected bool JudgeCondition()
        {
            return Condition == null ? true : Condition.Judge();
        }


    }
}