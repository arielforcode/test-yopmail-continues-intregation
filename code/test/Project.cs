using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoMail.code.page;

namespace YoMail.code.test
{
    [TestClass]
    public class Project:TestBase
    {
        MainPage mainPage= new MainPage();
        FrameSendMessage message= new FrameSendMessage();
        string username="ximena";
        string title = "prueba";
        [TestMethod]
        public void YopMailTest() {

            mainPage.textBoxUsername.SetText(username);
            mainPage.loginButton.Click();
            Assert.IsTrue(session.Session.Instance().GetBrowser().FindElement(By.XPath("//a[@class='wmlogoclick']")).Displayed, "Error failed init session, please check credentials");
            mainPage.newEmail.Click();

            session.Session.Instance().GetBrowser().SwitchTo().Frame("ifmail");
            message.emailSend.SetText(username + "@yopmail.com");
            message.titleMail.SetText(title);
            message.bodyMail.SetText("Correo de prueba para verificar envios");
            message.sendMail.Click();
            Thread.Sleep(4000);
            Assert.IsTrue(session.Session.Instance().GetBrowser().FindElement(By.Id("msgpopmsg")).Displayed, "Error send message mail");
            session.Session.Instance().GetBrowser().SwitchTo().DefaultContent();
            mainPage.refresh.Click();
            session.Session.Instance().GetBrowser().SwitchTo().Frame("ifinbox");
            Assert.IsTrue(session.Session.Instance().GetBrowser().FindElement(By.XPath("//div[@class='mctn']//div[@class='m']//button//div[text()='" + title + "']")).Displayed, "ERROR recived email failed");

        }
    }
}
