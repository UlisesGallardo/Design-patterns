using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALUMNI_APP
{
    class ProfessorCreator : UserCreator
    {
        public override User CreateUser(string ID)
        {
            return new Professor(ID);
        }
    }
}
