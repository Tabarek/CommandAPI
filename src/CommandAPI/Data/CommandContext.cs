using Microsoft.EntityFrameworkCore;
using CommandAPI.Models;

namespace CommandAPI.Data
{
    ///[DbContext] data representation class between the model and database
    public class CommandContext : DbContext{
        public CommandContext(DbContextOptions<CommandContext> options) : base(options){

        }

        /// [DbSet] representation of table in the database
        /// We are telling or [DbContext] we want to "model" our commands in the database(store them as a table) 
        public DbSet<Command> CommandItems{get; set;}
    }
}