using Padrrif.Dto;

namespace Padrrif.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthController(IAuthUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
           
            UserLoginDto? UserLoginDto = await _unitOfWork.Login(request); 

            if (UserLoginDto?.Value!= null || UserLoginDto?.ExpireAt != null) 
                return Ok(UserLoginDto);

            return BadRequest("Wrong credentials");
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsFarmer([FromForm] UserRegistrationDto request)
        {
            User user = await _unitOfWork.MapFromUserRegistrationDtoToUser(request);

            await _unitOfWork.RegisterAsFarmer(user);

            return Ok();

        }

        //[Authorize(Roles = nameof(RoleEnum.Admin))]
        [HttpPost("create-employee")]
        public async Task<IActionResult> CreateEmployee([FromForm] UserRegistrationDto request)
        {
            User user = await _unitOfWork.MapFromUserRegistrationDtoToUser(request);

            try
            {
                TokenDto tokenDto =  await _unitOfWork.RegisterAsEmpolyee(user);
              
                return Ok(tokenDto);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}