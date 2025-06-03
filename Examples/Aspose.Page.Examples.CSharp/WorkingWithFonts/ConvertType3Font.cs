using Aspose.Page.EPS;

namespace CSharp.WorkingWithFonts
{
    public class ConvertType3Font
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithFonts();

            //Create ne PsDocument object
            PsDocument doc = new PsDocument();

            //Convert outline Type3 font from the file 'Type3_outline.ps' to TTF font in dataDir folder.
            //Exstension of file can be ".ps" or something else. The main thing is that there is a font Type3 inside.
            doc.ConvertType3FontToTTF(dataDir + "Type3_outline.ps", dataDir);

            //Convert butmap Type3 font from the file 'Type3_bitmap.ps' to TTF font in dataDir folder.
            doc.ConvertType3FontToTTF(dataDir + "Type3_bitmap.ps", dataDir);

            // ExEnd:1
        }
    }
}
