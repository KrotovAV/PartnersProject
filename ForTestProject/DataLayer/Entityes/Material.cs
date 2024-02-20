using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entityes
{
    public class Material : Page
    {
        public int DirectryId { get; set; } //внешний ключ
        public virtual Directry Directry { get; set; } //навигацинное свойство
    }
}
