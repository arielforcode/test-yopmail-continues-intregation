using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoMail.code.control;

namespace YoMail.code.page
{
    public class MainPage
    {
        public TextBox textBoxUsername = new TextBox(By.Id("login"));
        public Button loginButton = new Button(By.Id("refreshbut"));
        public Button newEmail = new Button(By.Id("newmail"));
        public Button refresh = new Button(By.Id("refresh"));
    }
}
