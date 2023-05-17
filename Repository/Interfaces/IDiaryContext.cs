using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repository.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IDiaryContext
    {
        DbSet<Group> Groups { get;  }

        DbSet<Lesson> Lessons { get; }

        DbSet<School> Schools { get; }

        DbSet<Student> Students { get; }

        DbSet<User> Users { get; }

        DbSet<StudentExistance> StudentExistances { get; }

        DbSet<Unit> Units { get; }

        int SaveChanges();
         
      
        EntityEntry<TEntity> Add<TEntity>(TEntity entity) where TEntity : class;


        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
         



    }
}
