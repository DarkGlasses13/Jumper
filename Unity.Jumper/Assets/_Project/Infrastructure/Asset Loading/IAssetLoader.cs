using System.Threading.Tasks;

namespace Assets._Project.Infrastructure.Asset_Loading
{
    public interface IAssetLoader<T>
    {
        object Key { get; }
        T Load();
        Task<T> LoadAsync();
        void Unload();
    }
}
