using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace AvatarDetails
{
    public class AvatarMetaViewModel : MVVMViewModelBase<AvatarMetaModel>
    {
        protected override IEnumerable<IDisposable> Subscribe(AvatarMetaModel inNewModel)
        {
            foreach (var item in base.Subscribe(inNewModel)) {
                yield return item;
            }
            yield return inNewModel.Title.Subscribe(v => Title.Value = v);
        }

        public StringReactiveProperty Title
        { get; } = new StringReactiveProperty();
    }
}
