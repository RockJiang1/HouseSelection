using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HouseSelection.DAL;

namespace HouseSelection.BLL
{
    public abstract partial class BaseBLL<T> where T : class, new()
    {
        public BaseBLL()
        {
            SetDAL();
        }

        public BaseDAL<T> _dal { get; set; }

        public abstract void SetDAL();

        public bool Add(T t)
        {
            _dal.Add(t);
            return _dal.SaveChanges();
        }
        public bool AddRange(List<T> t)
        {
            _dal.AddRange(t);
            return _dal.SaveChanges();
        }
        public bool Delete(T t)
        {
            _dal.Delete(t);
            return _dal.SaveChanges();
        }
        public bool DeleteRange(List<T> t)
        {
            _dal.DeleteRange(t);
            return _dal.SaveChanges();
        }
        public bool Update(T t)
        {
            _dal.Update(t);
            return _dal.SaveChanges();
        }
        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda)
        {
            return _dal.GetModels(whereLambda);
        }

        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda)
        {
            return _dal.GetModelsByPage(pageSize, pageIndex, isAsc, OrderByLambda, WhereLambda);
        }
    }
}
