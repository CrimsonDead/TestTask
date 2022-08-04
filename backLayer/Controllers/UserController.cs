using dataLayer.Models;
using dataLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace backLayer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly IRepository<User> _userRepository;

        public UserController(ILogger<UserController> logger, IRepository<User> userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpGet(Name = "GetUser")]
        public object GetUser([FromQuery] int unp)
        {
            bool isLocalUserExist;
            var internalUser = _userRepository.GetItem(unp); 
            isLocalUserExist = internalUser != null ? true : false;
            string url = string.Format($"http://www.portal.nalog.gov.by/grp/getData?unp=" + unp.ToString() + "&charset=UTF-8&type=json");
            using (WebClient client = new WebClient())
            {
                try
                {
                    string json = client.DownloadString(url);
                    ExternalUser weatherInfo = JsonSerializer.Deserialize<ExternalUser>(json);
                    return new { isLocalUserExist = isLocalUserExist, isExternalUserExist = true };
                }
                catch (Exception)
                {
                    return new { isLocalUserExist = isLocalUserExist, isExternalUserExist = false };
                }
            }
        }

    }
}