using HW_OOP_96.Infrastructure.Commands;
using HW_OOP_96.Model;
using HW_OOP_96.Service;
using HW_OOP_96.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace HW_OOP_96.ViewModel
{
    public class GridViewViewModel : ViewModelBase
    {
        private ObservableCollection<Product> _products;

        public ObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                if (_products != value)
                {
                    _products = value;
                    OnPropertyChanged(nameof(Products));
                }
            }
        }

        public ICommand SaveToCSV { get; }
        private void OnSaveToCsv(object obj)
        {
            var csvFileWrite = new CSVFileWrite();
            csvFileWrite.SaveToCsv(Products, "PProduct.csv");
        }


        public GridViewViewModel()
        {
            Products = ProductListCreator.GetProducts();
            SaveToCSV = new GetValueFromGridCommand((p) => true, OnSaveToCsv);
        }
    }
}

