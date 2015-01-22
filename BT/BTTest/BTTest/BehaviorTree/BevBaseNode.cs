using System.Collections;

namespace BehaviorTreeLib
{
    public class BevBaseNode<T>
    {
        public BevCondition<T> Condition;
        private static long m_IDCount;
        private long m_ID;

        public long ID
        {
            get { return m_ID; }
        }

        public BevBaseNode()
        {
            m_ID = m_IDCount++;
        }

        public BevStatus Execute(Tick<T> t)
        {
            this._enter(t);
            if (!t.m_BlackBoard.GetNodeMemory<bool>("isOpen", t.m_Tree.ID.ToString(), this.ID.ToString()))
            {
                this._open(t);
            }
            BevStatus status = this._tick(t);
            if (status != BevStatus.RUNNING)
            {
                this._close(t);
            }
            this._exit(t);
            return BevStatus.FAILURE;
        }

        private void _enter(Tick<T> t)
        {
            t.EnterNode(this);
            this.Enter(t);
        }
        private void _open(Tick<T> t)
        {
            t.OpenNode(this);
            t.m_BlackBoard.SetNodeMemory<bool>("isOpen", t.m_Tree.ID.ToString(), this.ID.ToString(), true);
            this.Open(t);
        }
        private BevStatus _tick(Tick<T> t)
        {
            t.TickNode(this);
            return this.Tick(t);
        }
        private void _close(Tick<T> t)
        {
            t.CloseNode(this);
            t.m_BlackBoard.SetNodeMemory<bool>("isOpen", t.m_Tree.ID.ToString(), this.ID.ToString(), false);
            this.Close(t);
        }
        private void _exit(Tick<T> t)
        {
            t.ExitNode(this);
            this.Exit(t);
        }



        public virtual void Enter(Tick<T> t)
        {

        }
        public virtual void Open(Tick<T> t)
        {

        }
        public virtual BevStatus Tick(Tick<T> t)
        {
            return BevStatus.SUCCESS;
        }
        public virtual void Close(Tick<T> t)
        {

        }
        public virtual void Exit(Tick<T> t)
        {

        }
        protected bool JudgeCondition(Tick<T> t)
        {
            return Condition == null ? true : Condition.Judge(t);
        }


    }
}