using System;
using System.Collections.Generic;
using UnityEngine;

namespace AvatarDetails
{
    public class MVVMViewBase<ViewModelType, ModelType> : MonoBehaviour 
        where ViewModelType : MVVMViewModelBase<ModelType>
        where ModelType : MVVMModelBase
    {
        [SerializeField] ViewModelType _viewModel;
        protected ViewModelType ViewModel => _viewModel;

        /// <summary>
        /// UI操作時などのイベントを登録する
        /// </summary>
        protected virtual void RegisterEvents()
        {

        }

        /// <summary>
        /// ViewModelからの通知の受け取りを登録する。
        /// </summary>
        /// <param name="inNewViewModel">対応する新規ViewModel</param>
        /// <returns>ReactivePropertyの購読インスタンス</returns>
        protected virtual IEnumerable<IDisposable> Subscribe(ViewModelType inNewViewModel)
        {
            yield break;
        }

        private void Awake()
        {
            RegisterEvents();
            _viewModelSubscription.AddRange(Subscribe(ViewModel));
        }

        private List<IDisposable> _viewModelSubscription = new List<IDisposable>();
    }
}
