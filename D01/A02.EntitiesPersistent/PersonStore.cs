using ContosoUniversity.A01.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.A02.EntitiesPersistent
{
    public class PersonStore
    {
        public static ICollection<Person> Persons { get; set; }  // 人员对象集合
        /// <summary>
        /// 静态构造函数，用于初始化人员对象集合
        /// </summary>
        static PersonStore()
        {
            _InitialPersons();
        }
        /// <summary>
        /// 初始化原始数据
        /// </summary>
        private static void _InitialPersons()
        {
            Persons = new List<Person>()
            {
                new Person() { Name="刘虎军", Email="Liuhj@qq.com",
                Mobile="15107728899", SortCode="01001", Description="请补充个人简介" },
                new Person() { Name="魏小花", Email="weixh@163.com", Mobile="13678622345", SortCode="01002", Description="请补充个人简介" },
                new Person() { Name="李文慧", Email="liwenhui@tom.com", Mobile="13690251923", SortCode="01003", Description="请补充个人简介" },
                new Person() { Name="张江的", Email="zhangjd@msn.com", Mobile="13362819012", SortCode="01004", Description="请补充个人简介" },
                new Person() { Name="萧可君", Email="xiaokj@qq.com", Mobile="13688981234", SortCode="01005", Description="请补充个人简介" },
                new Person() { Name="魏铜生", Email="weitsh@qq.com", Mobile="18398086323", SortCode="01006", Description="请补充个人简介" },
                new Person() { Name="刘德华", Email="liudh@icloud.com", Mobile="13866225636", SortCode="01007", Description="请补充个人简介" },
                new Person() { Name="魏星亮", Email="weixl@liuzhou.com", Mobile="13872236091", SortCode="01008", Description="请补充个人简介" },
                new Person() { Name="潘家富", Email="panjf@guangxi.com", Mobile="13052366213", SortCode="01009", Description="请补充个人简介" },
                new Person() { Name="黎温德", Email="liwende@qq.com", Mobile="13576345509", SortCode="01010", Description="请补充个人简介" },
                new Person() { Name="邓淇升", Email="dengqsh@qq.com", Mobile="13709823456", SortCode="01011", Description="请补充个人简介" },
                new Person() { Name="谭希林", Email="tangx@live.com", Mobile="18809888754", SortCode="01012", Description="请补充个人简介" },
                new Person() { Name="陈琳", Email="chenhl@live.com", Mobile="13172038023", SortCode="01013", Description="请补充个人简介" },
                new Person() { Name="祁华钰", Email="qihy@qq.com", Mobile="15107726987", SortCode="01014", Description="请补充个人简介" },
                new Person() { Name="胡德财", Email="hudc@qq.com", Mobile="13900110988", SortCode="01015", Description="请补充个人简介" },
                new Person() { Name="吴富贵", Email="wufugui@hotmail.com", Mobile="15087109921", SortCode="01016", Description="请补充个人简介" }
            };

        }
    }
}
