using ASquaredRonDB.Access;
using ASquaredRonModels.Models;

namespace ASquaredRonDB.Contexts
{
    public class DbAccessContext : IDbAccessContext
    {
        private IDbAccess _dbAccess;

        public DbAccessContext(IDbAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }

        public async Task<int> SaveContact(ContactMeModel contactModel)
        {
            int contactID = await CheckDuplicate(contactModel);
            if (contactID == -1)
            {
                contactID = await _dbAccess.SaveData(
                "INSERT INTO Contacts (FullName, Email) VALUES (@FullName, @Email) RETURNING ID;"
                , contactModel
                , "ASquareDB");
                contactModel.ContactId = contactID;
            }
            
            await _dbAccess.SaveData(
                "INSERT INTO Messages (ContactID, Message) VALUES (@ContactId, @Message);"
                , contactModel
                , "ASquareDB");
            return contactModel.ContactId;
        }

        private async Task<int> CheckDuplicate(ContactMeModel contactModel)
        {
            int contactID = await _dbAccess.SaveData<ContactMeModel>("SELECT ID FROM Contacts WHERE Email = @Email", contactModel, "ASquareDB");
            if (contactID > 0)
            {
                contactModel.ContactId = contactID;
                return contactID;
            }
            else
                return -1;
        }
    }
}
