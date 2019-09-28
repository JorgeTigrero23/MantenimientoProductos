using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class CE_Categoria
    {
        private int _Idcategoria;
        private string _Codigocategoria;
        private string _Nombrecategoria;
        private string _Descripcioncategoria;

        public int Idcategoria { get => _Idcategoria; set => _Idcategoria = value; }
        public string Codigocategoria { get => _Codigocategoria; set => _Codigocategoria = value; }
        public string Nombrecategoria { get => _Nombrecategoria; set => _Nombrecategoria = value; }
        public string Descripcioncategoria { get => _Descripcioncategoria; set => _Descripcioncategoria = value; }
    }
}
