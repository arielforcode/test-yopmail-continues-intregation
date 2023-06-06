using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using YoMail.code.page;
using YoMail.code.session;
using YoMail.code.test;

namespace YoMail
{
    [Binding]
    public class TestStepDefinitions
    {
        MainPage mainPage = new MainPage();
        FrameSendMessage message = new FrameSendMessage();
        TestBase testbase= new TestBase();
        string username = "ximena";
        string title = "prueba";

        [Given(@"Dado que el tengo el sitio web")]
        public void GivenDadoQueElTengoElSitioWeb()
        {
            testbase.OpenBrowser();
            
        }

        [When(@"Ingreso mi correo")]
        public void WhenIngresoMiCorreo()
        {
            mainPage.textBoxUsername.SetText(username);
            mainPage.loginButton.Click();
        }

        [Then(@"Se vizualiza el panel de correos")]
        public void ThenSeVizualizaElPanelDeCorreos()
        {
            Assert.IsTrue(Session.Instance().GetBrowser().FindElement(By.XPath("//a[@class='wmlogoclick']")).Displayed, "Error failed init session, please check credentials");
            testbase.CloseBrowser();
        }
    }
}
