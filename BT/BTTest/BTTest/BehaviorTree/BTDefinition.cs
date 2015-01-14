using System.Collections;

namespace BehaviorTreeLib
{
	public enum BevConditionOperator
	{
		AND,
		OR,
		NOTHING
	}

	public enum BevStatus
	{
		RUNNING,
		SUCCESS,
        FAILURE
	}
}
