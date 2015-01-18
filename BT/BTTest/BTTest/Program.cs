using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTest
{
    class Program
    {
        static TestClass xiaoming;
        static TestClass harrison;
        static void Main(string[] args)
        {
            xiaoming = new TestClass();
            xiaoming.Name = "xiaoming";
            harrison = new TestClass();
            harrison.Name = "harrison";

            BehaviorTreeLib.BehaviorTree<TestClass> bt = new BehaviorTreeLib.BehaviorTree<TestClass>();
            bt.m_Root = new BehaviorTreeLib.BevSelector<TestClass>(new BehaviorTreeLib.BevAction<TestClass>(Say));
            BehaviorTreeLib.Blackboard blackBoard = new BehaviorTreeLib.Blackboard();
            BehaviorTreeLib.BehaviorTree<TestClass> btt = new BehaviorTreeLib.BehaviorTree<TestClass>();
            btt.m_Root = new BehaviorTreeLib.BevSelector<TestClass>(new BehaviorTreeLib.BevAction<TestClass>(Say));
            while (true)
            {
                bt.Tick(null, blackBoard);
                btt.Tick(null, blackBoard);
            }

        }
        public static BehaviorTreeLib.BevStatus Say(BehaviorTreeLib.Tick<TestClass> t)
        {
            int str=0;
            str=t.m_BlackBoard.GetGlobalMemory<int>("value");
            System.Console.WriteLine(str);
            t.m_BlackBoard.SetGlobalMemory<int>("value", ++str);
            return BehaviorTreeLib.BevStatus.SUCCESS;
        }
    }
    public class TestClass
    {
        public string Name;
    }
}
