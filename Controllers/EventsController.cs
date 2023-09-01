using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Events.Models;
using Events.Requests;
using Events.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Events.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEvents _eventService;
        private readonly IMapper _imapper;

        public EventsController(IEvents eventService, IMapper imapper)
        {
            _eventService = eventService;
            _imapper = imapper;
        }
        [HttpPost]
        public async Task<ActionResult<string>> AddEvent(CreateEvent newEvent){
            var events = _imapper.Map<Event>(newEvent);
            var res = await _eventService.CreateEventAsync(events);
            return CreatedAtAction(nameof(AddEvent),  res);
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetEvents(string?location){
            var events = await _eventService.GetEventsAsync(location);
            return Ok(events);
        }

         [HttpGet("{id}")]
        public async Task<ActionResult<Event>> Getevents(Guid id){
            var events = await _eventService.GetOneEventAsync(id);
            if(events == null){
                return NotFound( "Instructor not found");
            }
            return Ok(events);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateEvent(Guid id, CreateEvent updatedEvent){
            var response = await _eventService.GetOneEventAsync(id);
            if(response == null){
                return NotFound("instructor not found");
            }
            var updated = _imapper.Map(updatedEvent, response);
            var res = await _eventService.UpdateEventAsync(updated);
            return Ok(res);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteEvent(Guid id){
            var response = await _eventService.GetOneEventAsync(id);
            if(response == null){
                return NotFound("Instructor not found");
            }
            var res = await _eventService.DeleteEventAsync(response);
            return Ok(res);
        }
        
    }
}