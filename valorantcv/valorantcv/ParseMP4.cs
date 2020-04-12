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

        //given frame image, template, region of interest, and outputfullPath
        //
        public static bool CannyMatchFrame(string framePath, string templatePath, Rectangle interestRegion, int thresh, string debugPath = "")
        {
            //Unsure how I want to deal with low and high threshold
            //may not matter too much between different matches
            int cannyThresholdLow = 0;
            int cannyThresholdHigh = 125;

            //Canny Image Creation
            var frameImage = new Image<Bgr, byte>(framePath);
            var grayScaleImage = frameImage.Convert<Gray, byte>();
            grayScaleImage.ROI = interestRegion;
            var grayScaleROI = grayScaleImage.Copy();
            var cannyFrameROI = grayScaleROI.Canny(cannyThresholdLow, cannyThresholdHigh);

            var templateImage = new Image<Bgr, byte>(templatePath);
            var templateGrayScaleImage = templateImage.Convert<Gray, byte>();
            var templateCanny = templateGrayScaleImage.Canny(cannyThresholdLow, cannyThresholdHigh);

            //Template Matching
            Image<Gray, float> Score = cannyFrameROI.MatchTemplate(templateCanny, Emgu.CV.CvEnum.TemplateMatchingType.CcorrNormed);
            double min = 0, max = 0;
            Point minP = new Point(0, 0), maxP = new Point(0, 0);
            CvInvoke.MinMaxLoc(Score, ref min, ref max, ref minP, ref maxP);
            //int legibleScore = (int)((1.0 - min) * 100);
            int legibleScore = (int)(max * 100);

            if (debugPath.Length != 0)
            {
                int boxWidth = templateImage.Width;
                int boxHeight = templateImage.Height;

                //location is a combination of interestregion + minloc with size of template
                Rectangle Box = new Rectangle(interestRegion.Left + minP.X, interestRegion.Top + minP.Y, boxWidth, boxHeight);

                Console.WriteLine(framePath);
                Console.WriteLine("Score: " + legibleScore);
                Console.WriteLine("Threshold: " + thresh);
                Console.WriteLine(Box.ToString());
                Console.WriteLine("Template Match: " + (legibleScore > thresh));
                //templateCanny.Save(deb);
                cannyFrameROI.Save(debugPath);

                //red box color
                Bgr boxColor = new Bgr(0, 0, 255);

                frameImage.Draw(Box, boxColor, 2);

                //need to somehow save
                //frameImage.Save(debugPath);
            }




            //may need to dispose of everything
            frameImage.Dispose();
            grayScaleImage.Dispose();
            grayScaleROI.Dispose();
            cannyFrameROI.Dispose();
            templateImage.Dispose();
            templateGrayScaleImage.Dispose();
            templateCanny.Dispose();

            return legibleScore > thresh;

        }

        public static void testCanny()
        {
            int cannyThresholdLow = 20;
            int cannyThresholdHigh = 90;

            //C:\valorantcv\outputFrames\frame - 00121.png template
            //C:\valorantcv\outputFrames\frame
            var image = new Image<Bgr, byte>("C:\\valorantcv\\outputFrames\\frame-00121.png");

            var grayScaleImage = image.Convert<Gray, byte>();

            //var blurredImage = grayScaleImage.SmoothGaussian(5, 5, 0, 0);
            var cannyImage = grayScaleImage.Canny(cannyThresholdLow, cannyThresholdHigh);

            cannyImage.Save("C:\\valorantcv\\testBaseCanny\\cannyframe.png");


            var templateImage = new Image<Bgr, byte>("C:\\valorantcv\\templates\\spikeactive.png");

            var templateGrayScaleImage = templateImage.Convert<Gray, byte>();

            var templateCanny = templateGrayScaleImage.Canny(cannyThresholdLow, cannyThresholdHigh);

            templateCanny.Save("C:\\valorantcv\\testBaseCanny\\cannytemplate.png");

            //next step is to make a smaller image from the gray scale of the relevant area
            //

            //910 x 10
            //102 x 90

            //so we want a slightly larger area of detection

            Rectangle interestregion = new Rectangle(
                (900),
                (0),
                (112),
                (100)
             );

            //we need a bitmap source
            //Image<Bgr, byte> 

            //convert bitmap to 

            grayScaleImage.ROI = interestregion;
            Image<Gray, byte> imageROI = grayScaleImage.Copy();

            Image<Gray, byte> cannyImageROI = imageROI.Canny(cannyThresholdLow, cannyThresholdHigh);

            cannyImageROI.Save("C:\\valorantcv\\testBaseCanny\\cannyimageroi.png");


            //TODO: Refactor into a method to output info. Make this a debug mode type of thing probably (don't need most of this besides score)
            //values seem fine. Can get away with a lot it seems
            //Actually, need to test with a shitty example.
            Console.WriteLine("sqdifftest.png");
            Image<Gray, float> Score1 = cannyImageROI.MatchTemplate(templateCanny, Emgu.CV.CvEnum.TemplateMatchingType.Sqdiff);
            Score1.Save("C:\\valorantcv\\testBaseCanny\\sqdifftest.png");

            double min = 0, max = 0;
            Point minP = new Point(0, 0), maxP = new Point(0, 0);
            //Let's see what minmaxloc can do
            CvInvoke.MinMaxLoc(Score1,ref min,ref max,ref minP, ref maxP);
            Console.WriteLine(min);
            //showing x = 10, y = 10, which matches our shift in template ROI.
            Console.WriteLine(max);
            Console.WriteLine(minP);
            Console.WriteLine(maxP);

            // for TM_SQDIFF && TM_SQDIFF_NORMED, need to set to minLoc
            // rest are maxLoc
            // Unsure what output images are

            //score values are normalized between 1 and 0 (lowest being best). I think I can stick with this one
            Console.WriteLine("sqdiffnormtest.png");
            Image<Gray, float> Score2 = cannyImageROI.MatchTemplate(templateCanny, Emgu.CV.CvEnum.TemplateMatchingType.SqdiffNormed);
            Score2.Save("C:\\valorantcv\\testBaseCanny\\sqdiffnormtest.png");
            CvInvoke.MinMaxLoc(Score2, ref min, ref max, ref minP, ref maxP);
            Console.WriteLine(min);
            //showing x = 10, y = 10, which matches our shift in template ROI.
            Console.WriteLine(max);
            Console.WriteLine(minP);
            Console.WriteLine(maxP);


            //TODO: Test these other methods
            //cross correlation
            Image<Gray, float> Score3 = cannyImageROI.MatchTemplate(templateCanny, Emgu.CV.CvEnum.TemplateMatchingType.Ccorr);
            Score3.Save("C:\\valorantcv\\testBaseCanny\\ccorrtest.png");

            Image<Gray, float> Score4 = cannyImageROI.MatchTemplate(templateCanny, Emgu.CV.CvEnum.TemplateMatchingType.CcorrNormed);
            Score4.Save("C:\\valorantcv\\testBaseCanny\\ccornormtest.png");

            Image<Gray, float> Score5 = cannyImageROI.MatchTemplate(templateCanny, Emgu.CV.CvEnum.TemplateMatchingType.Ccoeff);
            Score5.Save("C:\\valorantcv\\testBaseCanny\\ccoefftest.png");

            Image<Gray, float> Score6 = cannyImageROI.MatchTemplate(templateCanny, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed);
            Score6.Save("C:\\valorantcv\\testBaseCanny\\ccoeffnormtest.png");



            //let's put out an image with the box itself
            //we have the coords of min location and min location score
            //we also have the size of the interest region
            //we have original image
            //Let's draw a box over it
            int boxWidth = templateImage.Width;
            int boxHeight = templateImage.Height;

            //location is a combination of interestregion + minloc with size of template
            Rectangle Box = new Rectangle(interestregion.Left + minP.X, interestregion.Top + minP.Y, boxWidth, boxHeight);


            Image<Bgr, byte> boxFrame = image.Copy();

            //redbox
            Bgr boxColor = new Bgr(0,0,255);

            boxFrame.Draw(Box, boxColor, 2);

            boxFrame.Save("C:\\valorantcv\\testBaseCanny\\boundBox.png");

        }


        //



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
