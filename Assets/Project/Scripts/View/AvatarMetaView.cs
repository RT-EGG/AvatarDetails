using System;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;

namespace AvatarDetails
{
    public class AvatarMetaView : MVVMViewBase<AvatarMetaViewModel, AvatarMetaModel>
    {
        [SerializeField] private TMP_InputField _inputFiledTitle;
        private TMP_InputField InputFieldTitle => _inputFiledTitle;

        protected override void RegisterEvents()
        {
            base.RegisterEvents();

            InputFieldTitle.onValueChanged.AsObservable().Subscribe(text => ViewModel.Title.Value = text);
        }

        protected override IEnumerable<IDisposable> Subscribe(AvatarMetaViewModel inNewViewModel)
        {
            foreach (var item in base.Subscribe(inNewViewModel)) {
                yield return item;
            }

            yield return inNewViewModel.Title.Subscribe(v => InputFieldTitle.text = v);
        }
    }
}
