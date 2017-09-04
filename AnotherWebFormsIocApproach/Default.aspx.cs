namespace AnotherWebFormsIocApproach
{
    using System;

    public partial class _Default : BasePageWithIoC
    {
        public IEmailService EmailService { get; set; }

        public ILogger LoggerService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoggerService.LogMessage("TEST");
        }
    }
}