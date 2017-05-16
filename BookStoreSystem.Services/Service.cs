using BookShopSystem.Data;

namespace BookStoreSystem.Services
{
    public abstract class Service
    {
        protected Service()
        {
            this.Context = new BookShopContext();
        }

        protected BookShopContext Context { get; }
    }
}
