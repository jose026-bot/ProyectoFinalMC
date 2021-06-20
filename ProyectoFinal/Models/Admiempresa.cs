﻿using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoFinal.Models
{
    public partial class Admiempresa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public int? EmpresaId { get; set; }
        public string Saladmin { get; set; }

        public virtual Empresa Empresa { get; set; }
    }
}
