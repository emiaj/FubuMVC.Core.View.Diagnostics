using System.Collections.Generic;

namespace FubuMVC.Core.View.Diagnostics
{
    public interface IViewProblemStoreCache
    {
        IEnumerable<ViewProblem> Problems { get; }
        void Append(ViewProblem problem);
    }
}