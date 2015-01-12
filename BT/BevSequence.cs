using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SlgGame.AI
{
		public class BevSequence:BevBaseNode
		{
				private List<BevBaseNode> m_Childs;
				private BevNodeType m_Type;

				public BevSequence ():base()
				{
						m_Childs = new List<BevBaseNode> ();
						m_Type = BevNodeType.BEV_NODE_SEQUENCE;
				}

				public void AddChilds (params BevBaseNode[] childs)
				{
						m_Childs.AddRange (childs);
				}

				public void RemoveChild (BevBaseNode child)
				{
						m_Childs.Remove (child);
				}

				public override bool Tick ()
				{
						if (!JudgeCondition ())
								return false;
						foreach (BevBaseNode child in m_Childs) {
								if (! child.Tick ())
										return false;
						}
						return true;
				}
		}
}