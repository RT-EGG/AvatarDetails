using System;
using System.Collections.Generic;
using UnityEngine;

namespace AvatarDetails
{
    public class MVVMViewModelBase<T> : MonoBehaviour where T : MVVMModelBase
    {
        /// <summary>
        /// Model��ύX����
        /// </summary>
        /// <param name="inValue">�V����Model</param>
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
        /// Model�ύX���̒ǉ�����
        /// </summary>
        /// <param name="inValue">�V����Model</param>
        protected virtual void SetModelCore(T inValue)
        {

        }

        /// <summary>
        /// View����̒ʒm�̎󂯎���o�^����B
        /// </summary>
        /// <param name="inNewModel">�Ή�����V�KModel</param>
        /// <returns>ReactiveProperty�̍w�ǃC���X�^���X</returns>
        protected virtual IEnumerable<IDisposable> Subscribe(T inNewModel)
        {
            yield break;
        }

        [SerializeField] private T _model;
        protected T Model => _model;
        private List<IDisposable> _modelSubscription = new List<IDisposable>();
    }
}
