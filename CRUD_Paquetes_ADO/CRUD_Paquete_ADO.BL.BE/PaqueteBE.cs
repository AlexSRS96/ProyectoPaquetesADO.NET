using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Paquete_ADO.BL.BE
{
    public class PaqueteBE
    {
        public int PackageID { get; set; }
        public String Description { get; set; }
        public int CustomerID { get; set; }
        public Decimal Price { get; set; }
        public int CustomerReceptionID { get; set; }

    }
}
