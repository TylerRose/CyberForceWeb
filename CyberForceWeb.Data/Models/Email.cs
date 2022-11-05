using IntelliTect.Coalesce.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberForceWeb.Data.Models;
[Read(SecurityPermissionLevels.AllowAll)]
[Edit(SecurityPermissionLevels.AllowAll)]
public class Email
{
    public int EmailId { get; set; }
    public string SenderName { get; set; } = null!;
    public string SenderEmailAddress { get; set; } = null!;
}