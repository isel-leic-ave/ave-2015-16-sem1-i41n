using System;
using System.Collections;
using System.Collections.Generic;

public class LazyEnumerator<T, R> : IEnumerator<R>
{
    readonly IEnumerator<T> src;
    readonly Func<T, R> transf;
    readonly Predicate<T> pred;
    readonly Func<bool> finish;

    public LazyEnumerator(IEnumerator<T> src, Func<T, R> transf, Predicate<T> p, Func<bool> finish)
    {
        this.src = src;
        this.transf = transf;
        this.pred = p;
        this.finish = finish;
    }

    public R Current
    {
        get { return transf(src.Current); }
    }

    object IEnumerator.Current
    {
        get { return this.Current; }
    }

    public bool MoveNext()
    {
        while(!finish() && src.MoveNext()){
            if (pred(src.Current))
                return true;
        }
        return false;
    }

    public void Reset() { src.Reset(); }
    public void Dispose() { src.Dispose(); }


}
