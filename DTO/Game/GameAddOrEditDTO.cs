using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GameAddOrEditDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int GameTypeId { get; set; }

        public static explicit operator GameAddOrEditDTO(Game model)
        {
            GameAddOrEditDTO dto = new GameAddOrEditDTO();

            if (model != null)
            {
                dto.Id = model.Id;
                dto.Name = model.Name;
                dto.Description = model.Description;
                dto.GameTypeId = model.GameType.Id;
            }

            return dto;

        }
    }
}
