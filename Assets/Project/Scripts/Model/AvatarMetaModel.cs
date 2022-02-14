using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using VRM;

namespace AvatarDetails
{
    public class AvatarMetaModel : MVVMModelBase
    {
        //public AvatarMetaModel(VRMMetaObject inValue)
        //{
        //    _metaObject = inValue;

        //    Title.Value = _metaObject.Title;
        //}

        protected override void InitializeCore()
        {
            base.InitializeCore();

            _metaObject = GetComponent<VRMMeta>().Meta;

            Title.Value = _metaObject.Title;
        }

        public ReactiveProperty<string> Title
        { get; } = new ReactiveProperty<string>();

        private VRMMetaObject _metaObject = null;
    }
}
