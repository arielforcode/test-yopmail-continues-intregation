using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoMail.code.factorybrowser
{
    public class FactoryBrowser
    {
        public static IBrowser Make(string type)
        {
            IBrowser browser;

            switch (type)
            {
                case "chrome":
                    browser = new Chrome();
                    break;

                default:
                    browser = new Chrome();
                    break;
            }
            return browser;
        }
    }
}
