using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EducationAll.Datas
{
    public partial class Grade
    {
        public override string ToString()
        {
            return this.name;
        }
    }

    public partial class User
    {
        public bool isAdmin()
        {
            return (this.idRank == App.RankAdmin);
        }
    }
}
