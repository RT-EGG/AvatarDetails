using Cysharp.Threading.Tasks;
using UnityEngine;
using VRM;

namespace AvatarDetails
{
    public class MainSceneModel : MVVMModelBase
    {
        [SerializeField] private AvatarViewModel _avatar;

        /// <summary>
        /// ファイルからVRMインスタンスを読み込み、生成する。
        /// </summary>
        /// <param name="inFilepath">ファイルパス</param>
        /// <exception cref="FileNotFoundException">inFilePathのファイルが見つからなかった</exception>
        /// <exception cref="NotVrm0Exception">ファイルフォーマットがvrmではない</exception>
        /// <returns>生成されたインスタンス。</returns>
        public async UniTask ImportFromFileAsync(string inFilepath)
        {
            VRMFileImporter importer = new VRMFileImporter();
            var instance = await importer.ImportFromFileAsync(inFilepath);

            instance.Root.transform.parent = _avatar.transform;

            // なぜかデフォルトでrendererが非表示なので有効可
            foreach (Renderer renderer in instance.Renderers) {
                renderer.enabled = true;
            }

            var avatarModel = instance.Root.AddComponent<AvatarModel>();
            _avatar.SetModel(avatarModel);
        }
    }
}
