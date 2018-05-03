using System;
using System.Collections.Generic;
using System.Text;

namespace Encuesta
{
    public class Encuesta
    {
        #region Properties
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string EquipoFavorito { get; set; }
        #endregion
        public override string ToString()
        {
            return $"{Nombre} |{FechaNacimiento}| {EquipoFavorito}";
        }
    }
}
