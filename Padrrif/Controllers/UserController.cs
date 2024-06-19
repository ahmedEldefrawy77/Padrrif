namespace Padrrif.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserUnitOfWork _unitOfWork;

        public UserController(IUserUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        [Authorize(Roles = nameof(RoleEnum.Empolyee))]
        [HttpGet("unconfirmed-users")]
        public async Task<IActionResult> Get()
        {
            List<User> users = await _unitOfWork.GetAllUnConfirmedUsers();

            return Ok(users);   
        }
        [Authorize(Roles = nameof(RoleEnum.Empolyee))]
        [HttpPost("confirm-user")]
        public async Task<IActionResult> ConfirmUser(int id)
        {
            bool isUpdated = await _unitOfWork.ConfirmUser(id);

            if (isUpdated)
                return Ok();

            return BadRequest();
        }

        [HttpGet("User-List")]
        public async Task<IActionResult> GetUserListWithEnum(int enid)
        {
            List<User>? users = await _unitOfWork.GetAllUserBasedOnStatuse(enid);
            return Ok(users);
        }
        [HttpGet("User-List-Id")]
        public async Task<IActionResult> GetUserWithIdentityNo(int id)
        {
            User? user = await _unitOfWork.GetUserWithIdentityNumber(id);
            if(user != null)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest("there is no User With Id Check the Id again");
            }
        }
        [HttpGet("User-List-Name")]
        public async Task<IActionResult> GetUserWithName(string name)
        {
            List<User>? users = await _unitOfWork.GetUserWithName(name);
            if ( users != null)
            {
                return Ok(users);
            }
            else
            {
                return BadRequest("there is no User With this Name Check your Identity Number again");
            }
        }
        [Authorize(Roles = nameof(RoleEnum.Farmer))]
        [HttpPut("Update-user")]
        public async Task<IActionResult> UpdateUser(User user)
        {
           string res =  await _unitOfWork.UpdateUser(user);
            return Ok(res);
        }
    }
}
