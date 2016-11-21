using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParrallelPrograming_task1_;

namespace ClimateData
{
    public class ViewModel
    {
        int level;
        Model obj = new Model();
       List<line> lines;
        public ViewModel(int level) {
            this.level = level;
        }
       public void Execute()
        {
            if (obj.DownloadGrid()) 
                lines = obj.CalcLevelLine(level);
        }
        public List<line> GetLines()
        {
            return lines;
        }
    }
}
