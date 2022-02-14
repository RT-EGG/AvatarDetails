using Cysharp.Threading.Tasks;
using System.IO;
using UniGLTF;
using VRM;

namespace AvatarDetails
{
    public class VRMFileImporter
    {
        /// <summary>
        /// �t�@�C������VRM�C���X�^���X��ǂݍ��݁A��������B
        /// </summary>
        /// <param name="inFilepath">�t�@�C���p�X</param>
        /// <exception cref="FileNotFoundException">inFilePath�̃t�@�C����������Ȃ�����</exception>
        /// <exception cref="NotVrm0Exception">�t�@�C���t�H�[�}�b�g��vrm�ł͂Ȃ�</exception>
        /// <returns>�������ꂽ�C���X�^���X�B</returns>
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
