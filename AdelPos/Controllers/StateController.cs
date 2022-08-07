using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Entity;
using POS.Models;

namespace AdelPos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        [Route("GetStateData")]
        [HttpGet]
        public IActionResult GetStateData()
        {
            try
            {
                var data = StateRepo.GetAllStates();
                if (data != null)
                {
                    return Ok(data);
                }
                else
                {
                    return NotFound("there's no data on DataBase");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Error is :{ex.Message}");
            }
            
        }


        [Route("GetStatById")]
        [HttpGet]
        public IActionResult GetStatById(int Id)
        {
           
            var data = StateRepo.GetStatesById(Id);
            return Ok(data);
        }


        [Route("SearchState")]
        [HttpGet]

        public IActionResult SearchState(string name)
        {
            var data = StateRepo.SearchByName(name);
            return Ok(data);
        }



        [Route("EditState")]
        [HttpPost]
        public IActionResult EditState ([FromBody] States states)
        {
            var data = StateRepo.EditState(states);
            return Ok(data);
        }


        [Route("DeleteState")]
        [HttpPost]
        public IActionResult DeleteState([FromBody] int ID)
        {
            try
            {
                var data = StateRepo.DeleteState(ID);
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        [Route("SaveStates")]
        [HttpPost]
        public IActionResult SaveStates([FromBody]States module)
        {
            try
            {
                var data = StateRepo.AddState(module);
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message); 
            }
            
        }

    }
}