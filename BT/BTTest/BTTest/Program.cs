using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClass xiaoming = new TestClass();
            xiaoming.Name = "xiaoming";
            TestClass harrison = new TestClass();
            harrison.Name = "harrison";

            BehaviorTreeLib.BehaviorTree<TestClass> bt = new BehaviorTreeLib.BehaviorTree<TestClass>();
            bt.m_Root = new BehaviorTreeLib.BevSelector<TestClass>(new BehaviorTreeLib.BevAction<TestClass>(Say));
            BehaviorTreeLib.Blackboard blackBoard = new BehaviorTreeLib.Blackboard();

            while (true)
            {
                bt.Tick(xiaoming, blackBoard);
                bt.Tick(harrison, blackBoard);
            }

        }
        public static BehaviorTreeLib.BevStatus Say(BehaviorTreeLib.Tick<TestClass> t)
        {
            System.Console.WriteLine(t.m_Target.Name);
            return BehaviorTreeLib.BevStatus.SUCCESS;
        }
    }
    public class TestClass
    {
        public string Name;
    }
}
