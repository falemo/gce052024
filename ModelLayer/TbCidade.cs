﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class TbCidade
    {
        public int Id { get; set; }
        public string NmCidade { get; set; }
        public int IdEstado { get; set; }

        public TbEstado Estado { get; set; }
    }

}
