using System.Collections.Generic;
using Autofac;
using NIST.CVP.ACVTS.Libraries.Common;
using NIST.CVP.ACVTS.Libraries.Generation.Core;
using NIST.CVP.ACVTS.Libraries.Generation.Core.Async;
using NIST.CVP.ACVTS.Libraries.Generation.Core.DeSerialization;
using NIST.CVP.ACVTS.Libraries.Generation.Core.JsonConverters;
using NIST.CVP.ACVTS.Libraries.Generation.Core.Parsers;
using NIST.CVP.ACVTS.Libraries.Generation.ML_DSA.FIPS204.SigVer.ContractResolvers;

namespace NIST.CVP.ACVTS.Libraries.Generation.ML_DSA.FIPS204.SigVer;

public class RegisterInjections : ISupportedAlgoModeRevisions
{
    public IEnumerable<AlgoMode> SupportedAlgoModeRevisions => new List<AlgoMode>
    {
        AlgoMode.ML_DSA_SigVer_FIPS204
    };

    public void RegisterTypes(ContainerBuilder builder, AlgoMode algoMode)
    {
        builder.RegisterType<Generator<Parameters, TestVectorSet, TestGroup, TestCase>>().AsImplementedInterfaces();
        builder.RegisterType<ParameterChecker<Parameters>>().AsImplementedInterfaces();

        builder.RegisterType<TestCaseGeneratorFactory>().AsImplementedInterfaces();
        builder.RegisterType<TestCaseGeneratorFactoryFactoryAsync<TestVectorSet, TestGroup, TestCase>>().AsImplementedInterfaces();
        builder.RegisterType<TestCaseValidatorFactory>().AsImplementedInterfaces();
        builder.RegisterType<TestVectorFactory<Parameters, TestVectorSet, TestGroup, TestCase>>().AsImplementedInterfaces();
        builder.RegisterType<TestGroupGeneratorFactory>().AsImplementedInterfaces();
        builder.RegisterType<ParameterValidator>().AsImplementedInterfaces();
        builder.RegisterType<ParameterParser<Parameters>>().AsImplementedInterfaces();

        builder.RegisterType<ValidatorAsync<TestVectorSet, TestGroup, TestCase>>().AsImplementedInterfaces();
        builder.RegisterType<ResultValidatorAsync<TestGroup, TestCase>>().AsImplementedInterfaces();
        builder.RegisterType<DynamicParser>().AsImplementedInterfaces();

        builder.RegisterType<JsonConverterProvider>().AsImplementedInterfaces();
        builder.RegisterType<ContractResolverFactory>().AsImplementedInterfaces();
        builder.RegisterType<VectorSetSerializer<TestVectorSet, TestGroup, TestCase>>().AsImplementedInterfaces();
        builder.RegisterType<VectorSetDeserializer<TestVectorSet, TestGroup, TestCase>>().AsImplementedInterfaces();
    }
}
