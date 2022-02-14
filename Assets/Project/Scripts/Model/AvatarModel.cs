using UnityEngine;

namespace AvatarDetails
{
    [RequireComponent(typeof(AvatarMetaModel))]
    public class AvatarModel : MVVMModelBase
    {
        public AvatarMetaModel Meta
        { get; private set; } = null;

        protected override void InitializeCore()
        {
            base.InitializeCore();

            Meta = GetComponent<AvatarMetaModel>();
        }
    }
}
