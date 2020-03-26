using Radilovsoft.Rest.Data.Ef.Provider;

namespace Sample.Db.Store
{
    public class TesterDbModelStore : EntityModelStore
    {
        public TesterDbModelStore() : base(typeof(TesterDbModelStore).Assembly)
        {
        }
    }
}