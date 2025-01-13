using AutoMapper;
using BasicCRUD.Application.Services;
using BasicCRUD.Domain.DTOs.User;
using BasicCRUD.Domain.Models;
using BasicCRUD.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BasicCRUD.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IGenericService<User> _userService;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IGenericService<User> userService, IMapper mapper, ILogger<UsersController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _userService.GetAllAsync();

                var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);

                return Ok(ResponseModel<IEnumerable<UserDto>>.SuccessResponse(userDtos, "Users retrieved successfully."));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving users.");

                return StatusCode(500, ResponseModel<object>.ErrorResponse("An error occurred while retrieving users."));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _userService.GetByIdAsync(id);

                if (user == null)
                    return NotFound(ResponseModel<object>.ErrorResponse("User not found."));

                var userDto = _mapper.Map<UserDto>(user);

                return Ok(ResponseModel<UserDto>.SuccessResponse(userDto, "User retrieved successfully."));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving user with ID: {id}.");

                return StatusCode(500, ResponseModel<object>.ErrorResponse("An error occurred while retrieving the user."));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDto createUserDto)
        {
            try
            {
                var newUser = _mapper.Map<User>(createUserDto);

                var createdUser = await _userService.AddAsync(newUser);

                var createdUserDto = _mapper.Map<UserDto>(createdUser);

                return CreatedAtAction(nameof(GetById), new { id = createdUser.Id },
                    ResponseModel<string>.SuccessResponse("User created successfully."));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating the user.");

                return StatusCode(500, ResponseModel<object>.ErrorResponse("An error occurred while creating the user."));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateUserDto updateUserDto)
        {
            try
            {
                var existingUser = await _userService.GetByIdAsync(id);

                if (existingUser == null)
                    return NotFound(ResponseModel<object>.ErrorResponse("User not found."));

                _mapper.Map(updateUserDto, existingUser);

                var updatedUser = await _userService.UpdateAsync(existingUser);

                var updatedUserDto = _mapper.Map<UserDto>(updatedUser);

                return Ok(ResponseModel<UserDto>.SuccessResponse(updatedUserDto, "User updated successfully."));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating the user with ID: {id}.");

                return StatusCode(500, ResponseModel<object>.ErrorResponse("An error occurred while updating the user."));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _userService.DeleteAsync(id);

                if (!result)
                    return NotFound(ResponseModel<object>.ErrorResponse("User not found."));

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting the user with ID: {id}.");

                return StatusCode(500, ResponseModel<object>.ErrorResponse("An error occurred while deleting the user."));
            }
        }

        [HttpGet("paginated")]
        public async Task<IActionResult> GetPaginated(int page = 1, int pageSize = 10)
        {
            try
            {
                var users = await _userService.GetPaginatedAsync(page, pageSize);

                var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);

                return Ok(ResponseModel<IEnumerable<UserDto>>.SuccessResponse(userDtos, "Paginated users retrieved successfully."));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving paginated users.");

                return StatusCode(500, ResponseModel<object>.ErrorResponse("An error occurred while retrieving paginated users."));
            }
        }
    }
}
