using AngleSharp.Text;
using AventStack.ExtentReports.Reporter.Config;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumCSharpProject.utilities;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace SeleniumCSharpProject;

public class NUnitTestItem1 : Base
{



    [Test]
    public void Test1()
    {
        IAlert alert = Driver.SwitchTo().Alert();
        Console.WriteLine(alert.Text);

        IWebDriver driver = new ChromeDriver();

        IList<string> windowHandles = driver.WindowHandles;
        driver.SwitchTo().Window(windowHandles[0]);

        IJavaScriptExecutor jExecute = (IJavaScriptExecutor)driver;
        jExecute.ExecuteScript("arguments[0].click;", driver.FindElement(By.Name("")));

    }
    public int fibn(int n)
    {
        if (n <= 1)
        {

            return n;
        }
        return (fibn(n - 1) + fibn(n - 2));


    }
    [Test]
    public void findrepeatedcharacter()
    {

        string sample = "blabba";

        List<string> abc = new List<string>();
        for (int i = 0; i < sample.Length; i++)
        {
            int temp = 0;
            for (int j = 0; j < sample.Length; j++)
            {
                string a = sample.Substring(i, 1);
                string b = sample.Substring(j, 1);
                if (a == b)
                {
                    temp++;
                    if (temp >= 2)
                    {
                        if (!(abc.Contains(b)))
                        {
                            abc.Add(b);

                        }
                    }
                }
            }

        }
        foreach (string str in abc)
        {
            Console.WriteLine(str);
        }
        //string temp = sample;
        //var chArr = temp.ToCharArray();
        //for (int i = 0; i < chArr.Length; i++)
        //{
        //    int tem = 0;
        //    for(int j = 0; i < chArr.Length; i++)
        //    {
        //        if (chArr[i] == chArr[j])
        //        {

        //            tem++;
        //            if (tem == 2) Console.WriteLine(chArr[i]);
        //        }


        //    }
        //}
    }
    [Test]
    public void hospitalpractice1()
    {


        int[,] A = new int[,]
        {
            { 16, 2, 5, 4, 1 },  // Hospital 0
              {   2, 1, 3, 2, 1 },  // Hospital 1
             { 3, 3, 2, 16, 3 }   // Hospital 2
    } 
        ;

        HashSet<int> set = new HashSet<int>();
        HashSet<int> finalSet = new HashSet<int>();
        for (int i=0; i < A.GetLength(0); i++)
        {
            HashSet<int> internalSet = new HashSet<int>();
            for (int j=0; j<A.GetLength(1); j++)
            {                

           
                    internalSet.Add(A[i, j]);
                

            }

           foreach(int item in internalSet)
            {

                if (!set.Contains(item))
                {
                    set.Add(item);
                }
                else
                { finalSet.Add(item); }
            }

        }

        foreach (var item in finalSet)
        {
            Console.WriteLine(item);
        }

    }

    [Test]

    public void hospitalpractice2()
    {

        int[,] A = new int[,]
         {
            { 16, 2, 5, 4, 1 },  // Hospital 0
              {   2, 1, 3, 2, 1 },  // Hospital 1
             { 3, 3, 2, 16, 3 }   // Hospital 2
         };
        int N = A.GetLength(0);
        int M = A.GetLength(1);

        Dictionary<int,HashSet<int>> docId = new  Dictionary<int,HashSet<int>>();
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                if (!(docId.ContainsKey(A[i,j])))
                {
                    docId.Add(A[i,j], new HashSet<int>());
                }
                docId[A[i,j]].Add(i);
            }

        }
        int count = 0;

        foreach (KeyValuePair<int,HashSet<int>> kvp in docId)
        {
            Console.WriteLine($"key :{kvp.Key} and Value: {kvp.Value.Count}");
            if (kvp.Value.Count > 1)
            {
                count++;

            }
        }

        Console.WriteLine(count);
        
    }

    [Test]
    public void RevwerseString()

    {
        //string text = "aappcraskdkn";
        //int count = text.Count(x => x == 'a');
        //Console.WriteLine(count);
        //Dictionary<char, int> dic = new Dictionary<char, int>();

        //foreach (char c in chr)
        //{
        //    if (dic.ContainsKey(c))
        //        dic[c]++;
        //    else
        //        dic.Add(c, 1);
        //}

        //foreach (KeyValuePair<char, int> kvp in dic)
        //    Console.WriteLine($"key is {kvp.Key} and value is {kvp.Value}");

        //List<int> numbers = new List<int>{0,1,2,3,4,5,5,3,4,1,6};
        //var distinctNumbers = numbers.Distinct();
        //foreach (int i in distinctNumbers)
        //    Console.WriteLine(i);

        //ReadOnlyCollection<string> hand =  Driver.WindowHandles;
        //Driver.SwitchTo().DefaultContent();
        //Console.WriteLine(hand[0]); ;


        //string text = "how are you?";
        //string revText = "";

        //string[] strAr = text.Split();

        //foreach (string str in strAr)
        //{
        //    string temp = "";
        //    for(int i = str.Length-1; i>=0; i--)
        //    {
        //        temp += str[i] ;

        //    }
        //    revText += temp + " ";
        //}


        //Console.WriteLine((revText.Trim()));

        //string name = "dasarP";

        //string reverseName = "";

        //for(int i=name.Length-1 ; i>=0; i--)
        //{
        //    reverseName += name[i].ToString();


        //}

        //Console.WriteLine(reverseName);

        //string sent = "who are you?";
        //string[] sentA = sent.Split(" ");
        //string reverseSent= "";


        //foreach (var item in sentA)
        //{
        //    string reverseWord = "";
        //    for (int i=item.Length-1; i>=0; i--)
        //    {
        //        reverseWord += item[i].ToString();

        //    }

        //    reverseSent += reverseWord;
        //}
        //Console.WriteLine(String.Join(" ", sentA.Reverse().ToArray()));


        //string ab = "sdasdasdasd";
        //HashSet<string> x = new HashSet<string>();
        //for(int i = 0; i< ab.Length; i++)
        //{
        //    x.Add(ab[i].ToString());

        //}

        //string bc = "";
        //foreach (string s in x)
        //{
        //    bc += s;
        //}

        //Console.WriteLine(bc);

    }

    public bool IsPllindrom(string str)

    {
        string rev = String.Join("", str.ToCharArray().Reverse());
        if (str == rev)
            return true;
        return false;
    }
    [Test]
    public void LongetstPallindrom()
    {
        string s = "a";
        List<string> abc = new List<string>();
        
        for (int i = 0; i <= s.Length; i++)

        {
            for (int j = 0; j <= s.Length-i; j++)
            {
                string sub = s.Substring(i, j);
             if ((!abc.Contains(sub)) & IsPllindrom(sub))
                    abc.Add(sub);

            }

        }
        string temp = "";
        foreach (string str in abc) 
        {
            if (str.Length>temp.Length)
                temp = str;
                }
        Console.WriteLine(temp);
    }

    [Test]
    public void findrepeatedcharacter1()
    {

        string sample = "blabba";


        Dictionary<char, int> rc = new Dictionary<char, int>();
        foreach(char chr in sample)
        {
            if (rc.ContainsKey(chr))
            {
                rc[chr]++;
            }
            else
            {
                rc.Add(chr, 1);
            }

        }
       
        foreach(KeyValuePair<char, int> keyValuePair in rc)
        {
            
            Console.WriteLine($"key: {keyValuePair.Key} value: {keyValuePair.Value}");
        }
    }
    [Test]
    public void Transactions()
    {
        
        Driver.Navigate().Back();
        ReadOnlyCollection<string> w = Driver.WindowHandles;
        
        Console.WriteLine(w[0]);
        calculations("AB",new int[]{3,3});
      
    }
    [Test]
    public void LengthOfLongestSubstring()
    {
        string s = "abcabcbb";
     //   List<string> subs = new List<string>();
        //subs.Add(s[0].ToString());
        string sub = "";
        
        for (int i = 0; i < s.Length; i++)
        {
            string inte = "";
            for (int k = i; k < s.Length; k++)
            {
                
                if (!(inte.Contains(s[k])))
                {
                    inte += s[k].ToString();

                }
                else
                {
                    sub += inte+ ",";
                    break;

                }
            }
            sub += inte + ",";

        }

        Console.WriteLine(sub);
        string temp = "";
        string[] subs = sub.Split(",");
        for (int h = 0; h < subs.Length; h++)
        {
            if (temp.Length < subs[h].Length)
                temp = subs[h];
        }



    }

    public void calculations(string users, int[] transactions)
    {

        int A = 0;
        int B = 0;
        int BB = 0;
        int AA = 0;
        for (int i = 0; i < users.Length; i++)
        {
            if (users[i] == 'B')
            {
                if((A-transactions[i])>0)
                {
                    A -= transactions[i];
                }
                else
                {
                    
                    AA += Math.Abs(A - transactions[i]);
                    A = 0;
                }
                    B += transactions[i];

            }
            else
            {
                if ((B - transactions[i]) > 0)
                {
                    B -= transactions[i];
                }
                else
                {
                   
                    BB += Math.Abs(B - transactions[i]);
                    B = 0;
                }
                A += transactions[i];

            }


        }
        Console.WriteLine($"A = {Math.Abs(AA)} and B = {Math.Abs(BB)}");
    }
}