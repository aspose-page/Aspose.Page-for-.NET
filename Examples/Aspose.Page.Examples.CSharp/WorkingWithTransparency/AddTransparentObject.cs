using Aspose.Page.XPS;
using Aspose.Page.XPS.XpsModel;
using System.Drawing;


namespace CSharp.WorkingWithTransparency
{
    public class AddTransparentObject
    {
        public static void Run()
        {
            // ExStart:1
            // The path to the documents directory.
            string dataDir = RunExamples.GetDataDir_WorkingWithTransparency();
            // Create new XPS Document
            XpsDocument doc = new XpsDocument();

            // Just to demonstrate transparency
            doc.AddPath(doc.CreatePathGeometry("M120,0 H400 v1000 H120")).Fill = doc.CreateSolidColorBrush(Color.Gray);
            doc.AddPath(doc.CreatePathGeometry("M300,120 h600 V420 h-600")).Fill = doc.CreateSolidColorBrush(Color.Gray);

            // Create path with closed rectangle geometry
            XpsPath path1 = doc.CreatePath(doc.CreatePathGeometry("M20,20 h200 v200 h-200 z"));
            // Set blue solid brush to fill path1
            path1.Fill = doc.CreateSolidColorBrush(Color.Blue);
            // Add it to the current page
            XpsPath path2 = doc.Add(path1);

            // path1 and path2 are the same as soon as path1 hasn't been placed inside any other element
            // (which means that path1 had no parent element).
            // Because of that rectangle's color on the page effectively turns to green
            path2.Fill = doc.CreateSolidColorBrush(Color.Green);

            // Now add path2 once again. Now path2 has parent. So path3 won't be the same as path2.
            // Thus a new rectangle is painted on the page ...
            XpsPath path3 = doc.Add(path2);
            // ... and we shift it 300 units lower ...
            path3.RenderTransform = doc.CreateMatrix(1, 0, 0, 1, 0, 300);
            // ... and set red solid brush to fill it
            path3.Fill = doc.CreateSolidColorBrush(Color.Red);

            // Create new path4 with path2's geometry ...
            XpsPath path4 = doc.AddPath(path2.Data);
            // ... shift it 300 units to the right ...
            path4.RenderTransform = doc.CreateMatrix(1, 0, 0, 1, 300, 0);
            // ... and set blue solid fill
            path4.Fill = doc.CreateSolidColorBrush(Color.Blue);

            // Add path4 once again.
            XpsPath path5 = doc.Add(path4);
            // path4 and path5 are not the same again ...
            // (move path5 300 units lower)
            path5.RenderTransform = path5.RenderTransform.Clone(); // to disconnect RenderTransform value from path4 (see next comment about Fill property)
            path5.RenderTransform.Translate(0, 300);
            // ... but if we set the opacity of Fill property, it will take effect on both path5 and path4
            // because brush is a complex property value which remains the same for path5 and path4
            path5.Fill.Opacity = 0.8f;

            // Create new path6 with path2's geometry ...
            XpsPath path6 = doc.AddPath(path2.Data);
            // ... shift it 600 units to the right ...
            path6.RenderTransform = doc.CreateMatrix(1, 0, 0, 1, 600, 0);
            // ... and set yellow solid fill
            path6.Fill = doc.CreateSolidColorBrush(Color.Yellow);

            // Now add path6's clone ...
            XpsPath path7 = doc.Add(path6.Clone());
            // (move path5 300 units lower)
            path7.RenderTransform = path7.RenderTransform.Clone();
            path7.RenderTransform.Translate(0, 300);
            // ... and set opacity for path7
            path7.Fill.Opacity = 0.8f;
            // Now opacity effects independantly as soon as property values are cloned along with the element

            // The following code block is equivalent to the previous one.
            // Add path6 itself. path6 and path7 are not the same. Although their Fill property values are the same 
            //XpsPath path7 = doc.Add(path6);
            //path7.RenderTransform = path7.RenderTransform.Clone();
            //path7.RenderTransform.Translate(0, 300);
            // To "disconnect" path7's Fill property from path6's Fill property reassign it to its clone (or path6's Fill clone)
            //path7.Fill = ((XpsSolidColorBrush)path7.Fill).Clone();
            //path7.Fill.Opacity = 0.8f;

            // Save resultant XPS document
            doc.Save(dataDir + "WorkingWithTransparency_out.xps");
            // ExEnd:1
        }
    }
}
