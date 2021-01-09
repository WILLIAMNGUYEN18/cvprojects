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

            //output result as a JSON
            //JsonConvert.Deserialize
            File.WriteAllText("C:\\valorantcv\\testBaseCanny\\testOutput.json", JsonConvert.SerializeObject(result));




        }




        //is there a cleaner, more programmatic way of handling all
        //the different template classes cases and their
        //appropriate response to the 


        //Need to include templates so we can process 
        //all the changes we want for each timeline instance

        static TimelineInstance processFrame(string file, List<TemplateClass> tempClasses) 
        {
            Console.WriteLine(file);
            TimelineInstance result = new TimelineInstance();
            string frame = parseFrameNumber(file);
            result.frame = Int32.Parse(frame);
            foreach (TemplateClass T in tempClasses)
            {
                result.spike = AnalyticsMethods.CannyMatchFrame(file,T.templatePath, T.interestRegion, T.threshold);
                //Need an additional processframe logic method

            }
            return result;
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
