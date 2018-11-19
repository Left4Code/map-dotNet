using Data.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Pattern
{
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        #region Private Fields
        IUnitOfWork utwk;
        #endregion Private Fields

        #region Constructor
        protected Service(IUnitOfWork utwk)
        {
            this.utwk = utwk;
        }
        #endregion Constructor



        public virtual void Add(TEntity entity)
        {
            ////_repository.Add(entity);
            utwk.GetRepositoryBase<TEntity>().Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            //_repository.Update(entity);
            utwk.GetRepositoryBase<TEntity>().Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            //   _repository.Delete(entity);
            utwk.GetRepositoryBase<TEntity>().Delete(entity);
        }

        public virtual void Delete(Expression<Func<TEntity, bool>> where)
        {
            // _repository.Delete(where);
            utwk.GetRepositoryBase<TEntity>().Delete(where);
        }

        public virtual TEntity GetById(long id)
        {
            //  return _repository.GetById(id);
            return utwk.GetRepositoryBase<TEntity>().GetById(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            //return utwk.GetRepositoryBase<TEntity>().Get();
            //return _repository.GetById(id);
            //  return utwk.getRepository<TEntity>().GetById(id);
            return null;
        }

        public virtual IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> filter = null, Expression<Func<TEntity, bool>> orderBy = null)
        {
            //  return _repository.GetAll();
            return utwk.GetRepositoryBase<TEntity>().GetMany(filter, orderBy);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            //return _repository.Get(where);
            return utwk.GetRepositoryBase<TEntity>().Get(where);
        }



        public void Commit()
        {
            try
            {
                utwk.Commit();
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public void Dispose()
        {
            utwk.Dispose();
        }


    }
}
