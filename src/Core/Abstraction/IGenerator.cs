using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Abstraction
{
    public interface IGenerator
    {
        IEnumerable<FileInfo> GenerateSite(Site Site);
    }
}
