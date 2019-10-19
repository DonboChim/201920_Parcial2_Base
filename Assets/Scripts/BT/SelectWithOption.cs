using UnityEngine;

namespace AI
{
    public abstract class SelectWithOption : Selector
    {
        protected bool completed;
        [SerializeField]
        private Group successTree;

        [SerializeField]
        private Group failTree;

        protected override bool Check( )
        {
            return completed;
        }

        public override void Execute()
        {
            if (Check())
            {
                successTree.Execute();
            }
            else
            {
                failTree.Execute();
            }
        }
    }
}