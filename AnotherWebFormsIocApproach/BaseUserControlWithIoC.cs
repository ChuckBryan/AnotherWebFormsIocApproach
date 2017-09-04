namespace AnotherWebFormsIocApproach
{
    using System;
    using System.Web.UI;
    using Microsoft.Practices.ServiceLocation;
    using StructureMap;

    public class BaseUserControlWithIoC : UserControl
    {
        protected override void OnLoad(EventArgs e)
        {
            ServiceLocator.Current.BuildUp(this);
            base.OnLoad(e);
        }
    }
}