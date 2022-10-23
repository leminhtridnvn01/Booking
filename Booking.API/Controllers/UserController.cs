using Booking.Domain.Entities;
using Booking.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoomRepository _roomRepository;
        public UserController(IUserRepository userRepository, IRoomRepository roomRepository)
        {
            _userRepository = userRepository;
            _roomRepository = roomRepository;

        }
        [HttpGet("get-all")]
        public IList<User> GetAll()
        {
            return _userRepository.GetAll();
        }

        [HttpGet("get-no-all")]
        public async Task<IList<Room>> GetNoAll()
        {
            return await _roomRepository.GetAllAsync();
        }

        [HttpGet("id")]
        public async Task<User> Get()
        {
            return await _userRepository.FindAsync(1);
        }

    }
}
