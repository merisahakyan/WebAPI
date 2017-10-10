using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DomainName { get; set; }
        public bool Default { get; set; }
    }
}
