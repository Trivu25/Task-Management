using System;
using System.Collections.Generic;

namespace TaskManagement.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public string? Title { get; set; }

    public DateTime? DueDate { get; set; }

    public int? Priority { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedOn { get; set; }

    public DateTime? ModifiedOn { get; set; }

    public int? UserId { get; set; }

    public string? Description { get; set; }

    public virtual User? User { get; set; }
}
