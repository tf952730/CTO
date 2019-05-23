using ContosoUniversity.A01.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class PersonViewModel
    {
        public Guid ID { get; set; }
        public string OrderNumber { get; set; }   // 列表时做列表序号的标识字符串

        [Display(Name = "姓名")]
        [Required(ErrorMessage = "姓名数据是必须的。")]
        [StringLength(10, ErrorMessage = "字符串长度不能超过 10 个字符。")]
        public string Name { get; set; }

        [Display(Name = "电子邮件")]
        [Required(ErrorMessage = "电子邮件数据是必须的。")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "移动电话")]
        [RegularExpression(@"((^13[0-9]{1}[0-9]{8}|^15[0-9]{1}[0-9]{8}|^14[0-9]{1}[0-9]{8}|^16[0-9]{1}[0-9]{8}|^17[0-9]{1}[0-9]{8}|^18[0-9]{1}[0-9]{8}|^19[0-9]{1}[0-9]{8})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)", ErrorMessage = "电话号码数据不合规！"),
            Required(ErrorMessage = "移动电话号码数据是必须的。"),
            MaxLength(11, ErrorMessage = "电话号码超过11位数！"),
            MinLength(11, ErrorMessage = "电话号码长度不足11位数！")]
        public string Mobile { get; set; }

        [Display(Name = "简要说明")]
        [StringLength(500, ErrorMessage = "字符串长度不能超过 500 个字符。")]
        public string Description { get; set; }

        [Display(Name = "人员编码")]
        [Required(ErrorMessage = "人员编码数据是必须的。")]
        [StringLength(50, ErrorMessage = "字符串长度不能超过 50 个字符。")]
        public string SortCode { get; set; }    // 序号

        /// <summary>
        /// 空构造函数
        /// </summary>
        public PersonViewModel() { }

        /// <summary>
        /// 通过人员对象构造视图模型
        /// </summary>
        /// <param name="person"></param>
        public PersonViewModel(Person person)
        {
            this.ID = person.ID;
            this.Name = person.Name;
            this.Email = person.Email;
            this.Mobile = person.Mobile;
            this.Description = person.Description;
            this.SortCode = person.SortCode;
        }

        /// <summary>
        /// 将视图模型转换为人员对象
        /// </summary>
        /// <returns></returns>
        public Person ToPerson()
        {
            var person = new Person()
            {
                ID = this.ID,
                Name = this.Name,
                Email = this.Email,
                Mobile = this.Mobile,
                Description = this.Description,
                SortCode = this.SortCode
            };

            return person;
        }
    }
}
