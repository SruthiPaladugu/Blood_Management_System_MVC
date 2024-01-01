using BloodManagementSystem_API_.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BloodManagementSystem_API_.Models
{
        public interface IBloodAppContext : IDisposable
        {
            DbSet<Donor> Donors { get; }
            int SaveChanges();
            void MarkAsModified(Donor item);
        }
    }
