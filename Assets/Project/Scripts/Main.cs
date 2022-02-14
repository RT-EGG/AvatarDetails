using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace AvatarDetails
{
    public class Main : MonoBehaviour
    {
        // Start is called before the first frame update
        async UniTask Start()
        {
            await InitializeAsync();

            UpdateLoop(this.GetCancellationTokenOnDestroy()).Forget();
        }

        private async UniTask InitializeAsync()
        {
            await UniTask.Yield();
        }

        private async UniTaskVoid UpdateLoop(CancellationToken inCancellationToken)
        {
            while (!inCancellationToken.IsCancellationRequested) {
                await UniTask.Yield(PlayerLoopTiming.Update, inCancellationToken);
            }
        }
    }
}
