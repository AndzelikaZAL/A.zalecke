using OpenQA.Selenium;

namespace a.zalecke_homework
{
    public class LoginPage : WebDriver
    {
        private IWebElement GetEmailField() { return Driver.FindElement(By.Name("email")); }
        private IWebElement GetPasswordField() { return Driver.FindElement(By.Name("passwd")); }
        private IWebElement GetLoginButton() { return Driver.FindElement(By.Name("SubmitLogin")); }

        public void DoLoginProcess()
        {
            GetEmailField().SendKeys("gaga@gmail.com");
            GetPasswordField().SendKeys("password");
            GetLoginButton().Click();
        }

    }

}
