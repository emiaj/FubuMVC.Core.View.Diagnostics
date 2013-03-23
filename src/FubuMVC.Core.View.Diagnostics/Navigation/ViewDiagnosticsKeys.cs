using FubuLocalization;
using FubuMVC.Diagnostics.Navigation;

namespace FubuMVC.Core.View.Diagnostics.Navigation
{
    public class ViewDiagnosticsKeys : StringToken
    {
        public static readonly DiagnosticKeys Views = new DiagnosticKeys("Views");

        public ViewDiagnosticsKeys(string defaultValue)
            : base(null, defaultValue, namespaceByType: true)
        {
        }
    }
}