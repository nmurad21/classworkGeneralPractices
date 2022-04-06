using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Utils.Exceptions;

namespace Entities.Models
{
    class Store: IEnumerable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private List<Game> games;
        public void AddGame(Game game)
        {
            var result = games.Find(g => g.Name == game.Name && !g.IsDeleted);
            if (result != null)
                throw new AlreadyExistsException("Bu adda game var");
            games.Add(game);
        }
        public Game GetGameById(int? id)
        {
            if (id==null)
            {
                throw new NullReferenceException("Id bos ola bilmez");
            }
            Game game= games.Find(g => g.Id == id && !g.IsDeleted);
            if (game==null)
            {
                throw new NullReferenceException("Game bos ola bilmez");
            }
            return game;
        }
        public void RemoveGameById(int? id)
        {
            if (id == null)
            {
                throw new NullReferenceException("Null ola bilmez");
            }
            Game game = games.Find(g => !g.IsDeleted && g.Id == id);
            if (game == null)
            {
                throw new NotFoundException("Bele bir game yoxdur");
            }
            game.IsDeleted = true;
        }
        public List<Game> FilterGamesByPrice(double minPrice, double maxPrice)
        {
            List<Game> game= games.FindAll(g => g.Price > minPrice && g.Price < maxPrice && !g.IsDeleted);
            if (game.Count==0)
            {
                throw new NotFoundException("Bu qiymetde game yoxdur");
            }
            return game;
        }
        public List<Game> FilterGamesByDiscountedPrice(double minDiscountedPrice, double maxDiscountedPrice)
        {
           List<Game> game= games.FindAll(g => g.DiscountPercent > minDiscountedPrice && g.DiscountPercent < maxDiscountedPrice && !g.IsDeleted);
            if (game.Count==0)
            {
                throw new NotFoundException("Bu endirimde game yoxdu");
            }
            return game;
        }
        public IEnumerator GetEnumerator()
        {
            foreach (var game in games)
            {
                yield return game;
            }
        }
    }
}
