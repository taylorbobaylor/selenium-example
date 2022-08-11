using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

while (true)
{
    Console.WriteLine("Run selenium automation? ");
    var res = Console.ReadLine();

    if (res?.ToLowerInvariant() == "y" || res?.ToLowerInvariant() == "yes")
        StartSeleniumAutomation();
    else
        return;
}


async Task StartSeleniumAutomation()
{
    var driver = new ChromeDriver(Directory.GetCurrentDirectory());

    driver.Manage().Window.Maximize();
    driver.Url = "https://www.google.com";
    driver.Navigate();

    var searchBox = driver.FindElement(By.Name("q"));
    searchBox.SendKeys("how to run selenium tests in c#");
    searchBox.Submit();
    
    await Task.Delay(TimeSpan.FromSeconds(3));
    driver.Quit();
}