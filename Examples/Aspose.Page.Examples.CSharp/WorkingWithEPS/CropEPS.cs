using Aspose.Page;
using Aspose.Page.EPS;
#if ASPOSE_DRAWING
using Aspose.Page.Drawing;
#else
using System.Drawing;
#endif
using System.IO;

namespace CSharp.WorkingWithEPS
{
    public class CropEPS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithEPS();

            //Create an input stream for EPS file
            using (Stream inputEpsStream = new System.IO.FileStream(dataDir + "input.eps", System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                //Initialize PsDocument object with input stream
                PsDocument doc = new PsDocument(inputEpsStream);

                //Get initial bounding box of EPS image
                int [] initialBoundingBox = doc.ExtractEpsBoundingBox();

                //Create an output stream for resized EPS
                using (Stream outputEpsStream = new System.IO.FileStream(dataDir + "output_crop.eps", System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    //Create new bounding box
                    //Bounding box is represented by 4 numbers: x0, y0, x, y, where x0 - left margin, y0 - top margin, x - (x0 + width), y - (y0 + height)
                    float[] newBoundingBox = new float[] { 260, 300, 480, 432 };

                    //Crop EPS image and save to the output stream                    
                    //Croping of image is changing of its bounding box so that new values of bounding box will be within initial bounding box, that is
                    //initialBoundingBox[0] <= newBoundingBox[0] <= initialBoundingBox[2]
                    //initialBoundingBox[1] <= newBoundingBox[1] <= initialBoundingBox[3]
                    //initialBoundingBox[0] <= newBoundingBox[2] <= initialBoundingBox[2]
                    //initialBoundingBox[1] <= newBoundingBox[3] <= initialBoundingBox[3]
                    doc.CropEps(outputEpsStream, newBoundingBox);
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
