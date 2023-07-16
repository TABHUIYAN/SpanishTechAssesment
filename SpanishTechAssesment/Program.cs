using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

internal class Program
{
    private static void Main(string[] args)
    {
        //Initializing and launching the Chrome Browser
        IWebDriver driver = new ChromeDriver();
        //maximize the browser
        driver.Manage().Window.Maximize();
        //Launching the URL
        driver.Navigate().GoToUrl("https://www.spanishpoint.ie/");

        // accepting all the cookies 
        Thread.Sleep(2000);
        
        IWebElement acceptCookies = driver.FindElement(By.XPath("//*[@id='wt-cli-accept-btn']"));
        acceptCookies.Click();

        // selecting and expanding Solution and Services
        driver.FindElement(By.Id("menu-item-30711")).Click();
        Thread.Sleep(2000);
        
        
        Actions action = new Actions(driver);
        IWebElement modernWork = driver.FindElement(By.XPath("//*[@id='menu-item-23119']"));
        action.MoveToElement(modernWork).Perform();
        modernWork.Click();
        //scroll page to the element with javaScript executor
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

        js.ExecuteScript("window.scrollBy(0,500)");
        IWebElement content = driver.FindElement(By.XPath("//li[@class='vc_tta-tab']//span[text()='Content & Collaboration']"));
        content.Click();
        //using static 
        Thread.Sleep(2000);
        // printing header text
        string linkText = content.Text;
        Console.WriteLine("The text of the element: " + linkText);
        //verifying the header text is as expected 
        //handling exception with try and catch
        try
        {
            Assert.IsTrue(linkText.Contains("Content & Collaboration"));
            Console.WriteLine("Content & Collaboration");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
       //verifying the paragraph starting with the provided text 
        string assertText = "Spanish Point customers tell us that people are their most important asset.";
        IWebElement ele = driver.FindElement(By.XPath("//p[contains(text(),'Spanish Point customers tell us that people are th')]"));
        try
        {
            Assert.IsTrue(ele.Text.StartsWith(assertText));
            Console.WriteLine(assertText);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        //driver.Quit();


    }
}