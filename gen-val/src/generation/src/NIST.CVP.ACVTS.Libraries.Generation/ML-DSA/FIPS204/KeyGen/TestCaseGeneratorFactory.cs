using NIST.CVP.ACVTS.Libraries.Generation.Core.Async;
using NIST.CVP.ACVTS.Libraries.Oracle.Abstractions;

namespace NIST.CVP.ACVTS.Libraries.Generation.ML_DSA.FIPS204.KeyGen;

public class TestCaseGeneratorFactory : ITestCaseGeneratorFactoryAsync<TestGroup, TestCase>
{
    private readonly IOracle _oracle;
        
    public TestCaseGeneratorFactory(IOracle oracle)
    {
        _oracle = oracle;
    }
        
    public ITestCaseGeneratorAsync<TestGroup, TestCase> GetCaseGenerator(TestGroup testGroup)
    {
        return new TestCaseGenerator(_oracle);
    }
}
