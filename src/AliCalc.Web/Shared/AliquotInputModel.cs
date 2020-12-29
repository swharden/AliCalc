using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliCalc.Web.Shared
{
    public class AliquotInputModel
    {
        public string DrugName;
        public bool DrugNameIsValid => !string.IsNullOrWhiteSpace(DrugName);
    }
}
