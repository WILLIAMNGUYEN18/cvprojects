using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace valorantcv
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    using Emgu.CV;
    using Emgu.CV.CvEnum;
    using Emgu.CV.Structure;

    class ParseMP4
    {

        public static void FFMPEGProcessFrames()
        {
            //Directory.CreateDirectory();
        }


        //parse frames based on a given interval
        private static string parseFrames(double interval)
        {

            //ffmpeg -i "C:\valorantcv\rawfootage\g2valorant.mp4" -vf "fps=1/1,showinfo" "C:\valorantcv\outputFrames\frame-%05d.png"

            return "";
        }
        public static void testCanny()
        {
            int cannyThresholdLow = 1;
            int cannyThresholdHigh = 100;

            //C:\valorantcv\outputFrames\frame - 00121.png
            var image = new Image<Bgr, byte>("C:\\valorantcv\\outputFrames\\frame-00121.png");

            var grayScaleImage = image.Convert<Gray, byte>();

            //var blurredImage = grayScaleImage.SmoothGaussian(5, 5, 0, 0);
            var cannyImage = grayScaleImage.Canny(cannyThresholdLow, cannyThresholdHigh);

            cannyImage.Save("C:\\valorantcv\\testBaseCanny\\cannyframe.png");


            var templateImage = new Image<Bgr, byte>("C:\\valorantcv\\templates\\spikeactive.png");

            var templateGrayScaleImage = templateImage.Convert<Gray, byte>();

            var templateCanny = templateGrayScaleImage.Canny(cannyThresholdLow, cannyThresholdHigh);

            templateCanny.Save("C:\\valorantcv\\testBaseCanny\\cannytemplate.png");

        }
        /*
            using (var image = new Image<Bgr, byte>("C:/Projects/DocumentDetection/document.jpg"))
            using (var grayScaleImage = image.Convert<Gray, byte>())
            using (var blurredImage = grayScaleImage.SmoothGaussian(5, 5, 0, 0))

                 //
        // Summary:
        //     Find the edges on this image and marked them in the returned image.
        //
        // Parameters:
        //   thresh:
        //     The threshhold to find initial segments of strong edges
        //
        //   threshLinking:
        //     The threshold used for edge Linking
        //
        // Returns:
        //     The edges found by the Canny edge detector
        [ExposableMethod(Exposable = true, Category = "Gradients, Edges")]
        public Image<Gray, byte> Canny(double thresh, double threshLinking);
         */

    }
}
