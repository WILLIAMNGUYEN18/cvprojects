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


    }
}
