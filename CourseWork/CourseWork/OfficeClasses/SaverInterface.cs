using CourseWork.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace OfficeClasses
{
    interface SaverInterface
    {

        void SaveToWord(EntityCords entity, Chart chart1);
        void SaveToExcel(EntityCords entity);
    }
}
