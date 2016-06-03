using Xunit;
using EveOnlineMissioningApp.Models;
using System;

namespace MissionCaptureTests
{
    
    public class MissionCaptureTest
    {
        
        [Fact]
        public void TestGetDifference()
        {
            MissionCapture mc = new MissionCapture();

            DateTime start = new DateTime();
            mc.startTime = start;

            DateTime end = new DateTime();
            mc.endTime = end;

            Assert.Equal(start.Subtract(end), mc.getDifference());
        }

    }

}
