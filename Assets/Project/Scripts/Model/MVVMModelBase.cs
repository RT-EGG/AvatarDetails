using UnityEngine;

namespace AvatarDetails
{
    public class MVVMModelBase : MonoBehaviour
    {
        private void Awake()
        {
            InitializeCore();
        }

        protected virtual void InitializeCore()
        {

        }
    }
}
