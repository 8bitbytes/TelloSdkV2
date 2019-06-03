using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using TelloSdk;
using TelloSdk.Servers;
using TelloSdk.Commands.Control;
using TelloSdk.Commands.Read;
using TelloSdk.Commands.Set;

using TelloApi.Models;

namespace TelloApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private TelloSdk.TelloManager _manager;

        public ValuesController():
            base()
        {
            _manager = new TelloManager("192.168.1.1", new TelloMockVideoServer(), new TelloMockStateServer(), new TelloMockCommandServer());
        }
        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "welcome";
        }

        #region Control Commands
        [HttpGet("back/{distance}")]
        public ActionResult<string> Back(int distance)
        {
            return _manager.SendCommand(new Back(distance));
        }

        [HttpGet("clockwise/{distance}")]
        public ActionResult<string> Clockwise(int distance)
        {
            return _manager.SendCommand(new Clockwise(distance));
        }

        [HttpGet("command/")]
        public ActionResult<string> Command()
        {
            return _manager.SendCommand(new Command());
        }

        [HttpGet("counterclockwise/{distance}")]
        public ActionResult<string> CounterClockwise(int distance)
        {
            return _manager.SendCommand(new CounterClockwise(distance));
        }

        [HttpGet("curve/{x1}/{x2}/{y1}/{y2}/{z1}/{z2}/speed")]
        public ActionResult<string> Curve(int x1,int x2, int y1, int y2, int z1, int z2,int speed)
        {
            return _manager.SendCommand(new Curve(x1,x2,y1,y2,z1,z2,speed));
        }

        [HttpGet("down/{distance}")]
        public ActionResult<string> Down(int distance)
        {
            return _manager.SendCommand(new Down(distance));
        }

        [HttpGet("emergency/")]
        public ActionResult<string> Emergency()
        {
            return _manager.SendCommand(new Emergency());
        }

        [HttpGet("flip/{direction}")]
        public ActionResult<string> Flip(Flip.FlipDirections direction)
        {
            return _manager.SendCommand(new Flip(direction));
        }

        [HttpGet("forward/{distance}")]
        public ActionResult<string> Forward(int distance)
        {
            return _manager.SendCommand(new Forward(distance));
        }

        [HttpGet("go/{x}/{y}/{z}/{speed}")]
        public ActionResult<string> Go(int x,int y, int z, int speed)
        {
            return _manager.SendCommand(new Go(x,y,z,speed));
        }

        [HttpGet("land/")]
        public ActionResult<string> Land()
        {
            return _manager.SendCommand(new Land());
        }

        [HttpGet("left/{distance}")]
        public ActionResult<string> Left(int distance)
        {
            return _manager.SendCommand(new Left(distance));
        }

        [HttpGet("right/{distance}")]
        public ActionResult<string> Right(int distance)
        {
            return _manager.SendCommand(new Right(distance));
        }

        [HttpGet("setvideostream/{state}")]
        public ActionResult<string> SetVideoStream(int state)
        {
            var cmd = new SetVideoStream();
            cmd.VideoStreamState = state == 1 ? TelloSdk.Commands.Control.SetVideoStream.States.On
                : TelloSdk.Commands.Control.SetVideoStream.States.Off;

            return _manager.SendCommand(cmd);
        }

        [HttpGet("setwifi/{ssid}/{password}")]
        public ActionResult<string> SetWifi(string ssid, string password)
        {
            return _manager.SendCommand(new SetWifi(ssid,password));
        }

        [HttpGet("takeoff/")]
        public ActionResult<string> Takeoff()
        {
            return _manager.SendCommand(new Takeoff());
        }

        [HttpGet("up/{distance}")]
        public ActionResult<string> Up(int distance)
        {
            return _manager.SendCommand(new Up(distance));
        }

        #endregion


        #region Read Commands

        [HttpGet("acceleration")]
        public ActionResult<string> Acceleration()
        {
            return _manager.SendCommand(new Acceleration());
        }

        [HttpGet("attitude")]
        public ActionResult<string> Attitude()
        {
            return _manager.SendCommand(new Attitude());
        }

        [HttpGet("barometer")]
        public ActionResult<string> Barometer()
        {
            return _manager.SendCommand(new Barometer());
        }

        [HttpGet("battery")]
        public ActionResult<string> Battery()
        {
            return _manager.SendCommand(new Battery());
        }

        [HttpGet("height")]
        public ActionResult<string> Height()
        {
            return _manager.SendCommand(new Height());
        }

        [HttpGet("speed")]
        public ActionResult<string> Speed()
        {
            return _manager.SendCommand(new TelloSdk.Commands.Read.Speed());
        }

        [HttpGet("temp")]
        public ActionResult<string> Temp()
        {
            return _manager.SendCommand(new Temp());
        }

        [HttpGet("time")]
        public ActionResult<string> Time()
        {
            return _manager.SendCommand(new Time());
        }

        [HttpGet("tof")]
        public ActionResult<string> TOF()
        {
            return _manager.SendCommand(new TOF());
        }

        [HttpGet("wifi")]
        public ActionResult<string> Wifi()
        {
            return _manager.SendCommand(new TelloSdk.Commands.Read.WIFI());
        }
        #endregion

        #region Set Commands

        [HttpPost("rc")]
        public ActionResult<string> RC([FromBody]RCParams param)
        {
            return _manager.SendCommand(new RC(param.LeftRight,param.ForwardBack,param.UpDown,param.Yaw));
        }

        [HttpPost("speed")]
        public ActionResult<string> SetSpeed([FromBody]int speed)
        {
            return _manager.SendCommand(new TelloSdk.Commands.Set.Speed(speed));
        }

        [HttpPost("wifi")]
        public ActionResult<string> Wifi([FromBody]WifiParams param)
        {
            return _manager.SendCommand(new TelloSdk.Commands.Set.WIFI(param.SSID,param.Password));
        }
        #endregion

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
