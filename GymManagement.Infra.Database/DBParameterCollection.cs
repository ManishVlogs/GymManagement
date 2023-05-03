using GymManagement.Infra.Database.Contracts;
using System.Data.Common;

namespace GymManagement.Infra.Database
{
    public class DBParameterCollection : IDBParameterCollection, IDisposable
    {
        private List<DBParameter> _parameterCollection = new List<DBParameter>();

        /// <summary>
        /// Adds a DBParameter to the ParameterCollection
        /// </summary>
        /// <param name="parameter">Parameter to be added</param>
        public void Add(DBParameter parameter)
        {
            _parameterCollection.Add(parameter);
        }

        /// <summary>
        /// Removes parameter from the Parameter Collection
        /// </summary>
        /// <param name="parameter">Parameter to be removed</param>
        public void Remove(DBParameter parameter)
        {
            _parameterCollection.Remove(parameter);
        }

        /// <summary>
        /// Removes all the parameters from the Parameter Collection
        /// </summary>
        public void RemoveAll()
        {
            _parameterCollection.RemoveRange(0, _parameterCollection.Count);
        }

        /// <summary>
        /// Removes parameter from the specified index.
        /// </summary>
        /// <param name="index">Index from which parameter is supposed to be removed</param>
        public void RemoveAt(int index)
        {
            _parameterCollection.RemoveAt(index);
        }

        /// <summary>
        /// Gets list of parameters
        /// </summary>
        internal List<DBParameter> Parameters
        {
            get
            {
                return _parameterCollection;
            }
        }

        public void Dispose()
        {

        }
    }
}