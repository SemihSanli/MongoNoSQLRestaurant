using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.BusinessLayer.Abstract;
using Restaurant.DTO.TeamDTO;
using Restaurant.EntityLayer.Entities;

namespace Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _teamTeam;

        public TeamController(ITeamService teamTeam)
        {
            _teamTeam = teamTeam;
        }

        [HttpGet]
        public IActionResult TeamList()
        {
            var values = _teamTeam.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateTeam(CreateTeamDTO createTeamDTO)
        {
            Team team = new Team()
            {
               TeamFullName = createTeamDTO.TeamFullName,
                TeamImageURL = createTeamDTO.TeamImageURL,
                TeamSocialMedia1 = createTeamDTO.TeamSocialMedia1,
                TeamSocialMedia2 = createTeamDTO.TeamSocialMedia2,
                TeamSocialMedia3 = createTeamDTO.TeamSocialMedia3,
                TeamSocialMedia4 = createTeamDTO.TeamSocialMedia4,
                TeamTitle = createTeamDTO.TeamTitle
            };
            _teamTeam.TInsert(team);
            return Ok("Hakkımda Kısmı Başarıyla Oluşturuldu");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTeam(string id)
        {
            _teamTeam.TDelete(id);
            return Ok("Hakkımda başarıyla silindi");
        }
        [HttpPut]
        public IActionResult UpdateTeam(UpdateTeamDTO updateTeamDTO)
        {
            Team team = new Team()
            {
                Id = updateTeamDTO.Id,
                TeamFullName = updateTeamDTO.TeamFullName,
                TeamImageURL = updateTeamDTO.TeamImageURL,
                TeamSocialMedia1 = updateTeamDTO.TeamSocialMedia1,
                TeamSocialMedia2 = updateTeamDTO.TeamSocialMedia2,
                TeamSocialMedia3 = updateTeamDTO.TeamSocialMedia3,
                TeamSocialMedia4 = updateTeamDTO.TeamSocialMedia4,
                TeamTitle = updateTeamDTO.TeamTitle
            };
            _teamTeam.TUpdate(team);
            return Ok("Hakkımda başarıyla güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetTeamById(string id)
        {
            var values = _teamTeam.TGetByID(id);
            return Ok(values);
        }
    }
}
