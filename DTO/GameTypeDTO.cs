using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class GameTypeDTO
    {
        public GameTypeDTO()
        {
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public static explicit operator GameTypeDTO(GameType model)
        {
            GameTypeDTO dto = new GameTypeDTO();
            if(model != null)
            {
                dto.Id = model.Id;
                dto.Title = model.Title;
            }
            return dto;
        }
    }
}
