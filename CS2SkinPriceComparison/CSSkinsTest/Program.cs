using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace CS2SkinPriceComparison;
public class Program
{
    public static void Main(string[] args)
    {
        UserInput userInput = new UserInput();
        userInput.SelectItemType();
    }
}