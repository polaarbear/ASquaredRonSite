using ASquaredRonModels.Models;

namespace ASquaredRonDB.Contexts
{
    public interface IDbAccessContext
    {
        Task<int> SaveContact(ContactMeModel contactModel);
    }
}