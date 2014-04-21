using System;

namespace Core
{
   public class RepositoryBase<T> : IDisposable  where T : class, IDisposable, new() {

        public T DbContext { get; set; }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    if(DbContext != null)
                        DbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
