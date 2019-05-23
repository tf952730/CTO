using ContosoUniversity.A01.Entities;
using ContosoUniversity.A02.EntitiesPersistent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ContosoUniversity.A03.EntitiesProcess
{
    public class PersonRepository: IPersonRepository
    {
        /// <summary>
        /// 提取人员数据集合的对象个数
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return PersonStore.Persons.Count;
        }

        /// <summary>
        /// 根据人员对象 ID 提取单个人员对象
        /// </summary>
        /// <param name="id">人员对象标识</param>
        /// <returns></returns>
        public Person GetPerson(Guid id) => PersonStore.Persons.Where(x => x.ID == id).FirstOrDefault();

        /// <summary>
        /// 提取全部的人员对象
        /// </summary>
        /// <returns></returns>
        public List<Person> GetPersons() => PersonStore.Persons.ToList();

        /// <summary>
        /// 根据关键词提取全部符合关键词检索条件的人员对象
        /// </summary>
        /// <param name="keyword">关键词</param>
        /// <returns></returns>
        public List<Person> GetPersons(string keyword)
        {
            var persons = new List<Person>();
            if (String.IsNullOrEmpty(keyword))
            {
                persons = PersonStore.Persons.ToList();
            }
            else
            {
                persons = PersonStore.Persons.Where(x =>
                    x.Name.Contains(keyword) ||
                    x.Email.Contains(keyword) ||
                    x.Mobile.Contains(keyword) ||
                    x.Description.Contains(keyword) ||
                    x.SortCode.Contains(keyword)
                    ).ToList();
            }

            return persons;
        }

        /// <summary>
        /// 根据查询条件的 Lambda 表达式提取符合条件的人员对象集合
        /// </summary>
        /// <param name="predicate">查询条件的 Lambda 表达式</param>
        /// <returns></returns>
        public List<Person> GetPersons(Expression<Func<Person, bool>> predicate)
        {
            var persons = PersonStore.Persons.AsQueryable().Where(predicate).ToList();
            return persons;
        }

        /// <summary>
        /// 添加人员到数据集
        /// </summary>
        /// <param name="person">外部创建的人员对象</param>
        public bool Add(Person person)
        {
            PersonStore.Persons.Add(person);
            return true;
        }

        /// <summary>
        /// 编辑人员对象数据
        /// </summary>
        /// <param name="person">提取自本数据集的对象加工处理后返回的对象</param>
        /// <returns></returns>
        public bool Update(Person person)
        {
            var toBeEditPerson = PersonStore.Persons.Where(x => x.ID == person.ID).FirstOrDefault();
            if (toBeEditPerson == null)
                return false;
            else
            {
                toBeEditPerson.Name = person.Name;
                toBeEditPerson.Email = person.Email;
                toBeEditPerson.Mobile = person.Mobile;
                toBeEditPerson.Description = person.Description;
                toBeEditPerson.SortCode = person.SortCode;
                return true;
            }
        }

        /// <summary>
        /// 根据人员对象 ID 删除集合中的人员对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(Guid id)
        {
            var toBeDeletePerson = GetPerson(id);
            if (toBeDeletePerson == null)
                return false;
            else
            {
                PersonStore.Persons.Remove(toBeDeletePerson);
                return true;
            }
        }
    }
}
