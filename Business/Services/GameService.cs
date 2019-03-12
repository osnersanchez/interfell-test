using Domain;
using DTO;
using Repository.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class GameService : IGameService
    {
        private IUnitOfWork _unitOfWork;

        public GameService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public GameDTO Add(GameAddOrEditDTO game)
        {
            Game newGame = new Game()
            {
                Name = game.Name,
                Description = game.Description,
                GameTypeId = game.GameTypeId
            };

            _unitOfWork.GameRepository.Insert(newGame);
            _unitOfWork.Commit();

            return (GameDTO) Get(newGame.Id);
        }

        public void Delete(int id)
        {
            Game game = _unitOfWork.GameRepository.Get(id);
            _unitOfWork.GameRepository.Delete(game);
            _unitOfWork.Commit();
        }

        public Game Get(int id)
        {
            return _unitOfWork.GameRepository.GetList().Where(x=> x.Id == id).FirstOrDefault();
        }

        public List<GameTypeDTO> GetGameTypes()
        {
            return _unitOfWork.GameTypeRepository.GetList().ToList().Select(x => (GameTypeDTO)x).ToList();
        }

        public List<GameDTO> GetList()
        {
           return _unitOfWork.GameRepository.GetList().ToList().Select(x => (GameDTO) x).ToList();
        }

        public GameDTO Put(GameAddOrEditDTO game)
        {
            Game putGame = _unitOfWork.GameRepository.Get(game.Id);

            putGame.Name = game.Name;
            putGame.GameTypeId = game.GameTypeId;
            putGame.Description = game.Description;

            _unitOfWork.GameRepository.Update(putGame);
            _unitOfWork.Commit();

            return (GameDTO) Get(game.Id);
        }
    }
}
