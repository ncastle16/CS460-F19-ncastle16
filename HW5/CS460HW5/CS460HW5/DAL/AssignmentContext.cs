using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using CS460HW5.Models;

namespace CS460HW5.DAL
{
    public class AssignmentContext : DbContext
    {
        public AssignmentContext() : base("name=Database")
        {

        }

        public virtual DbSet<Assignment> Assignments { get; set; }
    }
}