using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Drawing;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.IO;
using Newtonsoft.Json;
namespace valorantcv
{
    class Insights
    {



        //accept a json file path 
        public static Image<Bgr,byte> visualizeTimeline(string filePath)
        {

            //parse the file path
            List<TimelineInstance> Timeline = JsonConvert.DeserializeObject<List<TimelineInstance>>(File.ReadAllText(filePath));




            //Could use System.Drawing, will try out emgu drawings first

            //since we have frames (and eventually time) tied to each spike event
            //Create an image of set size
            //potentially refactor into its own draw method
            Image<Bgr, byte> Slate = new Image<Bgr, byte>(1920, 200, new Bgr(255,255,255));


            Rectangle outline = new Rectangle
                (
                50,
                75,
                1820,
                50
                );
            Slate.Draw(outline, new Bgr(0,0,0),2);

            Slate.Draw(new Rectangle(51, 76, 1818, 48), new Bgr(Color.LightGray), -1);

            //scale image by list length;
            int scale = Timeline.Count;

            //need increment
            int count = 0;

            foreach (TimelineInstance time in Timeline)
            {
                Bgr timelineColor;
                //handle color of (red for spike, grey for normal)
                if (time.spike)
                {
                    timelineColor = new Bgr(Color.Red);
                    double instanceSize = (outline.Width / scale);
                    //int currX = count * (int)Math.Ceiling(instanceSize) + count;
                    int currX = count * (int)instanceSize + count;

                    Console.WriteLine(currX);
                    Console.WriteLine(instanceSize);
                    Console.WriteLine(currX + instanceSize);
                    Console.WriteLine();

                    // starting position is 50
                    // increment is count * imgSize/scale
                    // If thickness is less than 1, the rectangle is filled up
                    Rectangle currentRec = new Rectangle(51 + currX, 77, (int)instanceSize, 46);
                    Slate.Draw(currentRec, timelineColor, -1);
                }

                count++;

            }

            Slate.Save("C:\\valorantcv\\testBaseCanny\\testViz.png");

            //for each index, in the timeline, draw a box
            //create an event list that we care about
            //loop across all the frames


            //for spike plants, since it's a timespan, we can just make it red in that section
            //draw a different color for each element?
            //shitty, but probably effective




            return null;
        }


    }
}
