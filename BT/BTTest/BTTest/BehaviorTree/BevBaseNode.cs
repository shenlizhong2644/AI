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

        public virtual bool Tick()
        {
            return true;
        }

        protected bool JudgeCondition()
        {
            return Condition == null ? true : Condition.Judge();
        }


    }
}