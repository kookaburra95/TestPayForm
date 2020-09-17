using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestPayForm
{
    internal class Tests
    {
        internal static void PayFormTest()
        {
            using (var browser = new ChromeDriver())
            {
                try
                {
                    browser.Manage().Window.Maximize();
                    browser.Navigate().GoToUrl("https://www.mts.by/finance/services-pay/card/");

                    //Ввод номера телефона
                    IWebElement phoneInput = browser.FindElement(By.CssSelector("#phone"));
                    phoneInput.SendKeys("336446625");

                    //Ввод суммы
                    IWebElement sumInput = browser.FindElement(By.CssSelector("#total_rub"));
                    sumInput.SendKeys("1");

                    //Выбор банка
                    IWebElement orderTypeInput = browser.FindElement(By.CssSelector("#test4"));
                    orderTypeInput.Click();

                    //Подтверждение данных (Продолжить)
                    IWebElement paySubmitButton = browser.FindElement(By.CssSelector("#pay_submit"));
                    paySubmitButton.Click();


                    //Ожидание фрейма
                    browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

                    //Выбор фрейма
                    browser.SwitchTo().Frame(browser.FindElement(By.CssSelector("#iframeDodrobyt")));

                    //Ввод номера карты
                    IWebElement cardNumberInput = browser.FindElement(By.CssSelector("#cc_pan"));
                    cardNumberInput.SendKeys("1111111111111111111");


                    Thread.Sleep(7000); //для наглядности

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nPayFormOk\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.WriteLine("\nPayFormError\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
