using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteChecker
{
    public interface ILogWrite
    {
        string GetResults(string results);
    }
}
