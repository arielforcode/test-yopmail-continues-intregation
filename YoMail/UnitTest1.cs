using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace YoMail
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;
        string name = "prueba";
        string titleMail = "prueba";

        [TestInitialize]
        public void OpenBrowser()
        {
            Console.WriteLine("Iniciando Navegador");
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            driver = new ChromeDriver(path + "/driver/chromedriver.exe");
            driver.Navigate().GoToUrl("https://yopmail.com/es/");
        }

        [TestCleanup]
        public void CloseBrowser()
        {
            Console.WriteLine("Cierre Navegador");
            driver.Quit();
        }
        [TestMethod]
        public void TestIFrames()
        {
            driver.FindElement(By.Id("login")).SendKeys(name);
            driver.FindElement(By.Id("refreshbut")).Click();
            Assert.IsTrue(driver.FindElement(By.XPath("//a[@class=\"wmlogoclick\"]")).Displayed, "Error failed init session, please check credentials");
            driver.FindElement(By.Id("newmail")).Click();
            Thread.Sleep(3000);
            driver.SwitchTo().Frame("ifmail");
            driver.FindElement(By.Id("msgto")).SendKeys(name + "@yopmail.com");
            driver.FindElement(By.Id("msgsubject")).SendKeys(titleMail);
            driver.FindElement(By.Id("msgbody")).SendKeys("Esta es la prueba del mensaje");
            driver.FindElement(By.Id("msgsend")).Click();
            Thread.Sleep(6000);
            Assert.IsTrue(driver.FindElement(By.Id("msgpopmsg")).Displayed, "Error send message mail");
            driver.SwitchTo().DefaultContent();
            driver.FindElement(By.Id("refresh")).Click();
            Thread.Sleep(6000);
            driver.SwitchTo().Frame("ifinbox");
            Assert.IsTrue(driver.FindElement(By.XPath("//div[@class='mctn']//div[@class='m']//button//div[text()='" + titleMail + "']")).Displayed, "ERROR recived email failed");
            Console.WriteLine("recibido");
        }
    }
}