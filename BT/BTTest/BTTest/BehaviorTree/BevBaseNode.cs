using System.Collections;

namespace BehaviorTreeLib
{
    public class BevBaseNode<T>
    {
        public BevCondition<T> Condition;
        private static long m_IDCount;
        private long m_ID;

        public BevBaseNode()
        {
            m_ID = m_IDCount++;
        }

        public virtual BevStatus Execute(Tick<T> t)
        {
            return BevStatus.FAILURE;
        }

        protected bool JudgeCondition(Tick<T> t)
        {
            return Condition == null ? true : Condition.Judge(t);
        }


    }
}