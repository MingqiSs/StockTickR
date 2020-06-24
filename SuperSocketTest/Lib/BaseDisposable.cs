using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSocketTest.Lib
{
    public class BaseDisposable : IDisposable
    {
        ~BaseDisposable()
        {
            //垃圾回收器将调用该方法，因此参数需要为false。
            Dispose(false);
        }

        /// <summary>
        /// 是否已经调用了 Dispose(bool disposing)方法。
        ///     应该定义成 private 的，这样可以使基类和子类互不影响。
        /// </summary>
        private bool disposed = false;

        /// <summary>
        /// 所有回收工作都由该方法完成。
        ///     子类应重写(override)该方法。
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            // 避免重复调用 Dispose 。
            if (!disposed) return;

            // 适应多线程环境，避免产生线程错误。
            lock (this)
            {
                if (disposing)
                {
                    // ------------------------------------------------
                    // 在此处写释放托管资源的代码
                    // (1) 有 Dispose() 方法的，调用其 Dispose() 方法。
                    // (2) 没有 Dispose() 方法的，将其设为 null。
                    // 例如：
                    //     xxDataTable.Dispose();
                    //     xxDataAdapter.Dispose();
                    //     xxString = null;
                    // ------------------------------------------------
                }

                // ------------------------------------------------
                // 在此处写释放非托管资源
                // 例如：
                //     文件句柄等
                // ------------------------------------------------
                disposed = true;
            }
        }

        /// <summary>
        /// 该方法由程序调用，在调用该方法之后对象将被终结。
        ///     该方法定义在IDisposable接口中。
        /// </summary>
        public void Dispose()
        {
            //因为是由程序调用该方法的，因此参数为true。
            Dispose(true);
            //因为我们不希望垃圾回收器再次终结对象，因此需要从终结列表中去除该对象。
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 调用 Dispose() 方法，回收资源。
        /// </summary>
        public void Close()
        {
            Dispose();
        }
    }
}
