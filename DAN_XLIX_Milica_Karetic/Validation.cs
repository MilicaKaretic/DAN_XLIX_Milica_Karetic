using DAN_XLIX_Milica_Karetic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLIX_Milica_Karetic
{
    class Validation
    {
        public bool ValidManagerInput(vwManager manager)
        {
            string f = manager.Floor.ToString();
            string e = manager.Experience.ToString();

            if (Int32.TryParse(f, out int fl))
            {
                if (manager.QualificationsLevel >= 1 && manager.QualificationsLevel <= 7)
                {
                    if (Int32.TryParse(e, out int ex))
                        return true;
                    else return false;
                }
                else return false;
            }
            else
                return false;
          
        }

        public bool ValidEmployeeInput(vwEmployee employee)
        {
            string f = employee.Floor.ToString();
            

            if (Int32.TryParse(f, out int fl))
            {
                if (employee.Gender.ToLower() == "m" || employee.Gender.ToLower() == "z")
                {
                        return true;

                }
                else return false;
            }
            else
                return false;

        }
    }
}
