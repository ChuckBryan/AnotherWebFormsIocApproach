namespace AnotherWebFormsIocApproach
{
    using System;
    using System.Web.UI;
    using Microsoft.Practices.ServiceLocation;
    using StructureMap;

    public class BasePageWithIoC : Page
    {
        protected override void OnInit(EventArgs e)
        {
            ServiceLocator.Current.BuildUp(this);
            base.OnInit(e);
            
        }
    }
}