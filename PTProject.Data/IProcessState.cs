﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTProject.Data
{
    public interface IProcessState
    {
        int numberUser(List<User>);

        int numberGood(Catalog);

    }
}
