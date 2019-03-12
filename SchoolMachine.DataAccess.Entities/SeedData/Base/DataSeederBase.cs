using SchoolMachine.DataAccess.Entities.Interfaces;
using System.Collections.Generic;

namespace SchoolMachine.DataAccess.Entities.SeedData.Base
{
    public class DataSeederBase<T> where T : INamedEntity
    {
        #region Constructors

        public DataSeederBase() {
            Initialize();
        }

        #endregion Constructors

        #region Private Variables

        private Dictionary<string, T> _dictionary;

        #endregion Private Variables

        #region Public Properties

        public Dictionary<string, T> Dictionary
        {
            get
            {
                if (_dictionary == null)
                {
                    _dictionary = new Dictionary<string, T>();
                    foreach (var obj in Objects)
                    {
                        _dictionary[obj.Name] = obj;
                    }
                }
                return _dictionary;
            }
            set { _dictionary = value; }
        }

        public List<T> Objects = new List<T>();

        #endregion Public Properties

        #region Initialization

        protected virtual void Initialize()
        {
        }

        #endregion Initialization
    }
}
