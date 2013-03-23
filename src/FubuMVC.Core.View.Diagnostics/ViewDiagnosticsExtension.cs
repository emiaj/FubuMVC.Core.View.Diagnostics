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
        }
    }
}