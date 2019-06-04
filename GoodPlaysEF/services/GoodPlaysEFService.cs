using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodPlaysEF.services {
    public class GoodPlaysEFService {
        #region Create
        /// <summary>
        /// Creates a new user in the database and returns their ID.
        /// </summary>
        /// <param name="firstName">The user's first name.</param>
        /// <param name="lastName">The user's last name.</param>
        /// <param name="email">The user's email address.</param>
        /// <returns>The user's UserID.</returns>
        public string CreateUser(string firstName, string lastName, string email) {
            using (var context = new GoodPlaysEntities()) {
                User user = new User() {
                    UserID = Guid.NewGuid().ToString(),
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email
                };
                context.Users.Add(user);
                context.SaveChanges();
                return user.UserID;
            }
        }

        /// <summary>
        /// Adds a game to a user's list and returns the ListItemID.
        /// </summary>
        /// <param name="userID">The user's ID.</param>
        /// <param name="listType">The list type to add to.</param>
        /// <param name="gameID">The game's id on IGDB.</param>
        /// <returns>The ListItem's ID.</returns>
        public int AddListItemToUser(string userID, int listType, int gameID) {
            using (var context = new GoodPlaysEntities()) {
                ListItem listItem = new ListItem() {
                    ListType1 = context.ListTypes.Single(lt => lt.ListTypeID == listType),
                    GameID = gameID
                };
                User user = context.Users.Single(u => u.UserID == userID);
                user.ListItems.Add(listItem);
                context.SaveChanges();
                return listItem.ListItemID;
            }
        }
        #endregion

        #region Read
        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="userID">The user's ID.</param>
        /// <returns>The user.</returns>
        public User GetUserByID(string userID) {
            using (var context = new GoodPlaysEntities()) {
                return context.Users.Single(u => u.UserID == userID);
            }
        }

        /// <summary>
        /// Retrieves a list of all users who have a specified game in their list.
        /// </summary>
        /// <param name="gameID"></param>
        /// <returns></returns>
        public List<User> GetUsersByGame(int gameID) {
            using (var context = new GoodPlaysEntities()) {
                return context.ListItems.Where(li => li.GameID == gameID).Select(li => li.User).Distinct().ToList();
            }
        }

        /// <summary>
        /// Retrieves a list item by its ID.
        /// </summary>
        /// <param name="listItemId">The list item's ID.</param>
        /// <returns>The list item.</returns>
        public ListItem GetListItemByID(int listItemId) {
            using (var context = new GoodPlaysEntities()) {
                return context.ListItems.Single(li => li.ListItemID == listItemId);
            }
        }

        /// <summary>
        /// Retrieves a list from one user by their ID.
        /// </summary>
        /// <param name="userID">The user's ID.</param>
        /// <returns>The user's list.</returns>
        public List<ListItem> GetListByUserID(string userID) {
            using (var context = new GoodPlaysEntities()) {
                return context.Users.Single(u => u.UserID == userID).ListItems.ToList();
            }
        }

        /// <summary>
        /// Retrieves a list from one user by their ID, filtered by list type.
        /// </summary>
        /// <param name="userID">The user's ID.</param>
        /// <param name="listType">The list type to filter by.</param>
        /// <returns>The user's list.</returns>
        public List<ListItem> GetListByUserID(string userID, int listType) {
            using (var context = new GoodPlaysEntities()) {
                return context.Users.Single(u => u.UserID == userID).ListItems
                    .Where(li => li.ListType == listType).ToList();
            }
        }

        /// <summary>
        /// Retrieves a list type by its ID.
        /// </summary>
        /// <param name="listTypeId">The list type's ID.</param>
        /// <returns>The list type.</returns>
        public ListType GetListTypeById(int listTypeId) {
            using (var context = new GoodPlaysEntities()) {
                return context.ListTypes.Single(lt => lt.ListTypeID == listTypeId);
            }
        }

        /// <summary>
        /// Retrieves a list type by its name.
        /// </summary>
        /// <param name="listTypeId">The list type's name.</param>
        /// <returns>The list type.</returns>
        public ListType GetListTypeByName(string listTypeName) {
            using (var context = new GoodPlaysEntities()) {
                return context.ListTypes.Single(lt => lt.ListTypeName == listTypeName);
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// Updates the values of a user with a specific ID.
        /// </summary>
        /// <param name="userID">The ID of the user to be updated.</param>
        /// <param name="firstName">The new value of the user's first name.</param>
        /// <param name="lastName">The new value of the user's last name.</param>
        /// <param name="email">The new value of the user's email address.</param>
        public void UpdateUserById(string userID, string firstName = null, string lastName = null, string email = null) {
            using (var context = new GoodPlaysEntities()) {
                User user = context.Users.Single(u => u.UserID == userID);
                user.FirstName = firstName ?? user.FirstName;
                user.LastName = lastName ?? user.LastName;
                user.Email = email ?? user.Email;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Updates the values of a list item with a specific ID.
        /// </summary>
        /// <param name="listItemID">The ID of the list item to be updated.</param>
        /// <param name="listType">The new list type.</param>
        /// <param name="gameID">The new game ID.</param>
        public void UpdateListItemById(int listItemID, int? listType = null, int? gameID = null) {
            using (var context = new GoodPlaysEntities()) {
                ListItem listItem = context.ListItems.Single(li => li.ListItemID == listItemID);
                listItem.ListType = listType ?? listItem.ListType;
                listItem.GameID = gameID ?? listItem.GameID;
                context.SaveChanges();
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// Deletes a single user with a specific ID.
        /// </summary>
        /// <param name="userID">The ID of the user to be deleted.</param>
        public void DeleteUserByID(string userID) {
            using (var context = new GoodPlaysEntities()) {
                context.Users.Remove(context.Users.Single(u => u.UserID == userID));
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes a single list item with a specific ID.
        /// </summary>
        /// <param name="listItemID">The ID of the list item to be deleted.</param>
        public void DeleteListItemByID(int listItemID) {
            using (var context = new GoodPlaysEntities()) {
                context.ListItems.Remove(context.ListItems.Single(li => li.ListItemID == listItemID));
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes all list items that reference a specific user's ID.
        /// </summary>
        /// <param name="userID">The ID of the user whose list will be deleted.</param>
        public void DeleteListByUserID(string userID) {
            using (var context = new GoodPlaysEntities()) {
                List<ListItem> listItems = context.ListItems.Where(li => li.UserID == userID).ToList();
                listItems.ForEach(li => context.ListItems.Remove(li));
                context.SaveChanges();
            }
        }
        #endregion
    }
}
