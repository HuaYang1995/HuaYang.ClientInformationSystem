using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class ClientsResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string phones { get; set; }
    }
}
