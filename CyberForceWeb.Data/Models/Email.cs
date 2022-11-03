using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberForceWeb.Data.Models;
public class Email
{
    public int EmailId { get; set; }
    public string SenderName { get; set; } = null!;
    public string SenderEmailAddress { get; set; } = null!;
}