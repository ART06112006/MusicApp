using MusicApp.Exceptions;
using MusicApp.Infrastructure;
using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;

namespace MusicApp.Services
{
    public class BuyAlbumService
    {
        public Action<string> ShowTransactionErrorMessage { get; set; }
        public Action ShowNotEnoughMoneyErrorMessage { get; set; }
        public Action ShowAlreadyBoughtItemErrorMessage { get; set; }
        public Action ShowSuccessfulTransferMessage { get; set; }

        public void BuyAlbum(User user, Album album)
        {
            var userService = (UserService)(AppServiceProvider.ServiceProvider.GetService(typeof(UserService)));

            var cost = album.Price * (1 - album.Discount / 100);

            if (user.Balance >= cost)
            {
                using (var transaction = new TransactionScope())
                {
                    try
                    {
                        var albumService = (AlbumService)(AppServiceProvider.ServiceProvider.GetService(typeof(AlbumService)));

                        var artist = new Artist()
                        {
                            Name = album.Artist.Name,
                            Country = album.Artist.Country,
                            Year = album.Artist.Year,
                            Photo = album.Artist.Photo
                        };

                        var tracks = new List<Track>();

                        foreach (var i in album.Tracks)
                        {
                            tracks.Add(new Track()
                            {
                                Name = i.Name,
                                Number = i.Number,
                                Clip = i.Clip,
                                Preview = i.Preview,
                                AlbumId = artist.Id
                            });
                        }

                        albumService.AddAlbum(new Album()
                        {
                            UserId = user.Id,
                            Name = album.Name,
                            Artist = artist,
                            Year = album.Year,
                            Genre = album.Genre,
                            Photo = album.Photo,
                            Tracks = tracks,
                            Price = album.Price,
                            Discount = album.Discount,
                            DownloadsNumber = 0
                        });
                        
                        user.Balance -= cost;
                        userService.UpdateUser(user);

                        var newAlbum = new Album()
                        {
                            UserId = album.UserId,
                            Name = album.Name,
                            Artist = album.Artist,
                            Year = album.Year,
                            Genre = album.Genre,
                            Photo = album.Photo,
                            Price = album.Price,
                            DownloadsNumber = album.DownloadsNumber,
                            Discount = album.Discount
                        };
                        newAlbum.DownloadsNumber++;
                        albumService.UpdateAlbum(album, newAlbum);

                        transaction.Complete();

                        ShowSuccessfulTransferMessage?.Invoke();
                    }
                    catch (ItemExistsException)
                    {
                        ShowAlreadyBoughtItemErrorMessage?.Invoke();
                    }
                    catch (Exception ex)
                    {
                        ShowTransactionErrorMessage?.Invoke(ex.Message);
                    }
                }
            }
            else
            {
                ShowNotEnoughMoneyErrorMessage?.Invoke();
            }
        }
    }
}
