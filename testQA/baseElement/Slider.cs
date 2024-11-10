using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testQA.baseElement;
using testQA.Utils;

namespace testQA.baseElement
{
    public class Slider:BaseElement
    {
        public Slider(By locator, string name) : base(locator, name) { }
    }
}
