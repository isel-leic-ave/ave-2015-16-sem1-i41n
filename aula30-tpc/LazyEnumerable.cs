using System;
using System.Collections;
using System.Collections.Generic;

public class LazyEnumerable<T, R>: IEnumerable<R>
{
    IEnumerable<T> src;
    Func<T, R> transf;
    Predicate<T> pred;
    Func<bool> finish;

    public LazyEnumerable(IEnumerable<T> src, Func<T, R> transf, Predicate<T> p, Func<bool> finish)
    {
        this.src = src;
        this.transf = transf;
        this.pred = p;
        this.finish = finish;
    }

 
    public IEnumerator<R> GetEnumerator()
    {
        return new LazyEnumerator<T, R>(src.GetEnumerator(), transf, pred, finish);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new LazyEnumerator<T, R>(src.GetEnumerator(), transf, pred, finish);
    }
}
