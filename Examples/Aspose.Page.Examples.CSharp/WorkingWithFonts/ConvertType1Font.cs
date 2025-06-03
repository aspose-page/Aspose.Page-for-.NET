using Aspose.Page.EPS;

namespace CSharp.WorkingWithFonts
{
    public class ConvertType1Font
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithFonts();

            //Create ne PsDocument object
            PsDocument doc = new PsDocument();

            //Convert Type1 font from the file 'Type1_Arial_Bold.ps' to TTF font in dataDir folder.
            //Exstension of file can be ".pfa", ".pfb", ".ps" or something else. The main thing is that there is a font Type1 inside.
            doc.ConvertType1FontToTTF(dataDir + "Type1_Arial_Bold.ps", dataDir);
            
            // ExEnd:1
        }
    }
}
