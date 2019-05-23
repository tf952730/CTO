using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.A01.Entities
{
    public class Person
    {
        [Key]
        public Guid ID { get; set; }            // 人员标识
        [StringLength(20)]
        [Required]
        public string Name { get; set; }        // 姓名
        [StringLength(1000)]
        public string Email { get; set; }       // 电子邮件
        [StringLength(20)]
        public string Mobile { get; set; }      // 移动电话号码
        public string Description { get; set; } // 简要说明
        [Required]
        [StringLength(50)]
        public string SortCode { get; set; }    // 序号
        public Person()
        {
            this.ID = Guid.NewGuid();
        }
    }
}
