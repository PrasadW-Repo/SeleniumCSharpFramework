using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using NUnit.Framework;
using NUnit.Framework.Internal;
using SeleniumCSharpProject.utilities;

namespace SeleniumCSharpProject;


public class Test1 : Base
{
    
    [Test]
    public void TestCase1()
    {
        Driver.Url = Base.Config.url;
       test.Log(Status.Fail,$"Entered url {Base.Config.url}");
       
    }



}
