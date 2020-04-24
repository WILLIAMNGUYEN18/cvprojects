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

            //scale image by list length;
            int scale = Timeline.Count;


            //Could use System.Drawing, will try out emgu drawings first

            //since we have frames (and eventually time) tied to each spike event
            //Create an image of set size
            //potentially refactor into its own draw method
            Image<Bgr, byte> Slate = new Image<Bgr, byte>(500, 200, new Bgr(255,255,255));
            
            
            
            
            //create an event list that we care about
            //loop across all the frames


            //for spike plants, since it's a timespan, we can just make it red in that section
            //draw a different color for each element?
            //shitty, but probably effective




            return null;
        }


    }
}
