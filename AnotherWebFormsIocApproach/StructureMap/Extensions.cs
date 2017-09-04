namespace AnotherWebFormsIocApproach.StructureMap
{
    using Microsoft.Practices.ServiceLocation;

    public static class Extensions
    {
        public static  void BuildUp(this IServiceLocator serviceLocator, object obj)
        {
            ((IBuildUp) serviceLocator).BuildUp(obj);
        }
    }
}