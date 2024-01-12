using System.ComponentModel.DataAnnotations;
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phrase.Models
{

public class PalindromModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Text { get; set; }
}

}