using Aspose.Page.EPS;
using Aspose.Page.EPS.Device;

namespace CSharp.WorkingWithImageConversion
{
    public class SaveImageAsEPS
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithImageConversion();

            // Create default options
            PsSaveOptions options = new PsSaveOptions();

            // Save JPEG image to EPS file
            PsDocument.SaveImageAsEps(dataDir + "input1.jpg", dataDir + "output1.eps", options);

            // ExEnd:1
        }
    }
}
