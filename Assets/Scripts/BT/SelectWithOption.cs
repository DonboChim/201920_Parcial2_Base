using UnityEngine;

namespace AI
{
    public abstract class SelectWithOption : Selector
    {
        [SerializeField]
        private Group successTree;

        [SerializeField]
        private Group failTree;

        protected override bool Check()
        {
            throw new System.NotImplementedException();
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