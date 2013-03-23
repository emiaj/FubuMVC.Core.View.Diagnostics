using FubuMVC.Core;
using HelloWorld.Endpoints;
using HelloWorld.Endpoints.Home;

namespace HelloWorld
{
    public class AppRegistry : FubuRegistry
    {
        public AppRegistry()
        {
            Routes.HomeIs<HomeInput>();
        }
    }
}