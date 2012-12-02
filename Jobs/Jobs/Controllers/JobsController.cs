using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using com.careerbuilder;
using com.careerbuilder.api;
using com.careerbuilder.api.models.responses;
using com.careerbuilder.api.models;

namespace Jobs.Controllers
{
    public class JobsController : Controller
    {
        public ActionResult Index(String location="Atlanta, GA", String job="Engineer")
        {
            ResponseJobSearch search = MvcApplication.CBApiGlobal.getCBApi().JobSearch()
                  .WhereKeywords(job)
                  .WhereLocation(location)
                  .Search();
            List<JobSearchResult> jobs = search.Results;
            ViewData["Jobbies"] = jobs;
            return View("Jobs");
        }

        public ActionResult Job(String did)
        {
            List<RecommendJobResult> recJobs = MvcApplication.CBApiGlobal.getCBApi().GetRecommendationsForJob(did).GetRange(0, 4);
            Job myJob = MvcApplication.CBApiGlobal.getCBApi().GetJob(did);

            List<Hashtable> recJobData = new List<Hashtable>();
            int count = 0;
            foreach (RecommendJobResult recJob in recJobs)
            {
                count++;
                Hashtable jobMap = new Hashtable();

                jobMap.Add("Title", recJob.Title);
                jobMap.Add("Company", recJob.Company.CompanyName);
                //String jobReq = MvcApplication.CBApiGlobal.getCBApi().GetJob(recJob.JobDid).JobRequirements;
                jobMap.Add("Req", "This would be Job Requirement for Company #" + count);
                recJobData.Add(jobMap);
            }
            ViewData["Job"] = myJob;
            ViewData["RecJobData"] = recJobData;
            return View("Job");
        }
    }
}
