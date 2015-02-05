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
            m_NodeMemory[typeof(T).ToString() + "_" + key + "_" + treeID + "_" + nodeID] = value;
        }
        public void SetTreeMemory<T>(string key, string treeID, T value)
        {
            m_TreeMemory[typeof(T).ToString() + "_" + key + "_" + treeID] = value;
        }
        public void SetGlobalMemory<T>(string key, T value)
        {
            m_GlobalMemory[typeof(T).ToString() + "_" + key] = value;
        }
        public void RemoveNodeMemory<T>(string key, string treeID, string nodeID)
        {
            m_NodeMemory.Remove(typeof(T).ToString()+"_"+ key + "_" + treeID + "_" + nodeID);
        }
        public void RemoveTreeMemory<T>(string key, string treeID)
        {
            m_NodeMemory.Remove(typeof(T).ToString() + "_" + key + "_" + treeID);
        }
        public void RemoveGlobalMemory<T>(string key)
        {
            m_NodeMemory.Remove(typeof(T).ToString() + "_" + key);
        }
        public T GetNodeMemory<T>(string key, string treeID, string nodeID)
        {
            Object result = null;
            return m_NodeMemory.TryGetValue(typeof(T).ToString() + "_" + key + "_" + treeID + "_" + nodeID, out result) ? (T)result : default(T);
        }
        public T GetTreeMemory<T>(string key, string treeID)
        {
            Object result = null;
            return m_TreeMemory.TryGetValue(typeof(T).ToString() + "_" + key + "_" + treeID, out result) ? (T)result : default(T);
        }
        public T GetGlobalMemory<T>(string key)
        {
            Object result = null;
            return m_GlobalMemory.TryGetValue(typeof(T).ToString() + "_" + key, out result) ? (T)result : default(T);
        }
    }
}
