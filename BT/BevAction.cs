using UnityEngine;
using System.Collections;

namespace SlgGame.AI
{
    public class BevAction : BevBaseNode
    {
        public delegate void BevActionHandleDelegate();

        private event BevActionHandleDelegate m_ActionHandle;

        public float DelayTime;

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
            DelayTime = 0;

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
            if (!JudgeCondition())
                return false;
            if (DelayTime != 0)
            {
                Debug.Log("Delay:" + DelayTime);
                SlgGame.GameManager.Instance.BattleManager.AISystem.StartCoroutine(SlgGame.GameManager.Instance.BattleManager.AISystem.DelayExecute(m_ActionHandle, DelayTime));
                return true;
            }
            if (m_ActionHandle != null)
            {
                m_ActionHandle();
            }
            return true;
        }
    }
}