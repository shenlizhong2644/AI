using System.Collections;
using System.Collections.Generic;

namespace BehaviorTreeLib
{
		public interface IBevNode
		{
				BevNodeType NodeType {
						get;
				}

			    bool Tick ();
		}
}