using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBizTrip.Domain.Enums
{
    public enum StatusVariants
    {
        New,        //when the form is created by TL and sent to admin
        Pending,    //when is sent to HR (HR receives it with pending)
        Approved,   //HR can change it
        Declined,   //HR can change it
        RequestedChange,     //Just TL can request a change
        Finished,    //TeamLead chooses the right delegation request(those ones cannot be changed by anyone but TL => gonna be changed just in New so admin can change the budget)
        Obsolete     //no action was taken in time and the date has passed 
    }
}
