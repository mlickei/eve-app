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
        MissionCaptureContext _ctxMissionCapture = new MissionCaptureContext();

        public IEnumerable<MissionCapture> GetAllMissionCaptures()
        {
            return _ctxMissionCapture.MissionCaptures.AsEnumerable();
        }

        public MissionCapture GetMissionCapture(int id)
        {
            MissionCapture mc = _ctxMissionCapture.MissionCaptures.Find(id);

            return mc;
        }
        
        [HttpPost]
        public int CreateMissionCapture([FromBody] MissionCapture mc)
        {
            MissionCapture newMc = _ctxMissionCapture.MissionCaptures.Add(mc);
            _ctxMissionCapture.SaveChanges();

            return newMc.id;
        }

        [HttpPut]
        public int UpdateMissionCapture([FromBody] MissionCapture mc)
        {
            //Get the mission capture
            MissionCapture updatedMc = _ctxMissionCapture.MissionCaptures.Find(mc.id);

            //Update it's values to the new version and save
            _ctxMissionCapture.Entry(updatedMc).CurrentValues.SetValues(mc);
            _ctxMissionCapture.SaveChanges();

            return updatedMc.id;
        }

    }
}
