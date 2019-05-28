using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace D01.A01.Entities
{
    public class Department:IEntity
    {
        [Key]
        public Guid ID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }                          // 部门名称
        [StringLength(1000)]
        public string Description { get; set; }                   // 部门简要说明
        [StringLength(150)]
        public string SortCode { get; set; }                      // 部门编码
        public bool IsActiveDepartment { get; set; }              // 部门状态

        public virtual Department ParentDepartment { get; set; }  // 上级部门

        public Department()
        {
            this.ID = Guid.NewGuid();
            this.IsActiveDepartment = true;
        }

    }
}
