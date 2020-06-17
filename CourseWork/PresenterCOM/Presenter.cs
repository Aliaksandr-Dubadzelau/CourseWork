using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;

namespace PresenterCOM
{

    [Guid("1E363574-5AC1-4825-8C55-492411BE334B")]
    [ClassInterface(ClassInterfaceType.None)]
    [ComSourceInterfaces(typeof(COMTechnologiInterface))]
    [ComVisible(true)]
    public class Presenter : PresenterInterface
    {

        void PresenterInterface.StartPresintation()
        {

            Application ppApp = new Application();
            ppApp.Visible = MsoTriState.msoTrue;
            Presentations ppPresens = ppApp.Presentations;
            Presentation objPres = ppPresens.Open(@"E:\\courseWork\\CourseProject\\CourseWork\\CourseWork\\exports\\presentation.pptx", MsoTriState.msoFalse, MsoTriState.msoTrue, MsoTriState.msoTrue);
            Slides objSlides = objPres.Slides;
            int n = objSlides.Count; //получаю количество слайдов в показываемой презентации
            SlideShowWindows objSSWs;
            SlideShowSettings objSSS;


            objSSS = objPres.SlideShowSettings;
            objSSS.EndingSlide = n - 2;
            objSSS.Run();
            objSSWs = ppApp.SlideShowWindows;

            Thread.Sleep(n * 5000);// пауза между слайдами так как 1 секунда переход 2 секунды слайд

            objPres.Close();
            ppApp.Quit();

            //закрываем потоки
            var processes = System.Diagnostics.Process.GetProcessesByName("POWERPNT");
            foreach (var p in processes)
            {
                p.Kill();
            }

        }

    }
}
