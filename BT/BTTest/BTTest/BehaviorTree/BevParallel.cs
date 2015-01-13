using System.Collections;
using System.Collections.Generic;

namespace BehaviorTreeLib
{
    public class BevParallel : BevBaseNode
    {
        private List<BevBaseNode> m_Childs;

        public BevParallel()
            : base()
        {
            m_Childs = new List<BevBaseNode>();
        }

        public void AddChild(BevBaseNode child)
        {
            m_Childs.Add(child);
        }

        public void AddChilds(params BevBaseNode[] childs)
        {
            m_Childs.AddRange(childs);
        }

        public void RemoveChild(BevBaseNode child)
        {
            m_Childs.Remove(child);
        }

        public override bool Tick()
        {
            if (!JudgeCondition())
                return false;
            foreach (BevBaseNode child in m_Childs)
            {
                child.Tick();
            }
            return true;
        }

    }
}