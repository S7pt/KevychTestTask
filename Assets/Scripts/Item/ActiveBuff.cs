using ScriptableObjects;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;

namespace Item
{
    public class ActiveBuff
    {
        private ItemConfig config;
        private CancellationTokenSource cancellationTokenSource;
        private Action<ActiveBuff> Completed;

        public ItemConfig Config => config;

        public ActiveBuff(ItemConfig config, Action<ActiveBuff> Completed)
        {
            this.config = config;
            this.Completed = Completed;
            cancellationTokenSource = new CancellationTokenSource();
            HandleLifecycle();
        }

        public async UniTask HandleLifecycle()
        {
            try
            {
                await UniTask.WaitForSeconds(Config.Duration, cancellationToken: cancellationTokenSource.Token);

                Completed?.Invoke(this);
            }
            catch (OperationCanceledException)
            {
            }
        }

        public void Refresh()
        {
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
            cancellationTokenSource = new CancellationTokenSource();

            HandleLifecycle().Forget();
        }

        public void Cancel()
        {
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
        }
    }
}