﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entities
{
    public enum Status { Empty, Pending, Completed };
    public class CustomerTasks
    {
        public int Id { get; set; }
        public int Id2 {  get; set; }
        public int Customer_Id { get; set; }
        public string Task_description { get; set; }
        public int Document_type_id { get; set; }
        public string? Document_path { get; set; }
        public string? Document_path2 { get; set; }

        public Status status { get; set; }
        public Status status2 { get; set; }
        public DateTime? Due_date { get; set; }
        public DateTime? Created_at { get; set; }= DateTime.UtcNow;
        public DateTime? Updated_at { get; set; } = DateTime.UtcNow;

        [ForeignKey("DocumentTypeId")]
        public int DocumentTypes { get; set; }

    }
}
