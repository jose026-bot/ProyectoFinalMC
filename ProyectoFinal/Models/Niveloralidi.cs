﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoFinal.Models
{
    public partial class Niveloralidi
    {
        public Niveloralidi()
        {
            Idiomacandid = new HashSet<Idiomacandid>();
        }

        public int Id { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Idiomacandid> Idiomacandid { get; set; }
    }
}
