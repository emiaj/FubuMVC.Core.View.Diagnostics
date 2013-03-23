using System.Collections.Generic;

namespace FubuMVC.Core.View.Diagnostics.Endpoints
{
    public class ViewsEndpoint
    {
        private readonly IViewProblemStoreCache _cache;

        public ViewsEndpoint(IViewProblemStoreCache cache)
        {
            _cache = cache;
        }

        public ViewDiagnosticsModel get_views(ViewDiagnosticsInput input)
        {
            var model = new ViewDiagnosticsModel {Problems = _cache.Problems};
            return model;
        }
    }

    public class ViewDiagnosticsInput
    {
    }

    public class ViewDiagnosticsModel
    {
        public IEnumerable<ViewProblem> Problems { get; set; }
    }

}