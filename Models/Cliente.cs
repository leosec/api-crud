using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api_crud.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Nome { get; set; }

        public string Cpf { get; set; }

    }
}
