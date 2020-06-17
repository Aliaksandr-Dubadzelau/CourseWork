using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PresenterCOM
{
    [Guid("DFBE8B74-8618-49A5-9AB4-848658A7660C")]
    [ComVisible(true)]
    public interface PresenterInterface
    {
        [DispId(1)]
        void StartPresintation();

    }
}
