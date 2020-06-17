using CourseWork.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace OfficeClasses
{
    public class DataSaver : SaverInterface
    {

        async void SaverInterface.SaveToExcel(EntityCords entity)
        {

            await Task.Run(() =>
            {

                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Workbook excelWorkBook = excelApp.Workbooks.Add();
                Worksheet excelWorkSheet = excelWorkBook.Worksheets.Add();

                List<double> CordsY = entity.GetListY();
                List<double> CordsT = entity.GetListT();

                int length = CordsT.Count();

                excelWorkSheet.Columns[1].Rows[1] = "Step";
                excelWorkSheet.Columns[2].Rows[1] = "T";
                excelWorkSheet.Columns[3].Rows[1] = "Y (T)";

                AddT(CordsT, excelWorkSheet);
                AddY(CordsY, excelWorkSheet);
                AddStep(length, excelWorkSheet);
                CreateChart(length, excelWorkSheet);
                

                excelWorkSheet.SaveAs(@"E:\courseWork\CourseProject\CourseWork\CourseWork\exports\excel.xlsx");
                excelApp.Quit();

                PlayDoneSound();
            });

            

        }

        async void SaverInterface.SaveToWord(EntityCords entity, System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {

            SaveImage(chart);

            await Task.Run(() =>
            {

                Microsoft.Office.Interop.Word.Application oneWord = new Microsoft.Office.Interop.Word.Application();
           
                var oneDoc = oneWord.Documents.Add();

                var paragraphone = oneDoc.Content.Paragraphs.Add();

                String info = CreateInfo(entity);
                paragraphone.Range.Text = info;

                oneWord.ActiveDocument.Sections[1].Headers[Microsoft.Office.Interop.Word.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.InlineShapes.AddPicture(@"E:\courseWork\CourseProject\CourseWork\CourseWork\pictures\graphic.png");

                oneDoc.SaveAs2(@"E:\courseWork\CourseProject\CourseWork\CourseWork\exports\word.docx");
                oneWord.Quit();

                PlayDoneSound();

            });

        }

        private void SaveImage(System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            chart.SaveImage(@"E:\courseWork\CourseProject\CourseWork\CourseWork\pictures\graphic.png", System.Drawing.Imaging.ImageFormat.Png);
        }

        private void PlayDoneSound()
        {

            SoundPlayer doneSound = new SoundPlayer(@"E:\courseWork\CourseProject\CourseWork\CourseWork\sounds\soundSave.wav");
            doneSound.Play();

        }

        private String CreateInfo(EntityCords entity)
        {

            String info = " R0 = " + entity.GetR() + "\n P = " + entity.GetP() + "\n b = " + entity.GetB() + "\n h = " + entity.GetH() +
                "\n l = " + entity.GetL() + "\n E = " + entity.GetE() + "\n t0 = " + entity.GetT0() + "\n th = " + entity.GetTH() + "\n tk = " +
                entity.GetTK();

            return info;

        }

        private void CreateChart(int length, Worksheet excelWorkSheet)
        {
            ChartObjects xlCharts = (ChartObjects)excelWorkSheet.ChartObjects(Type.Missing);
            ChartObject myChart = (ChartObject)xlCharts.Add(300, 0, length/1.5, 350);
            Microsoft.Office.Interop.Excel.Chart chart = myChart.Chart;
            Microsoft.Office.Interop.Excel.SeriesCollection seriesCollection = (Microsoft.Office.Interop.Excel.SeriesCollection)chart.SeriesCollection(Type.Missing);
            Microsoft.Office.Interop.Excel.Series series = seriesCollection.NewSeries();
            series.XValues = excelWorkSheet.get_Range("B2", "B" + (length + 1));
            series.Values = excelWorkSheet.get_Range("C2", "C" + (length + 1));
            series.Name = "Fluctuation";
            chart.ChartType = XlChartType.xlXYScatterSmooth;
        }

        private void AddY(List<double> cordsY, Worksheet worksheet)
        {
            int j = 1;

            foreach (double y in cordsY)
            {
                worksheet.Columns[3].Rows[j + 1] = y;
                j++;
            }

        }

        private void AddT(List<double> cordsT, Worksheet worksheet)
        {
            int j = 1;

            foreach (double t in cordsT)
            {
                worksheet.Columns[2].Rows[j + 1] = t;
                j++;
            }

        }

        private void AddStep(int length, Worksheet worksheet)
        {

            for (int i = 1; i < length + 1; i++)
            {
                worksheet.Columns[1].Rows[i+1] = i;
            }

        }
    }
}
