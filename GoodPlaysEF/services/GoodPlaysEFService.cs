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

        #endregion

        #region Delete

        #endregion
    }
}
