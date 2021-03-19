using Odev8.Service.Dtos.Derived;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Odev8.Service.Services
{
    public interface IRoomService
    {
        Task<List<RoomDto>> GetRoomsAsync();

        Task<RoomDto> GetRoomAsync(Guid id);
    }
}
