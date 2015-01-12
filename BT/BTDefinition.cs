using UnityEngine;
using System.Collections;

namespace SlgGame.AI
{
	public enum BevConditionOperator
	{
		AND,
		OR,
		NOTHING
	}
	
	public enum BevNodeType
	{
		BEV_NODE_SELECTOR,
		BEV_NODE_SEQUENCE,
		BEV_NODE_PARALLEL,
		BEV_NODE_ACTION,
		BEV_NODE_CONDITION
	}

	public enum Status
	{
		RUNNING,
		COMPLETED
	}
}
