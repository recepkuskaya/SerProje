using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerProje.Class
{
    public class ParentKisi : KisiBilgisi
    {
        public int Ust_Kisi_Id { get; set; }

        public int Ast_Kisi_Id { get; set; }


        public virtual ICollection<KisiBilgisi> KisiBilgisis { get; set; }
    }
}
