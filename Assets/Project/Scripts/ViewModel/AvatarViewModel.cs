using System;
using System.Collections.Generic;
using UnityEngine;

namespace AvatarDetails
{
    [RequireComponent(typeof(AvatarMetaViewModel))]
    public class AvatarViewModel : MVVMViewModelBase<AvatarModel>
    {
        private AvatarMetaViewModel Meta
        { get; set; }

        protected override void SetModelCore(AvatarModel inValue)
        {
            base.SetModelCore(inValue);

            Meta.SetModel(inValue.Meta);
        }

        protected override IEnumerable<IDisposable> Subscribe(AvatarModel inNewModel)
        {
            foreach (var item in base.Subscribe(inNewModel)) {
                yield return item;
            }
        }

        private void Awake()
        {
            Meta = GetComponent<AvatarMetaViewModel>();
        }
    }
}
