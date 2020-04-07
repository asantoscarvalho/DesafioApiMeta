using System;
using Contatos.Domain;
using Microsoft.EntityFrameworkCore;

namespace Contatos.Repository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base (options)  {}

        public DbSet<Contato> Contatos {get; set;}

    }
}
