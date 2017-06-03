using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApi.Controllers
{
    
    [Route("api/[controller]")]
    public class BeaconController : Controller
    {
        private readonly BeaconContext _context;

        public BeaconController(BeaconContext context)
        {
            _context = context;

            if (_context.Beacons.Count() == 0)
            {
                _context.Beacons.Add(new Beacon{BeaconName="lemon", UUID="B9407F30-F5F8-466E-AFF9-25556B57FE6D", Major= 38948, Minor=18761, Brand="Estimote"});
                _context.SaveChanges();
            }

        } //end constructor

        [HttpGet]
        public IEnumerable<Beacon> GetAll()
        {
            return _context.Beacons.ToList();
        }

        [HttpGet("{id}", Name = "GetBeacon")]
        public IActionResult GetById(int id)
        {
            var item = _context.Beacons.FirstOrDefault(t => t.BeaconID == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Beacon item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Beacons.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetBeacon", new { id = item.BeaconID }, item);
        }


        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Beacon item)
        {
            if (item == null || item.BeaconID != id)
            {
                return BadRequest();
            }

            var beacon = _context.Beacons.FirstOrDefault(t => t.BeaconID == id);
            if (beacon == null)
            {
                return NotFound();
            }

            beacon.BeaconName = item.BeaconName;
            beacon.Brand = item.Brand;
            beacon.UUID = item.UUID;
            beacon.Major = item.Major;
            beacon.Minor = item.Minor;

            _context.Beacons.Update(beacon);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Beacons.First(t => t.BeaconID == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Beacons.Remove(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }


    } //end class
} //end namespace

