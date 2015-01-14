using System.Collections;
using System.Collections.Generic;

namespace BehaviorTreeLib
{
    public class BevSelector : BevBaseNode
    {
        public List<BevBaseNode> m_Childs;

        public BevSelector()
        {
            m_Childs = new List<BevBaseNode>();
            Condition = null;
        }

        public void AddChild(BevBaseNode child)
        {
            m_Childs.Add(child);
        }

        public void AddChilds(params BevBaseNode[] childs)
        {
            //BevBaseNode[] nodes = childs ;
            m_Childs.AddRange(childs);
        }

        /*public void AddChilds (params object[] childs)
        {
                foreach (BevBaseNode node in childs)
                        Debug.Log (node);
                m_Childs.AddRange (childs as BevBaseNode[]);
        }*/

        public void RemoveChild(BevBaseNode child)
        {
            m_Childs.Remove(child);
        }

        public override BevStatus Tick()
        {
            if (!JudgeCondition())
                return BevStatus.FAILURE;
            foreach (BevBaseNode child in m_Childs)
            {
                if (BevStatus.SUCCESS == child.Tick())
                {
                    return BevStatus.SUCCESS;
                }
            }
            return BevStatus.FAILURE;
        }
    }
}