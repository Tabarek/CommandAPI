using System.Collections.Generic;
using CommandAPI.Models;

/// directives
namespace CommandAPI.Data{
    public interface ICommandAPIRepo{

/// Entity framework core
    bool SaveChanges();

    IEnumerable<Command> GetAllCommands();
    Command GetCommandById(int id);
    void CreateCommand(Command cmd);
    void UpdateCommand(Command cmd);
    void DeleteCommand(Command cmd);

    }
}