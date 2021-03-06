﻿using Domain;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IMandateService : IService<mandate>
    {
        List<mandate> getMandates(int id);
    }
}
