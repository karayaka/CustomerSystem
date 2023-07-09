using System;
using System.Linq.Expressions;
using CustomerSystm.Domain.EntitiyModels.BaseModels;

namespace CustomerSystem.Application.Repositorys
{
	public interface IRepository
	{
        /// <summary>
        /// Generik Olarak Ekleme Metodu
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<T> Add<T>(T model) where T : BaseEntityModel;

        /// <summary>
        /// Liste OLarak Ekele
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="models"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> AddRange<T>(IEnumerable<T> models) where T : BaseEntityModel;
        Task<IQueryable<T>> AddRange<T>(IQueryable<T> models) where T : BaseEntityModel;

        /// <summary>
        /// Generik Olarak Güncelleme
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entitiy"></param>
        /// <returns></returns>
        T Update<T>(T Entitiy) where T : BaseEntityModel;

        /// <summary>
        /// Liste Olarak Günceleme
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entitiy"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> UpdateRange<T>(IEnumerable<T> models) where T : BaseEntityModel;

        /// <summary>
        /// Generik Olarak Silme Metoƒdu
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ID"></param>
        Task<T> Delete<T>(Guid ID) where T : BaseEntityModel;

        /// <summary>
        /// Generik Olarak Silme Metodu
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ID"></param>
        Task<T> Delete<T>(T model) where T : BaseEntityModel;

        /// <summary>
        /// Liste Halinde Silme
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ID"></param>
        Task<IEnumerable<T>> DeleteRange<T>(IEnumerable<T> models) where T : BaseEntityModel;


        /// <summary>
        /// ID ile DbSilme
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ID"></param>
        Task<Guid> Remove<T>(Guid ID) where T : BaseEntityModel;

        /// <summary>
        /// Liste Silme
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ID"></param>
        void RemoveRange<T>(IEnumerable<T> models) where T : BaseEntityModel;

        /// <summary>
        /// Get Queryable Generik
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<T> Get<T>(Expression<Func<T, bool>> expression) where T : BaseEntityModel;

        /// <summary>
        /// Get Queryable NonDeleted
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<T> GetNonDeleted<T>(Expression<Func<T, bool>> expression) where T : BaseEntityModel;

        /// <summary>
        /// Get Queryable NonDeleted ve Aktif Kayıtlar
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        IQueryable<T> GetNonDeletedAndActive<T>(Expression<Func<T, bool>> expression) where T : BaseEntityModel;

        /// <summary>
        /// FistOr Defaol
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<T> Find<T>(Expression<Func<T, bool>> expression) where T : BaseEntityModel;
        /// <summary>
        /// sili,nmemiş objeler alınıyor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<T> FindNonDeleted<T>(Expression<Func<T, bool>> expression) where T : BaseEntityModel;
        /// <summary>
        /// silinmemiş ve aktif objeler
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<T> FindNonDeletedActive<T>(Expression<Func<T, bool>> expression) where T : BaseEntityModel;
        /// <summary>
        /// ID ile select view vi yazmaya yarayan kod
        /// </summary>
        /// <typeparam name="T">Tablo Entity</typeparam>
        /// <typeparam name="TResult">Dönüş Modeli</typeparam>
        /// <param name="ID">Onject ID</param>
        /// <param name="selection">Query</param>
        /// <returns></returns>
        TResult SelectByID<T, TResult>(int ID, Expression<Func<T, TResult>> selection) where T : BaseEntityModel;
        /// <summary>
        /// ID ile getirilmniş onje kayıtları
        /// ınculude yapılamaz!
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ID"></param>
        /// <returns></returns>
        Task<T> GetByID<T>(Guid ID) where T : BaseEntityModel;

        /// <summary>
        /// Sayfalama işleminde önce sayfa sayısı
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        int GetPageCount<T>(Expression<Func<T, bool>> expression, int pageSize) where T : BaseEntityModel;

        /// <summary>
        /// Sorgu Veilmez ise silinmemiş aktif kayıtların sayfa sayısı getiriyor
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        int GetPageCount<T>(int pageSize) where T : BaseEntityModel;

        /// <summary>
        /// Quarible nesneyi ni saydfa sayısını veran kod
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="models"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        int GetPageCount<T>(IQueryable<T> models, int pageSize) where T : BaseEntityModel;

        /// <summary>
        /// Qurable nesneyi sayfalayıp dönen fonsiyon
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="models">Nesneler</param>
        /// <param name="pageCount"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IQueryable<T> GetPaginate<T>(IQueryable<T> models, int pageCount, int pageSize) where T : BaseEntityModel;


        /// <summary>
        /// Sayı Getit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        int Count<T>(Expression<Func<T, bool>> expression) where T : BaseEntityModel;
        /// <summary>
        /// silinmemiş kayıtları getir
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        int CountNonDeleted<T>(Expression<Func<T, bool>> expression) where T : BaseEntityModel;
        /// <summary>
        /// Silinmemiş ve aktif kayıtları getir
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        int CountNonDeletedAndActive<T>(Expression<Func<T, bool>> expression) where T : BaseEntityModel;
        /// <summary>
        /// Generick Any COde
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        bool Any<T>(Expression<Func<T, bool>> expression) where T : BaseEntityModel;
        /// <summary>
        /// silinmemiş any
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        bool AnyNonDeleted<T>(Expression<Func<T, bool>> expression) where T : BaseEntityModel;
        /// <summary>
        /// Sİlinmemiş ve Aktif Ant Code
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        bool AnyNonDeletedAndActive<T>(Expression<Func<T, bool>> expression) where T : BaseEntityModel;
        /// <summary>
        /// Save All Db Changes Changes
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChange();
    }
}

