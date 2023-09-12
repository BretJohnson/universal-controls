using System;
using System.Collections.Generic;

namespace Microsoft.ComponentModelEx.ReactiveData
{
    public static class Transaction
    {
        [ThreadStatic] private static HashSet<ChangedEventHandler>? _reactionsToNotify;

        public static void Start()
        {
            _reactionsToNotify = new HashSet<ChangedEventHandler>();
        }

        public static void AddToNotify(ChangedEventHandler changedEventHandler)
        {
            _reactionsToNotify!.Add(changedEventHandler);
        }

        /// <summary>
        /// Finish a transaction, committing it and sending Changed notifications for everything that may have changed.
        ///
        /// Note that ReactiveData doesn't provide support for aborting transactions and undoing changes already made.
        /// If the client wants that functionality, they can implement it themselves, setting data back to its original
        /// value before calling End.
        /// </summary>
        public static void End()
        {
            foreach (ChangedEventHandler changedEventHandler in _reactionsToNotify!)
                changedEventHandler.Invoke();
            _reactionsToNotify = null;
        }

        public static void Run(Action action)
        {
            Start();
            action.Invoke();
            End();
        }

        public static void EnsureInTransaction()
        {
            if (_reactionsToNotify == null)
                throw new InvalidOperationException("Reactive data can only be modified inside a transaction. Use Transaction.Start / Transaction.Complete around updates.");
        }
    }
}
