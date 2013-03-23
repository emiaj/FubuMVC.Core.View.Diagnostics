using FubuMVC.Core.View.Diagnostics.Endpoints;
using FubuMVC.Diagnostics.Navigation;
using FubuMVC.Navigation;

namespace FubuMVC.Core.View.Diagnostics.Navigation
{
    public class ViewDiagnosticsMenu : NavigationRegistry
    {
        public ViewDiagnosticsMenu()
        {
            ForMenu(DiagnosticKeys.Main);
            Add += MenuNode.ForInput<ViewDiagnosticsInput>(ViewDiagnosticsKeys.Views);
        }
    }
}