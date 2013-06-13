using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test_WPF
{
    public static class Bdd
    {
        public Datas.EducationAllEntities db { get; set; }

        public Bdd()
        {
            db = new Datas.EducationAllEntities();
        }
    }
}
