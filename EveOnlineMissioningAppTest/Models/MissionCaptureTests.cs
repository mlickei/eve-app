using Xunit;
using EveOnlineMissioningApp.Models;
using System;

namespace MissionCaptureTests
{
    
    public class MissionCaptureTest
    {
        
        [Fact]
        public void TestGetTimeDifference()
        {
            MissionCapture mc = new MissionCapture();

            DateTime start = new DateTime();
            mc.startTime = start;

            DateTime end = new DateTime();
            mc.endTime = end;

            Assert.Equal(start.Subtract(end), mc.getTimeDifference());
        }

        [Fact]
        public void TestCalculateProfit()
        {
            MissionCapture mc = new MissionCapture();

            float income = 1000000;
            float expenses = 100000;
            float profit = income - expenses;

            mc.income = income;
            mc.expenses = expenses;
            float calcProfit = mc.calculateProfit();

            Assert.Equal(calcProfit, profit);
        }

    }

}
