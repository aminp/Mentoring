using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task01.Models
{
    public enum Status
    {
        Ready, Started, Finished
    }

    public class Project
    {

        public int ProjectID { get; set; }

        [DisplayName("Number of Developers")]
        public int DeveloperCount { get; set; }

        [DisplayName("Project Title")]
        public String ProjectTitle { get; set; }

        [DisplayName("Project Manager")]
        public String ProjectManager { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "Not Started")]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Finished Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", NullDisplayText = "Not Finished")]
        public DateTime? FinishedDate { get; set; }

        [DisplayName("Project Status")]
        public Status? ProjectStatus { get; set; }
    }
}