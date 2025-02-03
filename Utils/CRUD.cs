using NHibernate;
using ProyectXAPI.Connections;

namespace ProyectXAPI.Utils
{
    /// <summary>
    ///     Class designed to make operations with NHibernate with the session defined on SessionFactoryCloud
    /// </summary>
    /// <typeparam name="T">The type of object NHibernate must work with when making queries to the server</typeparam>
    public class CRUD<T> : IDisposable
    {
        private NHibernate.ISession session;

        public NHibernate.ISession Session { get { return session; } }

        public CRUD(): this(SessionFactoryCloud.Open<T>())
        {
            
        }
        private CRUD(NHibernate.ISession session)
        {
            this.session = session;
        }
        /// <summary>
        ///     Method designed to select an object from the database the session
        ///     points to.
        /// </summary>
        /// <typeparam name="TParam">The data type of the ID</typeparam>
        /// <param name="id">The id Value which will be used to search on the table database</param>
        /// <returns>An object of the specified type param specified on the object</returns>
        public T SelectById<TParam>(TParam id)
        {
            return session.Get<T>(id);
        }
        /// <summary>
        ///     Returns a list of objects with all the information from the table the session points to
        /// </summary>
        /// <returns>A list of objects with its data type based on the type parameter T declared when creating this object</returns>
        public IEnumerable<T> SelectAll()
        {
            return session.Query<T>().ToArray();
        }

        public void Insert(T param)
        {
            string showInsertResult;
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(param);
                transaction.Commit();
            }
        }
        /// <summary>
        ///     Inserts a list of objects into the table database the session points to
        /// </summary>
        /// <param name="list">The list of objects to be inserted into the database</param>
        public void InsertMany(IEnumerable<T> list)
        {
            foreach (T param in list)
            {
                Insert(param);
            }
        }
        /// <summary>
        ///     Makes an update statement to the server changing the rows related to the object.
        ///     it is best advised to retrive an object with one of the select methods and alter it to modify data with this method.
        /// </summary>
        /// <param name="element">The object the method will update from the table database</param>
        /// <returns>True if it has succesfully updated or false if it has failed</returns>
        public void Update(T element)
        {
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Update(element);
                transaction.Commit();
            }
        }
        /// <summary>
        ///     Deletes the given object from the database
        /// </summary>
        /// <param name="element">The object to be deleted from the database</param>
        /// <returns>True if it has succesfully deleted the row or false if it has failed</returns>
        public void Delete(T element)
        {
            string showInsertResult;
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(element);
                transaction.Commit();
            }
        }
        private void ReOpenSession()
        {
            if (!session.IsOpen)
            {
                session = SessionFactoryCloud.Open<T>();
            }
        }
        public void Dispose()
        {
            this.session.Close();
        }
    }
}
