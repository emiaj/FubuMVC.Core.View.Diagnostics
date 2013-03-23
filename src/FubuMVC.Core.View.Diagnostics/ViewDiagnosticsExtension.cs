using Bottles;
using FubuMVC.Core.View.Diagnostics.Endpoints;
using FubuMVC.Core.View.Diagnostics.Navigation;

namespace FubuMVC.Core.View.Diagnostics
{
    public class ViewDiagnosticsExtension : IFubuRegistryExtension
    {
        public void Configure(FubuRegistry registry)
        {
            registry.Policies.Add<ViewDiagnosticsMenu>();
            registry.Actions.IncludeType<ViewsEndpoint>();
            registry.Services(x => x.FillType<IActivator, ProblemGatherer>());
            registry.Services(x => x.FillType<IViewProblemStoreCache, ViewProblemStoreCache>());
        }
    }
}