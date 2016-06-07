using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EveOnlineMissioningApp.Models;

namespace EveOnlineMissioningApp.Controllers
{

    public class MissionCapturesController : ApiController
    {
        AppDBContext _DBctx = new AppDBContext();

        public IEnumerable<MissionCapture> GetAllMissionCaptures()
        {
            return _DBctx.MissionCaptures.AsEnumerable();
        }

        public MissionCapture GetMissionCapture(int id)
        {
            MissionCapture mc = _DBctx.MissionCaptures.Find(id);

            return mc;
        }
        
        [HttpPost]
        public int CreateMissionCapture([FromBody] MissionCapture mc)
        {
            MissionCapture newMc = _DBctx.MissionCaptures.Add(mc);
            _DBctx.SaveChanges();

            return newMc.id;
        }

        [HttpPut]
        public int UpdateMissionCapture([FromBody] MissionCapture mc)
        {
            //Get the mission capture
            MissionCapture updatedMc = _DBctx.MissionCaptures.Find(mc.id);

            //Update it's values to the new version and save
            _DBctx.Entry(updatedMc).CurrentValues.SetValues(mc);
            _DBctx.SaveChanges();

            return updatedMc.id;
        }

    }
}
