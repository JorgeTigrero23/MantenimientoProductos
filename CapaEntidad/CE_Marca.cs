using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_Marca
    {
        private int _Idmarca;
        private string _codigomarca;
        private string _nombremarca;
        private string _descripcionmarca;

        public int Idmarca { get => _Idmarca; set => _Idmarca = value; }
        public string Codigomarca { get => _codigomarca; set => _codigomarca = value; }
        public string Nombremarca { get => _nombremarca; set => _nombremarca = value; }
        public string Descripcionmarca { get => _descripcionmarca; set => _descripcionmarca = value; }
    }
}
