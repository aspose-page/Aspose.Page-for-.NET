using Aspose.Page;
using Aspose.Page.EPS;
using Aspose.Page.EPS.Device;
using Aspose.Page.EPS.XMP;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharp.WorkingWithEPS
{
    public class ResizeEPS
    {
        public static void RunPoints()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithEPS();

            //Create an input stream for EPS file
            using (Stream inputEpsStream = new System.IO.FileStream(dataDir + "input.eps", System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                //Initialize PsDocument object with input stream
                PsDocument doc = new PsDocument(inputEpsStream);

                //Get size of EPS image
                Size oldSize = doc.ExtractEpsSize();

                //Create an output stream for resized EPS
                using (Stream outputEpsStream = new System.IO.FileStream(dataDir + "output_resize_points.eps", System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    //Increase EPS size in 2 times and save to the output stream
                    doc.ResizeEps(outputEpsStream, new SizeF(oldSize.Width * 2, oldSize.Height * 2), Units.Points);
                }
            }
            // ExEnd:1
        }

        public static void RunInches()
        {
            // ExStart:2
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithEPS();

            //Create an input stream for EPS file
            using (Stream inputEpsStream = new System.IO.FileStream(dataDir + "input.eps", System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                //Initialize PsDocument object with input stream
                PsDocument doc = new PsDocument(inputEpsStream);

                //Get size of EPS image
                Size oldSize = doc.ExtractEpsSize();

                //Create an output stream for resized EPS
                using (Stream outputEpsStream = new System.IO.FileStream(dataDir + "output_resize_inches.eps", System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    //Save EPS to the output stream with new size assigned in inches
                    doc.ResizeEps(outputEpsStream, new SizeF(5.791f, 3.625f), Units.Inches);
                }
            }
            // ExEnd:2
        }

        public static void RunMms()
        {
            // ExStart:3
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithEPS();

            //Create an input stream for EPS file
            using (Stream inputEpsStream = new System.IO.FileStream(dataDir + "input.eps", System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                //Initialize PsDocument object with input stream
                PsDocument doc = new PsDocument(inputEpsStream);

                //Get size of EPS image
                Size oldSize = doc.ExtractEpsSize();

                //Create an output stream for resized EPS
                using (Stream outputEpsStream = new System.IO.FileStream(dataDir + "output_resize_mms.eps", System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    //Save EPS to the output stream with new size assigned in millimeters
                    doc.ResizeEps(outputEpsStream, new SizeF(196, 123), Units.Millimeters);
                }
            }
            // ExEnd:3
        }

        public static void RunPercents()
        {
            // ExStart:3
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithEPS();

            //Create an input stream for EPS file
            using (Stream inputEpsStream = new System.IO.FileStream(dataDir + "input.eps", System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                //Initialize PsDocument object with input stream
                PsDocument doc = new PsDocument(inputEpsStream);

                //Get size of EPS image
                Size oldSize = doc.ExtractEpsSize();

                //Create an output stream for resized EPS
                using (Stream outputEpsStream = new System.IO.FileStream(dataDir + "output_resize_percents.eps", System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    //Save EPS to the output stream with new size assigned in percents
                    doc.ResizeEps(outputEpsStream, new SizeF(200, 200), Units.Percents);
                }
            }
            // ExEnd:3
        }
    }
}
