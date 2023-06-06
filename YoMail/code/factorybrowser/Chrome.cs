﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoMail.code.factorybrowser
{
    public class Chrome:IBrowser
    {
        public IWebDriver Create()
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            var driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
            return driver;
        }

    }
}
