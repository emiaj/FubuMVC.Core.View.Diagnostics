using HelloWorld.Endpoints.Mistyped.Bar;
using HelloWorld.Endpoints.Mistyped.Baz;
using HelloWorld.Endpoints.Mistyped.Foo;

namespace HelloWorld.Endpoints.Mistyped
{
    public class MistypedEndpoint
    {
        public MistypedModel1 get_model1(MistypedModel1 input)
        {
            return input;
        }
        public MistypedModel2 get_model2(MistypedModel2 input)
        {
            return input;
        }
        public MistypedModel3 get_model3(MistypedModel3 input)
        {
            return input;
        }

    }

    namespace Foo
    {
        public class MistypedModel1
        {
        }

        public class ImNotACandidate
        {
        }
    }

    namespace Bar
    {
        public class MistypedModel2
        {
        }

        public class LookSomewhereElse
        {
        }
    }

    namespace Baz
    {
        public class MistypedModel3
        {
        }

        public class TheBazModel
        {
        }
    }
}