namespace AnotherWebFormsIocApproach
{
    using System;

    public partial class ExampleControl : BaseUserControlWithIoC
    {
        public ILogger Logger { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Logger.LogMessage("Logging from User Control");
        }
    }
}