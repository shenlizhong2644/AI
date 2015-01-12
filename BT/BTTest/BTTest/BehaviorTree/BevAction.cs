using System.Collections;

namespace BehaviorTreeLib
{
    public class BevAction : BevBaseNode
    {
        public delegate void BevActionHandleDelegate();

        private event BevActionHandleDelegate m_ActionHandle;

        public BevAction(params BevActionHandleDelegate[] ActionHandle)
            : base()
        {
            m_Type = BevNodeType.BEV_NODE_ACTION;
            if (ActionHandle != null)
            {
                foreach (BevActionHandleDelegate action in ActionHandle)
                {
                    m_ActionHandle += action;
                }
            }
        }

        public void AddChilds(params BevActionHandleDelegate[] childs)
        {
            foreach (BevActionHandleDelegate action in childs)
            {
                m_ActionHandle += action;
            }
        }

        public override bool Tick()
        {
            if (!JudgeCondition()) return false;
            if (m_ActionHandle != null) m_ActionHandle();
            return true;
        }
    }
}