using ContosoUniversity.A01.Entities;
using D01.A01.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace D01.A02.EntitiesPersistent
{
    public static class DataSeedDemo01
    {
        static D01DbContext _DbContext;
        /// <summary>
        /// 公开的初始化方法
        /// </summary>
        public static void ForEntities(D01DbContext context)
        {
            _DbContext = context;
            _DepartmentAndEmployee();
            _Person();
        }

        /// <summary>
        /// 普通组织结构和人员
        /// </summary>
        private static void _DepartmentAndEmployee()
        {
            if (_DbContext.Departments.Any())
                return;
            var dept01 = new Department() { Name = "总经办", Description = "", SortCode = "01" };
            var dept02 = new Department() { Name = "综合管理办公室", Description = "", SortCode = "02" };
            var dept03 = new Department() { Name = "开发部", Description = "", SortCode = "03" };
            var dept04 = new Department() { Name = "营运部", Description = "", SortCode = "04" };
            var dept0401 = new Department() { Name = "客户响应服务组", Description = "", SortCode = "0401" };
            var dept0402 = new Department() { Name = "客户需求分析组", Description = "", SortCode = "0402" };
            var dept0403 = new Department() { Name = "应用设计开发组", Description = "", SortCode = "0403" };
            var dept05 = new Department() { Name = "市场部", Description = "", SortCode = "05" };
            var dept06 = new Department() { Name = "品管部", Description = "", SortCode = "06" };
            var dept0601 = new Department() { Name = "营运部驻场服务组", Description = "", SortCode = "0601" };
            var dept0602 = new Department() { Name = "开发部驻场服务组", Description = "", SortCode = "0602" };

            dept01.ParentDepartment = dept01;
            dept02.ParentDepartment = dept02;
            dept03.ParentDepartment = dept03;
            dept04.ParentDepartment = dept04;
            dept0401.ParentDepartment = dept04;
            dept0402.ParentDepartment = dept04;
            dept0403.ParentDepartment = dept04;
            dept05.ParentDepartment = dept05;
            dept06.ParentDepartment = dept06;
            dept0601.ParentDepartment = dept06;
            dept0602.ParentDepartment = dept06;

            var depts = new List<Department>() { dept01, dept02, dept03, dept04, dept0401, dept0402, dept0403, dept05, dept06, dept0601, dept0602 };
            foreach (var item in depts)
                _DbContext.Departments.Add(item);
            _DbContext.SaveChanges();

            if (_DbContext.Employees.Any())
            {
                return;
            }

            var persons = new List<Employee>()
            {
                new Employee() { Name="刘虎军", Sex=true, Email="Liuhj@qq.com", Mobile="15107728899", SortCode="01001", Description="请补充个人简介", Department=dept01 },
                new Employee() { Name="魏小花", Sex=false, Email="weixh@163.com", Mobile="13678622345", SortCode="01002", Description="请补充个人简介",Department=dept02 },
                new Employee() { Name="李文慧", Sex=false, Email="liwenhui@tom.com", Mobile="13690251923", SortCode="01003", Description="请补充个人简介",Department=dept02 },
                new Employee() { Name="张江的", Sex=true, Email="zhangjd@msn.com", Mobile="13362819012", SortCode="01004", Description="请补充个人简介",Department=dept03 },
                new Employee() { Name="萧可君", Sex=false, Email="xiaokj@qq.com", Mobile="13688981234", SortCode="01005", Description="请补充个人简介",Department=dept03 },
                new Employee() { Name="魏铜生", Sex=true, Email="weitsh@qq.com", Mobile="18398086323", SortCode="01006", Description="请补充个人简介",Department=dept03 },
                new Employee() { Name="刘德华", Sex=true, Email="liudh@icloud.com", Mobile="13866225636", SortCode="01007", Description="请补充个人简介",Department=dept03 },
                new Employee() { Name="魏星亮", Sex=true, Email="weixl@liuzhou.com", Mobile="13872236091", SortCode="01008", Description="请补充个人简介",Department=dept04 },
                new Employee() { Name="潘家富", Sex=true, Email="panjf@guangxi.com", Mobile="13052366213", SortCode="01009", Description="请补充个人简介",Department=dept0401 },
                new Employee() { Name="黎温德", Sex=true, Email="liwende@qq.com", Mobile="13576345509", SortCode="01010", Description="请补充个人简介",Department=dept0401 },
                new Employee() { Name="邓淇升", Sex=true, Email="dengqsh@qq.com", Mobile="13709823456", SortCode="01011", Description="请补充个人简介" ,Department=dept0402},
                new Employee() { Name="谭冠希", Sex=true, Email="tangx@live.com", Mobile="18809888754", SortCode="01012", Description="请补充个人简介" ,Department=dept0403},
                new Employee() { Name="陈慧琳", Sex=false, Email="chenhl@live.com", Mobile="13172038023", SortCode="01013", Description="请补充个人简介" ,Department=dept05},
                new Employee() { Name="祁华钰", Sex=true, Email="qihy@qq.com", Mobile="15107726987", SortCode="01014", Description="请补充个人简介" ,Department=dept06},
                new Employee() { Name="胡德财", Sex=true, Email="hudc@qq.com", Mobile="13900110988", SortCode="01015", Description="请补充个人简介" ,Department=dept0601},
                new Employee() { Name="吴富贵", Sex=true, Email="wufugui@hotmail.com", Mobile="15087109921", SortCode="01016", Description="请补充个人简介" ,Department=dept0602}
            };

            foreach (var person in persons)
            {
                _DbContext.Employees.Add(person);
            }
            _DbContext.SaveChanges();
        }

        private static void _Person()
        {
            if (_DbContext.People.Any())
            {
                return;
            }

            var persons = new List<Person>()
            {
                new Person() { Name="刘虎军", Email="Liuhj@qq.com", Mobile="15107728899", SortCode="01001", Description="请补充个人简介" },
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

            foreach (var person in persons)
            {
                _DbContext.People.Add(person);
            }
            _DbContext.SaveChanges();

        }
    }
}
