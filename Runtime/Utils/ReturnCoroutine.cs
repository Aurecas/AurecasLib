using System.Collections;
using UnityEngine;

public class ReturnCoroutine<T> : CustomYieldInstruction {
    public Coroutine coroutine { get; private set; }

    public override bool keepWaiting {
        get {
            bool mn = target.MoveNext();
            if (target.Current.GetType() == typeof(T)) {
                result = (T)target.Current;
            }

            return mn;
        }
    }


    private T result;
    private IEnumerator target;
    public ReturnCoroutine(IEnumerator target) {
        this.target = target;
    }

    public T GetResult() {
        return result;
    }

}