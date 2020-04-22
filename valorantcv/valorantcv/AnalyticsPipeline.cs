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

namespace valorantcv
{
    class AnalyticsPipeline
    {

        public static void RunMP4Pipeline(string fileName)
        {

            //Creating Timeline
            List<TimelineInstance> result = new List<TimelineInstance>();


            //assumewe are doing 
            //TODO: incorporate MP4 parsing with FFMPEG

            //will skip MP4 parsing and provide processed folder path instead
            //need to loop through folder correctly
            string[] fullFilePaths = Directory.GetFiles(fileName);


            //TODO: Template Creation
            //Manually creating spike template atm
            TemplateClass spikeTemplate = new TemplateClass("C:\\valorantcv\\templates\\spikeactive.png", new Rectangle(900,0,112,100), 20, Templates.SpikePlant);

            List<TemplateClass> templates = new List<TemplateClass>();
            templates.Add(spikeTemplate);


            //for each file
            foreach (string files in fullFilePaths)
            {
                //in future could choose the template types as a list/set as a foreach
                //for relevant templatetype

                result.Add(processFrame(files, templates));

            }






        }

        static TimelineInstance processFrame(string file, List<TemplateClass> tempClasses) 
        {
            foreach (TemplateClass T in tempClasses)
            {
                //
                Console.WriteLine(file);
                //
                //Need an additional processframe logic method

                //is there a cleaner, more programmatic way of handling all
                //the different template classes cases and their
                //appropriate response to the 
            }
            return null;
        }




    }
}
