using kt7.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace kt7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private static List<Booking> bookings = new List<Booking>();

        [HttpGet]
        public IEnumerable<Booking> Get()
        {
            var query = bookings.AsQueryable();

            //if (!string.IsNullOrEmpty(resourceType))
            //{
            //    query = query.Where(b => b.ResourceType.Equals(StringComparison.OrdinalIgnoreCase));
            //}

            //if (startTime.HasValue && endTime.HasValue)
            //{
            //    query = query.Where(b => b.StartTime >= startTime.Value && b.EndTime <= endTime.Value);
            //}

            return query.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Booking> Get(int id)
        {
            var booking = bookings.FirstOrDefault(b => b.Id == id);
            if (booking == null) return NotFound();
            return booking;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Booking booking)
        {
            booking.Id = bookings.Count > 0 ? bookings.Max(b => b.Id) + 1 : 1;
            bookings.Add(booking);
            return CreatedAtAction(nameof(Get), new { id = booking.Id }, booking);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Booking booking)
        {
            var index = bookings.FindIndex(b => b.Id == id);
            if (index == -1) return NotFound();
            bookings[index] = booking;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var index = bookings.FindIndex(b => b.Id == id);
            if (index == -1) return NotFound();
            bookings.RemoveAt(index);
            return NoContent();
        }
    }
}
