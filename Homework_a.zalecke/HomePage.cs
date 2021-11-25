using OpenQA.Selenium;

namespace a.zalecke_homework
{
    public class HomePage : WebDriver
    {
        private IWebElement GetLoginButton()
        {
            return Driver.FindElement(By.CssSelector("#header > div.nav > div > div > nav > div.header_user_info > a"));
        }
        public void ClickLoginButton()
        {
            GetLoginButton().Click();
        }
    }

}
