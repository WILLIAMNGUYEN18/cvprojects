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
            string spikeTestDefault = "C:\\valorantcv\\testBaseCanny\\spikeTest";

            string spikeTemplate = "C:\\valorantcv\\templates\\spikeactive.png";
            Rectangle spikeRect = new Rectangle(
                (900),
                (0),
                (112),
                (100)
             );

            //output
            string spikeOriginalFrame = "C:\\valorantcv\\outputFrames\\frame-00121.png";
            string spikeOriginalOutput = spikeTestDefault + parseFrameNumber(spikeOriginalFrame) + ".png";
            ParseMP4.CannyMatchFrame(spikeOriginalFrame, spikeTemplate,spikeRect, 20, spikeOriginalOutput);

            string spikeRedCountdownFrame = "C:\\valorantcv\\outputFrames\\frame-00052.png";
            string spikeRedOutput = spikeTestDefault + parseFrameNumber(spikeRedCountdownFrame) + ".png";
            ParseMP4.CannyMatchFrame(spikeRedCountdownFrame,spikeTemplate, spikeRect, 20, spikeRedOutput);

            string spikeDarkFrame = "C:\\valorantcv\\outputFrames\\frame-00124.png";
            string spikeDarkOutput = spikeTestDefault + parseFrameNumber(spikeDarkFrame) + ".png";
            ParseMP4.CannyMatchFrame(spikeDarkFrame, spikeTemplate, spikeRect, 20, spikeDarkOutput);

            string spikeMixedFrame = "C:\\valorantcv\\outputFrames\\frame-00127.png";
            string spikeMixedOutput = spikeTestDefault + parseFrameNumber(spikeMixedFrame) + ".png";
            ParseMP4.CannyMatchFrame(spikeMixedFrame, spikeTemplate, spikeRect, 20, spikeMixedOutput);


            Console.WriteLine("Canny Match Frame Test Complete!");
            //Console.WriteLine(parseFrameNumber(spikeOriginalFrame));
            //Console.WriteLine(parseFrameNumber(spikeRedCountdownFrame));
        }

        static string parseFrameNumber(string framePath) 
        {
            int parsingFrame = framePath.LastIndexOf('-');
            string frame = framePath.Substring(parsingFrame + 1);
            int trimPNG = frame.LastIndexOf('.');
            frame = frame.Remove(trimPNG);

            return frame;
        }
    }
}
