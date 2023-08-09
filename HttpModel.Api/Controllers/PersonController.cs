using AutoMapper;
using HttpModel.Api.Data;
using HttpModel.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HttpModel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ApiDbcontext _context;
        private readonly IMapper _mapper;

        public PersonController(ApiDbcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("AddPerson")]
        public async Task<string> Add([FromBody] PersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            _context.Persons.Add(person);
            var res =await _context.SaveChangesAsync();
            if(res >=1)
            {
                return "Sucess";
            }
            return "Request not sucessfull";
        }

        [HttpGet("GetPerons")]
        public async Task<List<PersonDto>> GetPerson()
        { 
            List<PersonDto> persons = new();
            var mappedPersons = await _context.Persons.ToListAsync();
            foreach (var mappedPerson in mappedPersons)
            {
                var person = _mapper.Map<PersonDto>(mappedPerson);
                persons.Add(person);
            }
            return persons;
        }
    }
}
