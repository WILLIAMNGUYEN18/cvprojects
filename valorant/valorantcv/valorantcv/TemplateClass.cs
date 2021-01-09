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
    public enum Templates
    {
        SpikePlant,
    }
    class TemplateClass
    {
        
        public string templatePath;
        public Rectangle interestRegion;
        public int threshold;
        Templates template;

        public TemplateClass(string tempPath, Rectangle region, int thresh, Templates temp)
        {
            this.templatePath = tempPath;
            this.interestRegion = region;
            this.threshold = thresh;
            this.template = temp;
        }
    }
}
