using SFB;

namespace AvatarDetails
{
    public class FileBrowser
    {
        public string[] OpenFile(FileBrowserOption inOption)
        {
            return StandaloneFileBrowser.OpenFilePanel(
                inOption.Title, 
                inOption.RootDirectoryPath, 
                inOption.ExtensionFilters.ToSFB(), 
                inOption.MultiSelect
            );
        }

        //public async UniTask<string[]> OpenFileAsync(FileBrowerOption inOption)
        //{
        //    string[] result = null;
        //    StandaloneFileBrowser.OpenFilePanelAsync(
        //        inOption.Title,
        //        inOption.RootDirectoryPath,
        //        inOption.ExtensionFilters,
        //        inOption.MultiSelect,
        //        pathes => result = pathes
        //    );
        //    return result;
        //}
    }
}
