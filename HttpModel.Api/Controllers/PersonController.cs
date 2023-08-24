using AutoMapper;
using HttpModel.Api.Data;
using HttpModel.Api.Model;
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
        public async Task<ActionResult<List<PersonDto>>> GetPerson()
        { 
            List<PersonDto> persons = new();
            var mappedPersons = await _context.Persons.ToListAsync();
            foreach (var mappedPerson in mappedPersons)
            {
                var person = _mapper.Map<PersonDto>(mappedPerson);
                persons.Add(person);
            }
            return Ok(persons);
        }

        [HttpGet ("GetPersonById")]
        public async Task<ActionResult<PersonDto>> GetPersonById([FromHeader]int id)
        {
            var res = await _context.Persons.FirstOrDefaultAsync(x => x.Id == id);
            var result = _mapper.Map<PersonDto>(res);
            return Ok(result);
        }
    }
}
