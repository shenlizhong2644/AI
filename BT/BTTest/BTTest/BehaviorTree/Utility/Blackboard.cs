using System;
using System.Collections.Generic;

namespace BehaviorTreeLib
{
    public class Blackboard
    {
        private Dictionary<string, Object> m_GlobalMemory;
        private Dictionary<string, Object> m_TreeMemory;
        private Dictionary<string, Object> m_NodeMemory;
        public void Initialize()
        {
            m_GlobalMemory = new Dictionary<string, Object>();
            m_TreeMemory = new Dictionary<string, Object>();
            m_NodeMemory = new Dictionary<string, Object>();
        }
        public void SetNodeMemory<T>(string key, string treeID, string nodeID, T value)
        {
            m_NodeMemory[key + "_" + treeID + "_" + nodeID] = value;
        }
        public void SetTreeMemory<T>(string key, string treeID, T value)
        {
            m_TreeMemory[key + "_" + treeID] = value;
        }
        public void SetGlobalMemory<T>(string key, T value)
        {
            m_GlobalMemory[key] = value;
        }
        public T GetNodeMemory<T>(string key, string treeID, string nodeID)
        {
            return (T)m_NodeMemory[key + "_" + treeID + "_" + nodeID];
        }
        public T GetTreeMemory<T>(string key, string treeID)
        {
            return (T)m_TreeMemory[key + "_" + treeID];
        }
        public T GetNodeMemory<T>(string key)
        {
            return (T)m_GlobalMemory[key];
        }
    }
}
