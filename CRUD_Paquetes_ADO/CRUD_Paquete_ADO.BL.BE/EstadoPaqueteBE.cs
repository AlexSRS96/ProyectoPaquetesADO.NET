using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Paquete_ADO.BL.BE
{
    public class EstadoPaqueteBE
    {
        public int PackageID { get; set; }
        public String StatusDescription { get; set; }
        public DateTime ReceptionDate { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
