using System.Collections.Generic;

namespace FubuMVC.Core.View.Diagnostics
{
    public class ViewProblemStoreCache : IViewProblemStoreCache
    {
        private readonly IList<ViewProblem> _problems = new List<ViewProblem>();

        public IEnumerable<ViewProblem> Problems
        {
            get { return _problems; }
        }

        public void Append(ViewProblem problem)
        {
            _problems.Add(problem);
        }
    }
}