using Cysharp.Threading.Tasks;

namespace AvatarDetails
{
    public class MainSceneViewModel : MVVMViewModelBase<MainSceneModel>
    {
        public async UniTask ImportFromFileAsync(string inFilepath)
            => await Model.ImportFromFileAsync(inFilepath);
    }
}
