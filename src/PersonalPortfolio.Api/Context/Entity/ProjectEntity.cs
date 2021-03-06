﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalPortfolio.Context.Entity
{
    public class ProjectEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Url { get; set; }
        public string ShowcaseImage { get; set; }
        public IList<ImageEntity> Images { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<TechnologyEntity> Technologies { get; set; }
    }
}
