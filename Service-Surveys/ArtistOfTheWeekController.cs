using System.Collections.Generic;
using AutoMapper;
using Surveys.Data;
using Surveys.Dtos;
using Surveys.Models;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace Surveys.Controllers
{
    [Route("api/artistoftheweek/")]
    [ApiController]
    public class ArtistOfTheWeekController : ControllerBase
    {
        private readonly IArtistRepo _repository;

        private readonly IMapper _mapper; 

        public ArtistOfTheWeekController(IArtistRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/artistoftheweek/
        [HttpGet]
        public ActionResult <IEnumerable<ArtistReadDto>> GetArtistsOfTheWeek()
        {
            var artistItems = _repository.GetArtistsOfTheWeek();
            return Ok(_mapper.Map<IEnumerable<ArtistReadDto>>(artistItems));
        }

        // GET api/artistoftheweek/{id}
        [HttpGet("{id}", Name="GetArtistOfTheWeekById")]
        public ActionResult <ArtistReadDto> GetArtistOfTheWeekById(int id)
        {
            var artistItem = _repository.GetArtistOfTheWeekById(id);
            if(artistItem != null)
            {
                return Ok(_mapper.Map<ArtistReadDto>(artistItem));
            }
            return NotFound();
        }

        // POST api/artistoftheweek/
        [HttpPost]
        public ActionResult <ArtistReadDto> CreateArtistApplication(ArtistApplicationDto artistApplicationDto)
        {
            var artist = _mapper.Map<ArtistOfTheWeek>(artistApplicationDto);
            // create a new contact in the repository
            _repository.CreateArtistApplication(artist);
            // save new contact
            _repository.SaveChanges();

            var ArtistReadDto = _mapper.Map<ContactReadDto>(artist);
            // response
            return CreatedAtRoute(nameof(GetArtistOfTheWeekById), new {Id = ArtistReadDto.Id}, ArtistReadDto);
        }
    }
}