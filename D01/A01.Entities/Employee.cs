using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace D01.A01.Entities
{
    public class Employee : IEntity
    {
        [Key]
        public Guid ID { get; set; }                        // 人员标识
        [StringLength(10)]
        public string Name { get; set; }                    // 姓名
        public bool Sex { get; set; }                       // 性别
        public DateTime BirthDay { get; set; }              // 出生日期
        [StringLength(100)]
        public string Email { get; set; }                   // 电子邮件
        [StringLength(15)]
        public string Mobile { get; set; }                  // 移动电话号码
        [StringLength(2000)]
        public string Description { get; set; }             // 简要说明
        [StringLength(50)]
        public string SortCode { get; set; }                // 序号
        public virtual Department Department { get; set; }  // 归属部门
        public Employee()
        {
            this.ID = Guid.NewGuid();
            this.BirthDay = DateTime.Now;
        }
    }
}
