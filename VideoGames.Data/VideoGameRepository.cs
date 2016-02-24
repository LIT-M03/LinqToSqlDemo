using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGames.Data
{
    public class VideoGameRepository
    {
        private string _connectionString;

        public VideoGameRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<VideoGame> GetAll()
        {
            using (var context = new VideoGamesDataContext(_connectionString))
            {
                return context.VideoGames.ToList();
            }
        }

        public void AddGame(VideoGame videoGame)
        {
            using (var context = new VideoGamesDataContext(_connectionString))
            {
                context.VideoGames.InsertOnSubmit(videoGame);
                context.SubmitChanges();
            }
        }

        public void UpdateGame(VideoGame videoGame)
        {
            using (var context = new VideoGamesDataContext(_connectionString))
            {
                context.VideoGames.Attach(videoGame);
                context.Refresh(RefreshMode.KeepCurrentValues, videoGame);
                context.SubmitChanges();
            }
        }

        public void DeleteGame(int gameId)
        {
            using (var context = new VideoGamesDataContext(_connectionString))
            {
                //var game = context.VideoGames.FirstOrDefault(g => g.Id == gameId);
                //context.VideoGames.DeleteOnSubmit(game);
                //context.SubmitChanges();
                context.ExecuteCommand("DELETE FROM VideoGames WHERE Id = {0}", gameId);
            }
        }

    }
}
