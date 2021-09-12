using System.Collections.Generic;
using System.Linq;
using CommandAPI.Models;

namespace CommandAPI.Data{
    public class SqlCommandAPIRepo : ICommandAPIRepo
    {

        //use Constructor Dependency Injection to inject our DB Context into our SqlCommandAPIRepo class
        private readonly CommandContext _context;
        public SqlCommandAPIRepo(CommandContext context)
        {
            _context = context;
        }
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            //We reference “CommandItems” on our DB Context (_context) and return as a List of Command objects
            
            return _context.CommandItems.ToList();
        }

        public Command GetCommandById(int id)
        {
            // call the FirstOrDefault method on our “CommandItems” to return a Command object (if one exists) that matches our desired ID
            return _context.CommandItems.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}