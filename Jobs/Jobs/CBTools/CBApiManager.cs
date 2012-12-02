using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using com.careerbuilder;
using com.careerbuilder.api;
using com.careerbuilder.api.models.responses;

namespace Jobs.CBTools
{
    public class CBApiManager
    {
        private ICBApi myApi;

        public CBApiManager(String key)
        {
            myApi = API.GetInstance(key);
        }

        public ICBApi getCBApi()
        {
            return myApi;
        }
    }
}

