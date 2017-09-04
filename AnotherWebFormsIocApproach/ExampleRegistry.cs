namespace AnotherWebFormsIocApproach
{
    using global::StructureMap;

    public class ExampleRegistry : Registry
    {
        public ExampleRegistry()
        {
            For<ILogger>().ContainerScoped();
        }
    }
}