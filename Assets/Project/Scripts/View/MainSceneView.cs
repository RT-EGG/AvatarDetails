using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace AvatarDetails
{
    public class MainSceneView : MVVMViewBase<MainSceneViewModel, MainSceneModel>
    {
        [Inject] FileBrowser _fileBrowser;
        private FileBrowser FileBrowser => _fileBrowser;

        [SerializeField] FileBrowserOption _importFileBrowserOption = new FileBrowserOption();
        private FileBrowserOption ImportFileBrowserOption => _importFileBrowserOption;

        [SerializeField] private Button _buttonImportFromFile;
        private Button ButtonImportFromFile => _buttonImportFromFile;

        protected override void RegisterEvents()
        {
            base.RegisterEvents();

            ButtonImportFromFile.OnClickAsObservable()
                .Subscribe(async _ => {
                    if (FileBrowser != null) {
                        if (FileBrowser.OpenFile(ImportFileBrowserOption).TryGetFirst(out string path, _ => true)) {

                            if (ViewModel != null) {
                                await ViewModel.ImportFromFileAsync(path);
                            }
                        }

                        Debug.Log($"{path}");
                    }
                });
        }

        protected override IEnumerable<IDisposable> Subscribe(MainSceneViewModel inNewViewModel)
        {
            foreach (var item in base.Subscribe(inNewViewModel)) {
                yield return item;
            }
        }
    }
}
