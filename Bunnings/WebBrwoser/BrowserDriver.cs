﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Bunnings.WebBrowser
{
    public class BrowserDriver : IDisposable
        {
            private readonly Lazy<IWebDriver> _currentWebDriverLazy;
            private bool _isDisposed;

            public BrowserDriver()
            {
                _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);
            }

            /// <summary>
            /// The Selenium IWebDriver instance
            /// </summary>
            public IWebDriver Current => _currentWebDriverLazy.Value;

            /// <summary>
            /// Creates the Selenium web driver (opens a browser)
            /// </summary>
            /// <returns></returns>
            private IWebDriver CreateWebDriver()
            {
                //We use the Chrome browser
                var chromeDriverService = ChromeDriverService.CreateDefaultService(@"resources");
                var chromeOptions = new ChromeOptions();
                var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);
                chromeDriver.Manage().Window.Maximize();
                return chromeDriver;
            }

            /// <summary>
            /// Disposes the Selenium web driver (closing the browser) after the Scenario completed
            /// </summary>
            public void Dispose()
            {
                if (_isDisposed)
                {
                    return;
                }

                if (_currentWebDriverLazy.IsValueCreated)
                {
                    Current.Quit();
                }

                _isDisposed = true;
            }
        }
    }

