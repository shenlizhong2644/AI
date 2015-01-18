using System.Collections;
using System.Collections.Generic;
using System;
namespace BehaviorTreeLib
{
    public class BevCondition<T>
    {

        private List<BevCondition<T>> m_LinkCondition;

        private Func<Tick<T>,Boolean> m_ConditionHandle;

        private BevConditionOperator m_Operator;
        public bool Judge(Tick<T> t)
        {
            bool result = m_ConditionHandle(t);
            foreach (BevCondition<T> link_condition in m_LinkCondition)
            {
                switch (link_condition.m_Operator)
                {
                    case BevConditionOperator.AND:
                        result &= link_condition.Judge(t);
                        break;
                    case BevConditionOperator.OR:
                        result |= link_condition.Judge(t);
                        break;
                    case BevConditionOperator.NOTHING:
                        throw new System.InvalidOperationException();
                }
            }
            return result;
        }

        public BevCondition(Func<Tick<T>, Boolean> ConditionHandle)
        {
            if (ConditionHandle == null) throw new System.ArgumentNullException();
            m_LinkCondition = new List<BevCondition<T>>();
            m_Operator = BevConditionOperator.NOTHING;
            m_ConditionHandle = ConditionHandle;

        }

        public static BevCondition<T> operator &(BevCondition<T> Condition1, BevCondition<T> Condition2)
        {
            if (Condition1 == null)
                return Condition2;
            Condition2.m_Operator = BevConditionOperator.AND;
            Condition1.m_LinkCondition.Add(Condition2);
            return Condition1;
        }

        public static BevCondition<T> operator |(BevCondition<T> Condition1, BevCondition<T> Condition2)
        {
            Condition2.m_Operator = BevConditionOperator.OR;
            Condition1.m_LinkCondition.Add(Condition2);
            return Condition1;
        }

        public static BevCondition<T> operator &(BevCondition<T> Condition1, Func<Tick<T>, Boolean> ConditionHandle)
        {
            return Condition1 & new BevCondition<T>(ConditionHandle);
        }

        public static BevCondition<T> operator |(BevCondition<T> Condition1, Func<Tick<T>, Boolean> ConditionHandle)
        {
            return Condition1 | new BevCondition<T>(ConditionHandle);
        }
    }
}