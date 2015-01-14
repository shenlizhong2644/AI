using System.Collections;
using System.Collections.Generic;

namespace BehaviorTreeLib
{
		public class BevSequence:BevBaseNode
		{
				private List<BevBaseNode> m_Childs;

				public BevSequence ():base()
				{
						m_Childs = new List<BevBaseNode> ();
				}

				public void AddChilds (params BevBaseNode[] childs)
				{
						m_Childs.AddRange (childs);
				}

				public void RemoveChild (BevBaseNode child)
				{
						m_Childs.Remove (child);
				}

				public override BevStatus Tick ()
				{
						if (!JudgeCondition ())
                            return BevStatus.FAILURE;
						foreach (BevBaseNode child in m_Childs) {
								if (BevStatus.FAILURE== child.Tick ())
										return BevStatus.FAILURE;
						}
						return BevStatus.SUCCESS;
				}
		}
}