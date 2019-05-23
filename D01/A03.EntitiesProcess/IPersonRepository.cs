using ContosoUniversity.A01.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ContosoUniversity.A03.EntitiesProcess
{
    public interface IPersonRepository
    {
        /// 提取人员数据集合的对象个数
        /// </summary>
        /// <returns></returns>
        int Count();

        /// <summary>
        /// 根据人员对象 ID 提取单个人员对象
        /// </summary>
        /// <param name="id">人员对象标识</param>
        /// <returns></returns>
        Person GetPerson(Guid id);

        /// <summary>
        /// 提取全部的人员对象
        /// </summary>
        /// <returns></returns>
        List<Person> GetPersons();

        /// <summary>
        /// 根据关键词提取全部符合关键词检索条件的人员对象
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <returns></returns>
        List<Person> GetPersons(string keyword);

        /// <summary>
        /// 根据查询条件的 Lambda 表达式提取符合条件的人员对象集合
        /// </summary>
        /// <param name="predicate">查询条件的 Lambda 表达式</param>
        /// <returns></returns>
        List<Person> GetPersons(Expression<Func<Person, bool>> predicate);

        /// <summary>
        /// 添加人员到数据集
        /// </summary>
        /// <param name="person">外部创建的人员对象</param>
        /// <returns>ture 表示成功</returns>
        bool Add(Person person);

        /// <summary>
        /// 编辑人员对象数据
        /// </summary>
        /// <param name="person">待执行更新的持久化处理的人员对象</param>
        /// <returns>ture 表示成功</returns>
        bool Update(Person person);

        /// <summary>
        /// 根据人员对象 ID 删除集合中的人员对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ture 表示成功</returns>
        bool Delete(Guid id);

    }
}
