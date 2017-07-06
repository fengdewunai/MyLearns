﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestLearn;


namespace UnitTest
{
    /// <summary>
    /// ControllerTest 的摘要说明
    /// </summary>
    [TestClass]
    public class ControllerTest
    {
        
        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性:
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        Controller c = new Controller();

        [TestMethod]
        public void AddTest()
        {
            int a = 1;
            int b = 2;
            Assert.AreEqual(c.add(a,b),3);
        }

        [TestMethod()]
        public void SubtractionTest()
        {
            Assert.AreEqual(c.Subtraction(2,1),1);
        }
    }
}
