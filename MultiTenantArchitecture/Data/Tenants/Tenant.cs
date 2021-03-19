using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MultiTenantArchitecture.Data.Tenants
{
    public class Tenant
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tenant Name")]
        public string Name { get; set; }

        [Display(Name = "Host")]
        public string Host { get; set; }

        [Display(Name = "Database Connection String")]
        public string ConnectionString { get; set; }
    }
}
