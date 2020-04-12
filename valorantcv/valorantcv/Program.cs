using System;
using System.Collections.Generic;
using System.Drawing;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;

namespace valorantcv
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Basic Canny Test Starting...");
            ParseMP4.testCanny();
            Console.WriteLine("Basic Canny Test Complete!");

            Console.WriteLine("Canny Match Frame Test Starting...");
            //prep
            string spikeOriginalFrame = "C:\\valorantcv\\outputFrames\\frame-00121.png";
            string spikeTemplate = "C:\\valorantcv\\templates\\spikeactive.png";
            Rectangle spikeRect = new Rectangle(
                (900),
                (0),
                (112),
                (100)
             );

            string spikeOriginalOutput = "C:\\valorantcv\\testBaseCanny\\spikeTest.png";

            //Output
            ParseMP4.CannyMatchFrame(spikeOriginalFrame, spikeTemplate,spikeRect, 50, spikeOriginalOutput, true);


            string spikeDifferentFrame ="";

            Console.WriteLine("Canny Match Frame Test Complete!");
        }
    }
}
