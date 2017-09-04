namespace AnotherWebFormsIocApproach.StructureMap
{
    using global::StructureMap;

    public static class IoC
    {
        public static IContainer Initialize()
        {
            return new Container(new ScanningRegistry());
        }
    }
}