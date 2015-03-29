using System;
using System.Collections.Generic;

namespace HipChat
{
    /// <summary>
    /// Provide a simplified interface to the HipChatClient for normal usages.
    /// </summary>
    public interface IHipChatAPI
    {
        /// <summary>
        /// Retrieves a list of all rooms that the API key has access to
        /// </summary>
        IList<Entities.Room> GetRooms();

        /// <summary>
        /// Retrieves the last 75 messages sent in the room.
        /// </summary>
        IList<Entities.Message> GetRoomHistory(int RoomID);

        /// <summary>
        /// Retrieves the chat history for the room for the given day
        /// </summary>
        IList<Entities.Message> GetRoomHistory(int RoomID, DateTime Date);

        void SendMessage(int RoomID, String From, String Message);
    }
}