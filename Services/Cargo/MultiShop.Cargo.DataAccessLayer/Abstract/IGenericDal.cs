using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.Abstract
{
	public interface IGenericDal<T> where T : class
	{
		List<T> GetList();
		T GetById(int id);
		void Insert(T entity);
		void Update(T entity);
		void Delete(int id);
	}
}
