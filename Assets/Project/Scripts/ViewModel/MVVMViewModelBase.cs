using System;
using System.Collections.Generic;
using UnityEngine;

namespace AvatarDetails
{
    public class MVVMViewModelBase<T> : MonoBehaviour where T : MVVMModelBase
    {
        /// <summary>
        /// Modelを変更する
        /// </summary>
        /// <param name="inValue">新しいModel</param>
        public void SetModel(T inValue)
        {
            _modelSubscription.DisposeAndClear();

            _model = inValue;

            SetModelCore(_model);
            if (_model != null) {
                _modelSubscription.AddRange(Subscribe(Model));
            }
        }

        /// <summary>
        /// Model変更時の追加処理
        /// </summary>
        /// <param name="inValue">新しいModel</param>
        protected virtual void SetModelCore(T inValue)
        {

        }

        /// <summary>
        /// Viewからの通知の受け取りを登録する。
        /// </summary>
        /// <param name="inNewModel">対応する新規Model</param>
        /// <returns>ReactivePropertyの購読インスタンス</returns>
        protected virtual IEnumerable<IDisposable> Subscribe(T inNewModel)
        {
            yield break;
        }

        [SerializeField] private T _model;
        protected T Model => _model;
        private List<IDisposable> _modelSubscription = new List<IDisposable>();
    }
}
