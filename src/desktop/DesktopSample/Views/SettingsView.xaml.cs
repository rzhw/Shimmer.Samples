﻿using System.Reactive.Linq;
using System.Windows;
using ReactiveUI;
using ReactiveUI.Xaml;
using Shimmer.DesktopDemo.ViewModels;

namespace Shimmer.DesktopDemo.Views
{
    public partial class SettingsView : IViewFor<SettingsViewModel>
    {
        public SettingsView()
        {
            InitializeComponent();

            this.Bind(ViewModel, vm => vm.UpdateLocation, v => v.UpdateLocation.Text);

            this.OneWayBind(ViewModel, vm => vm.ErrorMessage, v => v.ErrorMessage.Text);
            this.OneWayBind(ViewModel, vm => vm.IsError, v => v.ErrorMessage.Visibility);

            this.OneWayBind(ViewModel, vm => vm.IsSaved, v => v.SavedMessage.Visibility);

            this.BindCommand(ViewModel, vm => vm.BackCommand, v => v.Back);
            this.BindCommand(ViewModel, vm => vm.SelectFolder, v => v.OpenFolder);
        }

        public SettingsViewModel ViewModel
        {
            get { return (SettingsViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(SettingsViewModel), typeof(SettingsView), new PropertyMetadata(null));

        object IViewFor.ViewModel
        {
            get { return ViewModel; }
            set { ViewModel = (SettingsViewModel)value; }
        }
    }
}