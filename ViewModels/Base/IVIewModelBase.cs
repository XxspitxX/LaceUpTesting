﻿using LaceUpTesting.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaceUpTesting.ViewModels.Base
{
    public interface IViewModelBase : IQueryAttributable
    {
        public INavigationService NavigationService { get; }

        public IAsyncRelayCommand InitializeAsyncCommand { get; }

        public bool IsBusy { get; }

        public bool IsInitialized { get; }

        Task InitializeAsync();
    }
}

