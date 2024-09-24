using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MusicApp.Commands;
using MusicApp.Context;
using MusicApp.Repositories;
using MusicApp.Services;
using MusicApp.ViewModels;
using MusicApp.ViewModels.UserViewModels;
using MusicApp.Views;
using MusicApp.Views.UserView;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApp.Infrastructure
{
    public static class AppServiceProvider
    {
        public static ServiceProvider ServiceProvider { get; private set; }
        public static void Initialize()
        {
            var services = new ServiceCollection();

            //Context
            services.AddDbContext<MusicDbContext>();

            //Repositories
            services.AddTransient<AlbumRepository, AlbumRepository>();
            services.AddTransient<TrackRepository, TrackRepository>();
            services.AddTransient<UserRepository, UserRepository>();

            //Services
            services.AddSingleton<AlbumService, AlbumService>();
            services.AddSingleton<TrackService, TrackService>();
            services.AddSingleton<AuthorizationService, AuthorizationService>();
            services.AddSingleton<BuyAlbumService, BuyAlbumService>();
            services.AddSingleton<UserService, UserService>();

            //Views
            services.AddTransient<AddAlbumView, AddAlbumView>();
            services.AddTransient<AddTrackView, AddTrackView>();
            services.AddTransient<MainView, MainView>();
            services.AddTransient<ShowAlbumView, ShowAlbumView>();
            services.AddTransient<UpdateArtistView, UpdateArtistView>();
            services.AddTransient<UpdateAlbumView, UpdateAlbumView>();
            services.AddTransient<LoginView, LoginView>();
            services.AddTransient<SignUpView, SignUpView>();
            services.AddTransient<ProfileView, ProfileView>();
            services.AddTransient<UserBuyAlbumView, UserBuyAlbumView>();
            services.AddTransient<UserMainView, UserMainView>();
            services.AddTransient<UserShowMyAlbumView, UserShowMyAlbumView>();
            services.AddTransient<UserProfileView, UserProfileView>();
            services.AddTransient<UserTopUpAccountView, UserTopUpAccountView>();

            //ViewModels
            services.AddTransient<AddAlbumViewModel, AddAlbumViewModel>();
            services.AddTransient<AddTrackViewModel, AddTrackViewModel>();
            services.AddTransient<MainViewModel, MainViewModel>();
            services.AddTransient<ShowAlbumViewModel, ShowAlbumViewModel>();
            services.AddTransient<UpdateArtistViewModel, UpdateArtistViewModel>();
            services.AddTransient<UpdateAlbumViewModel, UpdateAlbumViewModel>();
            services.AddTransient<LoginViewModel, LoginViewModel>();
            services.AddTransient<SignUpViewModel, SignUpViewModel>();
            services.AddTransient<ProfileViewModel, ProfileViewModel>();
            services.AddTransient<UserBuyAlbumViewModel, UserBuyAlbumViewModel>();
            services.AddTransient<UserMainViewModel, UserMainViewModel>();
            services.AddTransient<UserShowMyAlbumViewModel, UserShowMyAlbumViewModel>();
            services.AddTransient<UserProfileViewModel, UserProfileViewModel>();
            services.AddTransient<UserTopUpAccountViewModel, UserTopUpAccountViewModel>();

            //Commands
            services.AddTransient<AddAlbumCommand, AddAlbumCommand>();
            services.AddTransient<AddAlbumCommandChangeViewCommand, AddAlbumCommandChangeViewCommand>();
            services.AddTransient<AddTrackChangeViewCommand, AddTrackChangeViewCommand>();
            services.AddTransient<AddTrackCommand, AddTrackCommand>();
            services.AddTransient<RemoveAlbumCommand, RemoveAlbumCommand>();
            services.AddTransient<RemoveTrackCommand, RemoveTrackCommand>();
            services.AddTransient<ShowAlbumChangeViewCommand, ShowAlbumChangeViewCommand>();
            services.AddTransient<UpdateAlbumChangeViewCommand, UpdateAlbumChangeViewCommand>();
            services.AddTransient<UpdateAlbumCommand, UpdateAlbumCommand>();
            services.AddTransient<UpdateArtistChangeViewCommand, UpdateArtistChangeViewCommand>();
            services.AddTransient<UpdateArtistCommand, UpdateArtistCommand>();
            services.AddTransient<RefreshAlbumsCommand, RefreshAlbumsCommand>();
            services.AddTransient<OpenClipCommand, OpenClipCommand>();
            services.AddTransient<LoginUserCommand, LoginUserCommand>();
            services.AddTransient<SignUpUserCommand, SignUpUserCommand>();
            services.AddTransient<SignUpUserChangeViewCommand, SignUpUserChangeViewCommand>();
            services.AddTransient<ChangeProfileCommand, ChangeProfileCommand>();
            services.AddTransient<ProfileChangeViewCommand, ProfileChangeViewCommand>();
            services.AddTransient<Commands.UserCommands.OpenClipCommand, Commands.UserCommands.OpenClipCommand>();
            services.AddTransient<Commands.UserCommands.OpenPreviewCommand, Commands.UserCommands.OpenPreviewCommand>();
            services.AddTransient<Commands.UserCommands.UserBuyAlbumCommand, Commands.UserCommands.UserBuyAlbumCommand>();
            services.AddTransient<Commands.UserCommands.UserRemoveMyAlbumCommand, Commands.UserCommands.UserRemoveMyAlbumCommand>();
            services.AddTransient<Commands.UserCommands.UserShowAlbumChangeViewCommand, Commands.UserCommands.UserShowAlbumChangeViewCommand>();
            services.AddTransient<Commands.UserCommands.UserShowMyAlbumChangeViewCommand, Commands.UserCommands.UserShowMyAlbumChangeViewCommand>();
            services.AddTransient<Commands.UserCommands.UserRefreshMyAlbumsCommand, Commands.UserCommands.UserRefreshMyAlbumsCommand>();
            services.AddTransient<Commands.UserCommands.UserChangeProfileCommand, Commands.UserCommands.UserChangeProfileCommand>();
            services.AddTransient<Commands.UserCommands.UserProfileChangeViewCommand, Commands.UserCommands.UserProfileChangeViewCommand>();
            services.AddTransient<Commands.UserCommands.UserTopUpAccountChangeViewCommand, Commands.UserCommands.UserTopUpAccountChangeViewCommand>();
            services.AddTransient<Commands.UserCommands.UserTopUpAccountCommand, Commands.UserCommands.UserTopUpAccountCommand>();

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
