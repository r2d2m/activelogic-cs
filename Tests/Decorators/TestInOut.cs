using NUnit.Framework;

using Active.Core;

public class TestInOut : DecoratorTest<InOut> {

    [Test] public void T0_0(){ o( x[false, false] == null ); }
	[Test] public void T0_1(){ o( x[false, true ] == null ); }
    [Test] public void T1_0(){ o( x[true,  false] != null); }
    [Test] public void T1_1(){ o( x[true,  true ] != null); }

    [Test] public void In_then_0_0()
        { var s = x[true, false]; o(x[false, false] != null); }

    [Test] public void In_then_0_1()
        { var s = x[true, false]; o(x[false, true] == null); }

    [Test] public void In_then_1_0()
        { var s = x[true, false]; o(x[true, false] != null); }

    [Test] public void In_then_1_1()
        { var s = x[true, false]; o(x[true, true] == null); }

    [Test] public void Cycle(){
        // initially neither condition is true; not passing
        o(x[false, false] == null);
        // when in condition becomes true, passing
        o(x[true, false] != null);
        // still passing even though in condition is no longer true
        o(x[false, false] != null);
        // now blocking because out condition is true
        o(x[false, true] == null);
        o(x[false, false] == null);
    }

}
