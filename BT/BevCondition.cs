using System.Collections;
using System.Collections.Generic;

namespace BehaviorTreeLib
{
		public class BevCondition
		{
				
				public delegate bool BevConditionHandleDelegate ();

				private List<BevCondition> m_LinkCondition;
				
				private event BevConditionHandleDelegate m_ConditionHandle;
				
				private BevConditionOperator m_Operator;
				public bool Judge ()
				{
						bool result = m_ConditionHandle ();
						foreach (BevCondition link_condition in m_LinkCondition) {
								switch (link_condition.m_Operator) {
								case BevConditionOperator.AND:
										result &= link_condition.Judge ();
										break;
								case BevConditionOperator.OR:
										result |= link_condition.Judge ();
										break;
								case BevConditionOperator.NOTHING:
										Debug.LogError ("Operator is Nothing");
										break;
								}
						}
						return result;
				}

				public BevCondition (BevConditionHandleDelegate ConditionHandle)
				{
						if (ConditionHandle == null) {
								Debug.LogError ("ConditionHandle was null");
						}
						m_LinkCondition = new List<BevCondition> ();
						m_Operator = BevConditionOperator.NOTHING;
						m_ConditionHandle = ConditionHandle;
						
				}
				
				public static BevCondition operator & (BevCondition Condition1, BevCondition Condition2)
				{
						if (Condition1 == null)
								return Condition2;
						Condition2.m_Operator = BevConditionOperator.AND;
						Condition1.m_LinkCondition.Add (Condition2);
						return Condition1;
				}

				public static BevCondition operator | (BevCondition Condition1, BevCondition Condition2)
				{
						Condition2.m_Operator = BevConditionOperator.OR;
						Condition1.m_LinkCondition.Add (Condition2);
						return Condition1;
				}

				public static BevCondition operator & (BevCondition Condition1, BevConditionHandleDelegate ConditionHandle)
				{
						return Condition1 & new BevCondition (ConditionHandle);	
				}

				public static BevCondition operator | (BevCondition Condition1, BevConditionHandleDelegate ConditionHandle)
				{
						return Condition1 | new BevCondition (ConditionHandle);
				}
		}
}