using Cysharp.Threading.Tasks;
using System.IO;
using UniGLTF;
using VRM;

namespace AvatarDetails
{
    public class VRMFileImporter
    {
        /// <summary>
        /// ファイルからVRMインスタンスを読み込み、生成する。
        /// </summary>
        /// <param name="inFilepath">ファイルパス</param>
        /// <exception cref="FileNotFoundException">inFilePathのファイルが見つからなかった</exception>
        /// <exception cref="NotVrm0Exception">ファイルフォーマットがvrmではない</exception>
        /// <returns>生成されたインスタンス。</returns>
        public async UniTask<RuntimeGltfInstance> ImportFromFileAsync(string inFilepath)
        {
            if (!File.Exists(inFilepath)) {
                throw new FileNotFoundException($"File \"{inFilepath}\" not found.", inFilepath);
            }

            GltfData data = new AutoGltfFileParser(inFilepath).Parse();

            VRMData vrmData = new VRMData(data);
            using (VRMImporterContext loader = new VRMImporterContext(vrmData)) {
                RuntimeGltfInstance instance = await loader.LoadAsync();

                return instance;
            }

            /*
            catch (NotVrm0Exception)
            {
                // retry
                Debug.LogWarning("file extension is vrm. but not vrm ?");
                using (var loader = new UniGLTF.ImporterContext(data, materialGenerator: GetGltfMaterialGenerator(m_useUrpMaterial.isOn)))
                {
                    var instance = await loader.LoadAsync(GetIAwaitCaller(m_useAsync.isOn));
                    SetModel(instance);
                }
            }
            */
        }
    }
}
