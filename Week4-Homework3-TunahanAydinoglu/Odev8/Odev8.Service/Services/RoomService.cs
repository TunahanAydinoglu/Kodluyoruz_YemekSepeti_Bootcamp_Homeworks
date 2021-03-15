using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Odev8.Data.Context;
using Odev8.Service.Dtos.Derived;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev8.Service.Services
{
    public class RoomService : IRoomService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public RoomService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<List<RoomDto>> GetRoomsAsync()
        {
            var roomEntities = await _context.Rooms.ToListAsync();
            var result = roomEntities.Select(room => _mapper.Map<RoomDto>(room))
                                     .ToList();

            return result;
        }
        public async Task<RoomDto> GetRoomAsync(Guid id)
        {
            var roomEntity = await _context.Rooms.SingleOrDefaultAsync(room => room.Id == id);
            if (roomEntity == null)
                return null;

            return _mapper.Map<RoomDto>(roomEntity);

        }


    }
}
