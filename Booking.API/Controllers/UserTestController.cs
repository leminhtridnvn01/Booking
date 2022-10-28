using Booking.API.InterationEvents.Events;
using Booking.Domain.Entities;
using Booking.Domain.Interfaces;
using Booking.Domain.Interfaces.Repositories;
using EventBus.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Booking.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserTestController : ControllerBase
    {
        private readonly IUserTestRepository _userRepository;
        private readonly IRoomTestRepository _roomRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventBus _eventBus;
        public UserTestController(IUserTestRepository userRepository
            , IRoomTestRepository roomRepository
            , IUnitOfWork unitOfWork
            , IEventBus eventBus)
        {
            _userRepository = userRepository;
            _roomRepository = roomRepository;
            _unitOfWork = unitOfWork;
            _eventBus = eventBus;

        }
        [HttpGet("get-all")]
        public IList<UserTest> GetAll()
        {
            return _userRepository.GetAll();
        }

        [HttpGet("get-no-all")]
        public async Task<IList<RoomTest>> GetNoAll()
        {
            var user = await _userRepository.FindAsync(2);
           
            await _unitOfWork.SaveChangeAsync();
            _eventBus.Publish(new UserCreatedIntergrationEvent(2, user.Name));
            return await _roomRepository.GetAllAsync();
        }

        [HttpGet("id")]
        public async Task<UserTest> Get()
        {
            return await _userRepository.FindAsync(1);
        }

    }
}
