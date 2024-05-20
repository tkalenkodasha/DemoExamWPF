using ClassLibrary1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;




namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
        
        
        [TestMethod]
        public void InvalidArraySizeTest1()
        {
            Calculations Ap = new Calculations();
            TimeSpan[] startTimes = new TimeSpan[]
            {
            new TimeSpan(9, 0,0 ),
            new TimeSpan(11,10,0)
            };
            int[] durations = new[] { 60, 50, 20 };
            TimeSpan beginWorking = new TimeSpan(8, 0, 0);
            TimeSpan endWorking = new TimeSpan(18, 0, 0);
            int consultationTime = 20;
            Assert.ThrowsException<Exception>(() =>
            {
                Ap.AvailablePeriod(startTimes, durations, beginWorking, endWorking, consultationTime);
            }, "error");

        }

        [TestMethod]
        public void EndLessStartTest2()
        {
            Calculations Ap = new Calculations();
            TimeSpan[] startTimes = new TimeSpan[]
            {
            new TimeSpan(12, 0, 0)
            };
            int[] durations = new[] { 40 };
            TimeSpan beginWorkingTime = new TimeSpan(10, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(8, 0, 0);
            int consultationTime = 20;
            Assert.ThrowsException<Exception>(() =>
            {
                Ap.AvailablePeriod(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            });
        }

        [TestMethod]
        public void ConsultationTimeLessZeroTest3()
        {
            Calculations Ap = new Calculations();
            TimeSpan[] startTimes = new TimeSpan[]
            {
            new TimeSpan(11, 0, 0)
            };
            int[] durations = new[] { 40 };
            TimeSpan beginWorkingTime = new TimeSpan(10, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(8, 0, 0);
            int consultationTime = -20;
            Assert.ThrowsException<Exception>(() =>
            {
                Ap.AvailablePeriod(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            });
        }

        [TestMethod]
        public void EndWorkingTime24hoursTest4()
        {
            Calculations Ap = new Calculations();
            TimeSpan[] startTimes = new TimeSpan[]
            {
            new TimeSpan(12, 0, 0)
            };
            int[] durations = new[] { 40 };
            TimeSpan beginWorkingTime = new TimeSpan(10, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(26, 0, 0);
            int consultationTime = 20;
            Assert.ThrowsException<Exception>(() =>
            {
                Ap.AvailablePeriod(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            });
        }

        [TestMethod]
        public void Test5()
        {
            Calculations Ap = new Calculations();
            TimeSpan[] startTimes = new TimeSpan[]
            {
            new TimeSpan(8, 0, 0)
            };
            int[] durations = new[] { 40 };
            TimeSpan beginWorkingTime = new TimeSpan(10, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 20;
            Assert.ThrowsException<Exception>(() =>
            {
                Ap.AvailablePeriod(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            });
        }


        [TestMethod]
        public void EmptyStartTimesTest6()
        {
            Calculations Ap = new Calculations();
            TimeSpan[] startTimes = new TimeSpan[0];

            int[] durations = new int[0];
            TimeSpan beginWorkingTime = new TimeSpan(10, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 20;
            string[] result = Ap.AvailablePeriod(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            string[] expected = new string[] { "10:00-18:00" };
            CollectionAssert.AreEqual(expected, result, "unsucced");
        }

        [TestMethod]
        public void Test7()
        {
            Calculations Ap = new Calculations();
            TimeSpan[] startTimes = new TimeSpan[]
            {
            new TimeSpan(11, 0, 0),
            new TimeSpan(12, 0, 0),
            new TimeSpan(17, 20, 0),

            };
            int[] durations = new[] { 40, 20, 10 };
            TimeSpan beginWorkingTime = new TimeSpan(10, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 20;
            string[] result = Ap.AvailablePeriod(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            string[] expected = new string[] { "10:00-11:00", "11:40-12:00", "12:20-17:20", "17:30-18:00", };
            CollectionAssert.AreEqual(expected, result, "unsucced");
        }

    }

}

