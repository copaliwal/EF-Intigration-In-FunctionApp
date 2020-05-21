using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FunctionAppEF.EntityFramework.EntityFramework.Models
{
    public class MasterOrganization
    {
        [Key]
        [Column("OrgId")]
        public Guid OrgId { get; set; }
        public string Name { get; set; }
        string Connections { get; set; }
    }
}
