using Zenject;

namespace AvatarDetails
{
    public class FileBrowserInstaller : MonoInstaller<FileBrowserInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<FileBrowser>()
                .To<FileBrowser>()
                .AsCached();
        }
    }
}