using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoMail.code.control
{
    public class TextBox:ControlSelenium
    {
        public TextBox(By Locator) : base(Locator)
        {

        }

        public void SetText(string value)
        {
            FindControl();
            Control.Clear();
            Control.SendKeys(value);
        }
    }
}
