using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SerProje.ContextSer;
using SerProje.Repository;
using SerProje.Class;
using System.Data.SqlClient;
using SerProje.NewClasses;

namespace SerProje.UnitOfWork
{
    public class SerUnitOfWork : IUnitOfWork
    {
        private SerProjeDB dbContext_ = new SerProjeDB();
        private SerProjectRepository<KisiBilgileri> _kisiBilgisiRepository;
        private SerProjectRepository<EgitimBilgileri> _egitimBilgisiRepository;
        private SerProjectRepository<SonEgitimBilgisi> _sonOkulRepository;
        private SerProjectRepository<BagliKisiler> _parentKisiRepository;
        //private SerProjectRepository<BagliKisiler> _parentKisiRepository;
        private bool _disposed = false;

        public SerProjectRepository<KisiBilgileri> KisiBilgisiRepository
        {
            get
            {
                if (_kisiBilgisiRepository == null)
                    _kisiBilgisiRepository = new SerProjectRepository<KisiBilgileri>(dbContext_); //dbContext_ 
                return _kisiBilgisiRepository;
            }
        }

        public SerProjectRepository<EgitimBilgileri> EgitimBilgisiRepository
        {
            get
            {
                if (_egitimBilgisiRepository == null)
                    _egitimBilgisiRepository = new SerProjectRepository<EgitimBilgileri>(dbContext_);
                return _egitimBilgisiRepository;
            }
        }

        public SerProjectRepository<SonEgitimBilgisi> SonOkulRepository
        {
            get
            {
                if (_sonOkulRepository == null)
                    _sonOkulRepository = new SerProjectRepository<SonEgitimBilgisi>(dbContext_);
                return _sonOkulRepository;
            }
        }

        public SerProjectRepository<BagliKisiler> ParentKisiRepository
        {
            get
            {
                if (_parentKisiRepository == null)
                    _parentKisiRepository = new SerProjectRepository<BagliKisiler>(dbContext_);
                return _parentKisiRepository;
            }
        }

        public void Save()
        {
            using(var dbCntx = new SerProjeDB())
            {
                using(var transaction = dbCntx.Database.BeginTransaction())
                {
                    try
                    {
                        //database
                        
                        dbContext_.SaveChanges();

                        transaction.Commit();
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                    }
                    
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    dbContext_.Dispose();
                }
            }
            this._disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
