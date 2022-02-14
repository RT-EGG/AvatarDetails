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
        /// UI���쎞�Ȃǂ̃C�x���g��o�^����
        /// </summary>
        protected virtual void RegisterEvents()
        {

        }

        /// <summary>
        /// ViewModel����̒ʒm�̎󂯎���o�^����B
        /// </summary>
        /// <param name="inNewViewModel">�Ή�����V�KViewModel</param>
        /// <returns>ReactiveProperty�̍w�ǃC���X�^���X</returns>
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
