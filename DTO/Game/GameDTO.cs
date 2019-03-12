using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GameDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GameType { get; set; }
        public int GameTypeId { get; set; }

        public static explicit operator GameDTO (Game model)
        {
            GameDTO dto = new GameDTO();

            if (model != null)
            {
                dto.Id = model.Id;
                dto.Name = model.Name;
                dto.Description = model.Description;
                dto.GameType = model.GameType.Title;
                dto.GameTypeId = model.GameTypeId;
            }

            return dto;

        }
    }
}
