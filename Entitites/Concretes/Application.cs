﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Application : BaseEntity<int>
    {
        //id,applicant_id,bootcamp_id,applicationState_id
        public int ApplicantId { get; set; }
        public int BootcampId { get; set; }
        public int ApplicationStateId { get; set; }

        public virtual Applicant? Applicant { get; set; }
        public virtual Bootcamp? Bootcamp { get; set; }
        public virtual ApplicationState? ApplicationState { get; set; }

        public Application(int id, int applicantId, int bootcampId, int applicationStateId)
        {
            Id = id;
            ApplicantId = applicantId;
            BootcampId = bootcampId;
            ApplicationStateId = applicationStateId;
        }

        public Application()
        {

        }

    }
}
