using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SlgGame.AI
{
		public interface IBevNode
		{
				BevNodeType NodeType {
						get;
				}

			    bool Tick ();
		}
}