using UnityEngine;

namespace AvatarDetails
{
    [System.Serializable]
    public class FileBrowserOption
    {
        [SerializeField] string _title = "";
        [SerializeField] FileBrowserExtensionFilter[] _extensionFilters = new FileBrowserExtensionFilter[]{ };
        [SerializeField] string _rootDirectoryPath = "";
        [SerializeField] bool _multiSelect = false;

        public string Title => _title;
        public FileBrowserExtensionFilter[] ExtensionFilters => _extensionFilters;
        public string RootDirectoryPath => _rootDirectoryPath;
        public bool MultiSelect => _multiSelect;
    }
}
