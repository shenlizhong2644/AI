using System;
using System.Collections.Generic;

namespace BehaviorTreeLib
{
    public class Blackboard
    {
        private Dictionary<string, Object> m_GlobalMemory;
        private Dictionary<string, Object> m_TreeMemory;
        private Dictionary<string, Object> m_NodeMemory;
        public Blackboard()
        {
            _initialize();
        }
        private void _initialize()
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
            Object result = null;
            return m_NodeMemory.TryGetValue(key + "_" + treeID + "_" + nodeID, out result) ? (T)result : default(T);
        }
        public T GetTreeMemory<T>(string key, string treeID)
        {
            Object result = null;
            return m_TreeMemory.TryGetValue(key + "_" + treeID, out result) ? (T)result : default(T);
        }
        public T GetGlobalMemory<T>(string key)
        {
            Object result = null;
            return m_GlobalMemory.TryGetValue(key, out result) ? (T)result : default(T);
        }
    }
}
