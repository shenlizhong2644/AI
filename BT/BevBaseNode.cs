using UnityEngine;
using System.Collections;

namespace SlgGame.AI
{
		public class BevBaseNode :IBevNode
		{
				protected BevNodeType m_Type;
				public BevCondition Condition;
				private static long m_IDCount;
				private long m_ID;

				public BevBaseNode ()
				{
						m_ID = m_IDCount++;
				}

				public virtual bool Tick ()
				{
						return true;
				}

				protected bool JudgeCondition ()
				{
						return Condition == null ? true : Condition.Judge ();
				}

				public BevNodeType NodeType {
						get {
								return m_Type;
						}
				}
			
		}
}