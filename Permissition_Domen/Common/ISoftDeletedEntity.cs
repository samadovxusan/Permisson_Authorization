using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Permission_Domen.Common
{
    public interface ISoftDeletedEntity
    {
        bool IsDeleted { get; set; }
        DateTime DateTimeDeleted { get; set; }

    }
}
