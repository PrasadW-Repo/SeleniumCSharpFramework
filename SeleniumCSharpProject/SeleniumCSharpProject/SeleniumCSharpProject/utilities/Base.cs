using System;
using System.IO;
using System.Threading;
using AventStack.ExtentReports;
using AventStack.ExtentReports.MarkupUtils;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V140.Storage;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace SeleniumCSharpProject.utilities
{

    public class Base
    {
       
        string WORKING_DIR = Directory.GetParent(Environment.CurrentDirectory)?.Parent?.Parent?.FullName ?? throw new NullReferenceException("Unable to determine working directory.");
        // Thread-local storage for IWebDriver per test thread 
        private static readonly ThreadLocal<IWebDriver?> _tdriver = new ThreadLocal<IWebDriver?>();

        // Protected getter for subclasses to access the driver safely
        protected IWebDriver Driver => _tdriver.Value ?? throw new NullReferenceException("WebDriver is not initialized for the current thread. Ensure StartBrowser() has run.");
        public static TestConfig SystemConfig => _systemConfig ?? throw new NullReferenceException("SystemConfig is not loaded. Ensure SetConfig() has been called.");

        public static BaseConfig Config => _config ?? throw new NullReferenceException("Config is not loaded. Ensure SetConfig() has been called.");

        // Backing fields for lazy-loaded configs
        private static TestConfig? _systemConfig;
        private static BaseConfig? _config;

        ExtentReports extent;
        public ExtentTest test;

       // [OneTimeSetUp]
        public void OneTimeSetup()       {


            EnsureConfigLoaded();
            extent = new ExtentReports();
            var reporter = new ExtentSparkReporter($"{WORKING_DIR}\\ExtentReport.html");
            reporter.Config.ReportName = "Automation Test Report";
            reporter.Config.DocumentTitle = "Test Results";


            extent.AttachReporter(reporter);

            extent.AddSystemInfo("Environment", SystemConfig.env);
            extent.AddSystemInfo("Browser", Config.browser);

        }
         




      //  [SetUp]
        public void StartBrowser()
        {
             test = extent.CreateTest(TestContext.CurrentContext.Test.Name);    
            // Ensure configuration is present before starting the browser
            

            string borwserName = Config.browser ?? "chrome";

            try
            {
                switch (borwserName.ToLowerInvariant())
                {
                    case "firefox":
                        _tdriver.Value = new FirefoxDriver();
                        break;
                    case "edge":
                        _tdriver.Value = new EdgeDriver();
                        break;
                    case "chrome":
                    default:
                        _tdriver.Value = new ChromeDriver();
                        break;
                }

                // configure driver via protected getter
                _tdriver.Value.Manage().Window.Maximize();
                _tdriver.Value.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            }
            catch (Exception ex)
            {
                _tdriver.Value = null;
                throw new InvalidOperationException("Failed to start WebDriver for the current thread.", ex);
            }
        }

       // [TearDown]
        public void TearDownBrowser()
        {
            try
            {   var status = TestContext.CurrentContext.Result.Outcome.Status;
                DateTime time = DateTime.Now;
                String fileName = $"{WORKING_DIR}\\screenshots\\Screenshot_" + time.ToString("h_mm_ss") + ".png";
                
                if (status != TestStatus.Failed)
                {
                    ;
                   // test.AddScreenCaptureFromPath(fileName);
                    test.Log(Status.Fail, "Test failed", Utils.takeScreenshot(Driver, fileName));
                    //File.Delete(fileName);
                }
                extent.Flush();
                _tdriver.Value?.Quit();
            }
            catch
            {
                // ignore quit exceptions
            }
            finally
            {
                _tdriver.Value = null;
            }
        }

        // Public so tests running in discovery (static providers) can call it explicitly if needed
        public static void SetConfig()
        {            

            //Load system config
            _systemConfig = Utils.ReadJSON("appsettings.json").ToObject<TestConfig>() ?? throw new  NullReferenceException();

            // Choose test data file based on env
            string dataFile = string.Equals(_systemConfig.env, "prod", StringComparison.OrdinalIgnoreCase)
                ? "TestDataPROD.json"
                : "TestDataINTG.json";

            //Load test data config

            _config = Utils.ReadJSON(dataFile).ToObject<BaseConfig>() ?? throw new NullReferenceException();
        }

        private static void EnsureConfigLoaded()
        {
            if (_systemConfig != null && _config != null) return;

            try
            {
                SetConfig();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to load configuration. Verify appsettings.json and test data files.", ex);
            }
        }
    }
}
