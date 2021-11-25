using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System;

namespace a.zalecke_homework
{
    public class Tests : WebDriver
    {
        private string email = "gaga@gmail.com";
        private string password = "password";

        private HomePage homePage = new HomePage();
        private LoginPage loginPage = new LoginPage();

        [SetUp]
        public void Setup()
        {
            Driver = new ChromeDriver(); 
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        [Test]
        public void Test1()
        {
            IWebElement login_btn = Driver.FindElement(By.CssSelector("#header > div.nav > div > div > nav > div.header_user_info > a"));
            login_btn.Click();
        }

        [Test]
        public void Search()
        {
            DoLogin();

            Driver.FindElement(By.Name("search_query")).SendKeys("blouse");
            Driver.FindElement(By.Name("submit_search")).Submit();
            IWebElement product = Driver.FindElement(By.ClassName("product-name"));
            string productTitle = product.GetAttribute("title");
            Assert.AreEqual("Blouse", productTitle, "Error message: product page not found");

            IWebElement add_btn = Driver.FindElement(By.Name("Add to cart"));
            add_btn.Click();

            IWebElement proceed_btn = Driver.FindElement(By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_cart.col-xs-12.col-md-6 > div.button-container > a"));
            proceed_btn.Click();

            IWebElement proceed_btn2 = Driver.FindElement(By.ClassName("button btn btn-default standard-checkout button-medium"));
            proceed_btn2.Click();

            IWebElement proceed_btn3 = Driver.FindElement(By.Name("processAddress"));
            proceed_btn3.Click();

            IWebElement check_btn = Driver.FindElement(By.Name("cgv"));
            check_btn.Click();
            IWebElement proceed_btn4 = Driver.FindElement(By.Name("processCarrier"));
            proceed_btn4.Click();

            IWebElement bank_btn = Driver.FindElement(By.ClassName("bankwire"));
            bank_btn.Click();

            IWebElement confirm_btn = Driver.FindElement(By.ClassName("button btn btn-default button-medium"));
            confirm_btn.Click();

            IWebElement confirmationpage = Driver.FindElement(By.Id("order-confirmation"));
            string productconfirmed = confirmationpage.GetAttribute("id");
            Assert.AreEqual("order-confirmation", productconfirmed, "Error message: product page not found");

        }


        [Test]
        public void TestHomePage()
        {
            homePage.ClickLoginButton();
        }

        [Test]
        public void TestLoginPage()
        {
            homePage.ClickLoginButton();
            loginPage.DoLoginProcess();
        }

        public void DoLogin()
        {
            IWebElement email_txt = Driver.FindElement(By.Name("email"));
            email_txt.SendKeys("email");

            IWebElement password_txt = Driver.FindElement(By.Name("passwd"));
            password_txt.SendKeys("password");

            IWebElement signin_btn = Driver.FindElement(By.Name("SubmitLogin"));
            signin_btn.Click();
            Assert.AreEqual("SubmitLogin", signin_btn.Text, "Error message: credentials are invalid");

        }



    }

}

