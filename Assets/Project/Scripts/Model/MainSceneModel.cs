using Cysharp.Threading.Tasks;
using UnityEngine;
using VRM;

namespace AvatarDetails
{
    public class MainSceneModel : MVVMModelBase
    {
        [SerializeField] private AvatarViewModel _avatar;

        /// <summary>
        /// �t�@�C������VRM�C���X�^���X��ǂݍ��݁A��������B
        /// </summary>
        /// <param name="inFilepath">�t�@�C���p�X</param>
        /// <exception cref="FileNotFoundException">inFilePath�̃t�@�C����������Ȃ�����</exception>
        /// <exception cref="NotVrm0Exception">�t�@�C���t�H�[�}�b�g��vrm�ł͂Ȃ�</exception>
        /// <returns>�������ꂽ�C���X�^���X�B</returns>
        public async UniTask ImportFromFileAsync(string inFilepath)
        {
            VRMFileImporter importer = new VRMFileImporter();
            var instance = await importer.ImportFromFileAsync(inFilepath);

            instance.Root.transform.parent = _avatar.transform;

            // �Ȃ����f�t�H���g��renderer����\���Ȃ̂ŗL����
            foreach (Renderer renderer in instance.Renderers) {
                renderer.enabled = true;
            }

            var avatarModel = instance.Root.AddComponent<AvatarModel>();
            _avatar.SetModel(avatarModel);
        }
    }
}
