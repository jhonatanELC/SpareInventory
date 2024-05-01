using Core.Contracts.Infrastructure;
using Core.Contracts.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Services
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        //The following varibale will hold DbContext Instance
        public SpareInventoryDbContext Context = null;
        //The following varibale will hold the Transaction Instance
        private IDbContextTransaction _objTran = null;

        public ISpareRepository Spares { get; private set; }
        public IBrandRepository Brands { get; private set; }
        public IVehicleRepository Vehicles { get; private set; }
        public IPriceRepository Prices { get; private set; }
        public ISpareBrandRepository SpareBrands { get; private set; }

        //Initializing the Context, Spares, and Brands objects
        public UnitOfWork(SpareInventoryDbContext _Context)
        {
            Context = _Context;
            Spares = new SpareRepository(_Context);
            Brands = new BrandRepository(_Context);
            Vehicles = new VehicleRepository(_Context);
            Prices = new PriceRepository(_Context);
            SpareBrands = new SpareBrandRepository(_Context);
        }

        //If all the Transactions are completed successfully then we need to call this Commit() 
        //method to Save the changes permanently in the database
        public void Commit()
        {
            //Commits the underlying store transaction
            _objTran?.Commit();
        }

        //The CreateTransaction() method will create a database Transaction so that we can do database operations
        //by applying do everything and do nothing principle
        public void CreateTransaction()
        {
            //It will Begin the transaction on the underlying connection
            _objTran = Context.Database.BeginTransaction();
        }


        //If at least one of the Transaction is Failed then we need to call this Rollback()
        //method to Rollback the database changes to its previous state
        public void Rollback()
        {
            //Rolls back the underlying store transaction
            _objTran?.Rollback();

            //The Dispose Method will clean up this transaction object and ensures Entity Framework
            //is no longer using that transaction.
            _objTran?.Dispose();
        }

        //The Save() Method will Call the DbContext Class SaveChanges method 
        //So whenever we do a transaction we need to call this Save() method 
        //so that it will make the changes in the database permanently
        public async Task Save()
        {
            try
            {
                //Calling DbContext Class SaveChanges method 
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Handle the exception, possibly logging the details
                // The InnerException often contains more specific details
                throw new Exception(ex.Message, ex);
            }
        }


        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
